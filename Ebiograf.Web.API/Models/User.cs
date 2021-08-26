using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EBiograf.Web.Api.Models
{
    public class User
    {
        // User ID is the Primary Key 
        [Key] // DataAnnotations used to declare that it is a primary key.
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Creating a Auto incremented ID - sql example(Identity(1,1))
        [Column(TypeName = "int")]
        [Required]
        public int UserID { get; set; }

        [Column(TypeName = "nvarchar(64)")]
        [Required]
        public string UserName { get; set; }

        [Column(TypeName = "nvarchar(76)")]
        [Required]
        public string Password { get; set; } // Password will be Bcrypted and stored in the database.

        [Column(TypeName = "nvarchar(64)")]
        [Required]
        public string FirstName { get; set; }

        [Column(TypeName = "nvarchar(64)")]
        [Required]
        public string LastName { get; set; }

        [Column(TypeName = "nvarchar(64)")]
        [Required]
        public string EmailAddress { get; set; }

        [Column(TypeName = "datetime")]
        [Required]
        public DateTime DateCreated { get; set; }

        [Column(TypeName = "nvarchar(16)")]
        [Required]
        public string Phone { get; set; }

    }
}
