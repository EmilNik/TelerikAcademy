namespace RealEstate.Data.Models
{
    using Common.Constants;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class RealEstate
    {
        private ICollection<Comment> comments;

        public RealEstate()
        {
            this.comments = new HashSet<Comment>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(RealEstateConstants.TitleMinLength)]
        [MaxLength(RealEstateConstants.TitleMaxLength)]
        public string Title { get; set; }

        [Required]
        [MinLength(RealEstateConstants.DescriptionMinLength)]
        [MaxLength(RealEstateConstants.DescriptionMaxLength)]
        public string Description { get; set; }

        public RealEstateType RealEstateType { get; set; }
        
        [Range(RealEstateConstants.ConstructionYearMinValue, RealEstateConstants.ConstructionYearMaxValue)]
        public int? ConstructionYear { get; set; }

        public string Address { get; set; }

        public bool CanBeSold { get; set; }

        public bool CanBeRented { get; set; }

        [Required]
        public string Contact { get; set; }

        public DateTime DateCreated { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }

        public int? SellingPrice { get; set; }

        public int? RentingPrice { get; set; }

        public virtual ICollection<Comment> Comments
        {
            get
            {
                return this.comments;
            }
            set
            {
                this.comments = value;
            }
        }

    }
}
