namespace RealEstate.Web.Api.Controllers
{
    using System.Web.Http;
    using System.Linq;

    using AutoMapper.QueryableExtensions;
    using Infrastructure;
    using Models.RealEstates;
    using Services.Data.Contracts;

    public class RealEstatesController : ApiController
    {
        private readonly IRealEstateService realEstates;
        private IUserIdProvider userIdProvider;

        public RealEstatesController(IUserIdProvider idProvider, IRealEstateService realEstates)
        {
            this.realEstates = realEstates;
            this.userIdProvider = idProvider;
        }

        public IHttpActionResult Get()
        {
            var realEstates = this.realEstates.GetAllRealEstates();
            return this.Ok(realEstates);
        }

        public IHttpActionResult Get(int skip, int take)
        {
            var currentUserId = this.userIdProvider.GetUserId();
            IRealEstateResponseModel result;
            
            var realEstates = this.realEstates.GetRealEstates(skip, take);

            if (currentUserId == null)
            {
                result = realEstates.ProjectTo<ListedRealEstateResponseModelForUsers>().FirstOrDefault();
            }
            else
            {
                result = realEstates.ProjectTo<ListedRealEstateResponseModelForPublic>().FirstOrDefault();
            }

            if (result == null)
            {
                return this.NotFound();
            }

            return this.Ok(realEstates);
        }
        
        public IHttpActionResult Get(int id)
        {
            var currentUserId = this.userIdProvider.GetUserId();

            var realEstate = this.realEstates.GetRealEstateById(id);
            IRealEstateResponseModel result;

            if (currentUserId == null)
            {
                result = realEstate.ProjectTo<ListedRealEstateResponseModelForPublic>().FirstOrDefault();
            }
            else
            {
                result = realEstate.ProjectTo<ListedRealEstateResponseModelForUsers>().FirstOrDefault();
            }

            if (result == null)
            {
                return this.NotFound();
            }

            return this.Ok(result);
        }

        [Authorize]
        public IHttpActionResult Post(CreateRealEstateRequestModel model)
        {
            var currentUserId = this.userIdProvider.GetUserId();

            if (model.SellingPrice != null)
            {
                model.CanBeSold = true;
            }

            if (model.RentingPrice != null)
            {
                model.CanBeRented = true;
            }

            var newRealEstate = this.realEstates
                .CreateRealEstate
                (
                    model.Title,
                    model.Description,
                    model.Contact,
                    currentUserId,
                    model.CanBeSold,
                    model.CanBeRented,
                    model.SellingPrice,
                    model.RentingPrice
                );

            var realEstateResult = realEstates
                .GetRealEstateById(newRealEstate.Id)
                .ProjectTo<ListedRealEstateAfterCreating>()
                .FirstOrDefault();

            return this.Created(string.Format("/api/RealEstate/{0}", newRealEstate.Id), realEstateResult);
        }
    }
}