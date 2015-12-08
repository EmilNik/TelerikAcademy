namespace RealEstate.Data.Models
{
    using Common.Constants;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Comment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(CommentConstants.CommentMinLength)]
        [MaxLength(CommentConstants.CommentMaxLength)]
        public string Content { get; set; }

        public DateTime DateCreated { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }

        public int? RealEstateId { get; set; }

        public virtual RealEstate RealEstate { get; set; }
    }
}
