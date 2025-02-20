using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieCollection.Models

{
    public class Application
    {
        // Required Primary Key
        [Key]
        [Required]
        public int MovieId { get; set; }

        [ForeignKey("CategoryId")]
        public int? CategoryId { get; set; }  // Foreign Key

        public Category Category { get; set; }  // Navigation propert

        [Required(ErrorMessage ="Sorry, you need to enter a proper movie title.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Sorry, you must enter a year 1888 or later.")]
        [Range(1888, int.MaxValue, ErrorMessage = "Year must be 1888 or later.")]
        public int Year { get; set; }

        public string? Director { get; set; }

        public string? Rating { get; set; }

        [Required(ErrorMessage = "Sorry, you need to select whether or not this movie was edited.")]
        public bool? Edited { get; set; }

        public string? LentTo { get; set; }

        [Required(ErrorMessage = "Sorry, you must indicate whether the movie is already copied to Plex.")]
        public bool CopiedToPlex { get; set; }

        [MaxLength(25)] // Ensures the database column has a max length of 25
        [StringLength(25, ErrorMessage = "Notes cannot exceed 25 characters.")]
        public string? Notes { get; set; }




    }
}
