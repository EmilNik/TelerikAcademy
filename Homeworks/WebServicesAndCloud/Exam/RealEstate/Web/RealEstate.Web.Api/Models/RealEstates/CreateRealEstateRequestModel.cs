namespace RealEstate.Web.Api.Models.RealEstates
{
    using System.ComponentModel.DataAnnotations;

    using Common.Constants;

    public class CreateRealEstateRequestModel : IRealEstateResponseModel
    {
        [Required]
        [MinLength(RealEstateConstants.TitleMinLength)]
        [MaxLength(RealEstateConstants.TitleMaxLength)]
        public string Title { get; set; }

        [Required]
        [MinLength(RealEstateConstants.DescriptionMinLength)]
        [MaxLength(RealEstateConstants.DescriptionMaxLength)]
        public string Description { get; set; }

        [Required]
        public string Contact { get; set; }

        public bool CanBeSold { get; set; }

        public bool CanBeRented { get; set; }

        public int? SellingPrice { get; set; }

        public int? RentingPrice { get; set; }
    }
}