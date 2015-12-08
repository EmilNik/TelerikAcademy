namespace RealEstate.Data.Models
{
    using Common.Constants;
    using System.ComponentModel.DataAnnotations;

    public class CreateCommentRequestModel
    {
        [Required]
        [MinLength(CommentConstants.CommentMinLength)]
        [MaxLength(CommentConstants.CommentMaxLength)]
        public string Content { get; set; }

        public int RealEstateId { get; set; }
    }
}