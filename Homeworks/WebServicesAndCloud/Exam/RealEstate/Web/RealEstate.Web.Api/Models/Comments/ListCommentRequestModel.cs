using RealEstate.Data.Models;
using RealEstate.Web.Api.Infrastructure.Mappings;
using System;
using AutoMapper;

namespace RealEstate.Web.Api.Models.Comments
{
    public class ListCommentRequestModel : IMapFrom<Comment>, IHaveCustomMappings
    {
        public string Content { get; set; }

        public string UserId { get; set; }

        public DateTime CreatedOn { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Comment, ListCommentRequestModel>()
                .ForMember(r => r.CreatedOn, opts => opts.MapFrom(r => r.DateCreated));
        }
    }
}