using Ebiograf.Web.API.Models.Show;
using Ebiograf.Web.API.Models.Snacks;
using EBiograf.Web.Api.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ebiograf.Web.API.Models.Bookings
{
    public class Booking
    {
        // User ID is the Primary Key 
        [Key] // DataAnnotations used to declare that it is a primary key.
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Creating a Auto incremented ID - sql example(Identity(1,1))
        [Column(TypeName = "int")]
        [Required]
        public int BookingID { get; set; }

        [Column(TypeName = "int")]
        [Required]
        public int NumberOfSeats { get; set; }

        [Column(TypeName = "datetime")]
        [Required]
        public DateTime TimeStamp { get; set; }

        [Column(TypeName = "int")]
        [Required]
        public int Status { get; set; } // Enum

        // Nagvigation Property for Genre
        
        public int UserID { get; set; }
        public User User { get; set; }
        
        public ICollection<ShowSeat> ShowSeats { get; set; }
        public ICollection<Snack> Snacks { get; set; }

        public virtual Payment Payment { get; set; }
    }
}
