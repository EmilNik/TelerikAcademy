namespace YouTubePlaylistsSystem.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Playlist
    {
        private ICollection<Rate> rates;
        private ICollection<Video> videos;

        public Playlist()
        {
            this.rates = new HashSet<Rate>();
            this.videos = new HashSet<Video>();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime DateCreated { get; set; }

        [Required]
        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }

        public virtual ICollection<Video> Videos { get { return this.videos; } set { this.videos = value; } }

        public virtual ICollection<Rate> Rates { get { return this.rates; } set { this.rates = value; } }
    }
}