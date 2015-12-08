namespace RealEstate.Web.Api.Models.Users
{
    using AutoMapper;
    using Data.Models;
    using Infrastructure.Mappings;

    public class ListUserRequestModel : IMapFrom<User>, IHaveCustomMappings
    {
        public string UserName { get; set; }

        public int Comments { get; set; }

        public int RealEstates { get; set; }

        public double Rating { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<User, ListUserRequestModel>()
                .ForMember(r => r.UserName, opts => opts.MapFrom(r => r.UserName))
                .ForMember(r => r.Comments, opts => opts.MapFrom(r => r.Comments.Count))
                .ForMember(r => r.Rating, opts => opts.MapFrom(r => r.Raiting))
                .ForMember(r => r.RealEstates, opts => opts.MapFrom(r => r.RealEstates.Count));
        }
    }
}