﻿using System.ComponentModel.DataAnnotations;

namespace TicketSystem.Models
{
    public class Image
    {
        [Key]
        public int Id { get; set; }

        public byte[] Content { get; set; }
        
        public string FileExtension { get; set; }
    }
}