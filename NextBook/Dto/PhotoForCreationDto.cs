using System;

namespace NextBook.Dto
{
    public class PhotoForCreationDto
    {
        public long Id { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public DateTime DateAdded { get; set; }
        public bool IsDefault { get; set; }
    }
}