using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace RazorPagesMovie.Models
{
    public class Movie
    {
        public int ID { get; set; }

        //The Required and MinimumLength attributes indicate
        //that a property must have a value;
        //but nothing prevents a user from entering white space to satisfy this validation.
        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Title { get; set; }

        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        //The RegularExpression attribute is used to limit
        //what characters can be input. In the preceding code, "Genre"
        //RGX here means
        //1)Must only use letters.
        //2)The first letter is required to be uppercase.
        //  White space, numbers, and special characters are not allowed.
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        [Required]
        [StringLength(30)]
        public string Genre { get; set; }

        //The Range attribute constrains a value to within a specified range.
        [Range(1, 100)]
        //Value types (such as decimal, int, float, DateTime) are inherently required
        //and don't need the [Required] attribute.
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }

        //Regex here means
        //1)Requires that the first character be an uppercase letter.
        //2)Allows special characters and numbers in subsequent spaces.
        //  "PG-13" is valid for a rating, but fails for a "Genre".
        [RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$")]
        [StringLength(5)]
        [Required]
        public string Rating { get; set; }
    }
}