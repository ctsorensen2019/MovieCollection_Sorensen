using System.ComponentModel.DataAnnotations;

namespace MovieCollection.Models

{
    public class Application
    {
        // Required Primary Key
        [Key]
        [Required]
        public int FormID { get; set; }

        [Required]
        public string Category { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public string Director { get; set; }

        [Required]
        public string Rating { get; set; }

        public bool? Edited { get; set; }
       
        public string? LentTo { get; set; }

        [MaxLength(25)] // Ensures the database column has a max length of 25
        [StringLength(25, ErrorMessage = "Notes cannot exceed 25 characters.")]
        public string? Notes { get; set; }




    }
}
