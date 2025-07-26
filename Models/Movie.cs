using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_Identity_Movie.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Director { get; set; } = string.Empty;
        public DateTime ReleaseDate { get; set; }
        public string Genre { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Rating { get; set; }

        public string? FileName { get; set; }
        public byte[]? File { get; set; }

        [NotMapped]
        public IFormFile FileForm { get; set; }

        //    public string PosterUrl { get; set; } = string.Empty;
    }
}
