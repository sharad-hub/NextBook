using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NextBook.Models
{
    public class Photo
    {
        public long Id { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public DateTime DateAdded { get; set; }
        public bool IsDefault { get; set; }

        [ForeignKey("User")]
        public long UserId { get; set; }

        public virtual User User { get; set; }
    }
}