using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace Ebiograf.Web.API.Models.Movie
{
    public class Genre
    {
        // User ID is the Primary Key 
        [Key] // DataAnnotations used to declare that it is a primary key.
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Creating a Auto incremented ID - sql example(Identity(1,1))
        [Column(TypeName = "int")]
        [Required]
        public int GenreID { get; set; }

        [Column(TypeName = "nvarchar(512)")]
        [Required]
        public string GenreName { get; set; }

        public ICollection<Movie> Movie { get; set; }
    }
}
