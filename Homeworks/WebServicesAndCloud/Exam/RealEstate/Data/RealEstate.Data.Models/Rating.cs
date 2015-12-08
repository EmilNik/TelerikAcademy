namespace RealEstate.Data.Models
{
    using Common.Constants;
    using System.ComponentModel.DataAnnotations;

    public class Rating
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Range(RatingConstants.RatingMinValue, RatingConstants.RatingMaxValue)]
        public double Value { get; set; }

        public string UserId { get; set; }
    }
}
