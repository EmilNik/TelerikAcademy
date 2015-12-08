namespace RealEstate.Web.Api.Models.RealEstates
{
    using System;
    using System.Collections.Generic;

    using AutoMapper;
    using Comments;
    using Data.Models;
    using Infrastructure.Mappings;

    public class ListedRealEstateResponseModelForPublic : IMapFrom<RealEstate>, IHaveCustomMappings, IRealEstateResponseModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime DateCreated { get; set; }

        public RealEstateType RealEstateType { get; set; }

        public int? ConstructionYear { get; set; }

        public string Address { get; set; }

        public bool CanBeSold { get; set; }

        public bool CanBeRented { get; set; }

        public string Contact { get; set; }

        public string UserName { get; set; }

        public IEnumerable<ListCommentRequestModel> Comments { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<RealEstate, ListedRealEstateResponseModelForPublic>()
                .ForMember(r => r.UserName, opts => opts.MapFrom(r => r.User.UserName));
        }
    }
}