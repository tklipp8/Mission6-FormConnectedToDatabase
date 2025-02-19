using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission6.Models
{
    public class Movie
    {
        //Properties of the form with get and set included for each
        [Key]
        [Required]
        public int MovieId { get; set; }
        [ForeignKey("CategoryId")]
        public int? CategoryId { get; set; } 
        public Category Category { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        [Range(1888,2100)]
        public string Year { get; set; }
        public string? Director { get; set; }
        public string? Rating { get; set; }
        [Required]
        public int Edited { get; set; }
        public string? LentTo { get; set; }
        [Required]
        public int CopiedToPlex { get; set; }
        public string? Notes { get; set; }
    }
}
