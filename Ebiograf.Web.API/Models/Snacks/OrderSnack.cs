using Ebiograf.Web.API.Models.Bookings;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ebiograf.Web.API.Models.Snacks
{
    public class OrderSnack
    {
        [Key] // DataAnnotations used to declare that it is a primary key.
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Creating a Auto incremented ID - sql example(Identity(1,1))
        [Column(TypeName = "int")]
        [Required]
        public int SnackID { get; set; }

        [Column(TypeName = "int")]
        [Required]
        public int Quantity { get; set; }
        //Navigartion Properties

        public int BookingID { get; set; }
        public Booking Booking { get; set; } 
        public int ProductID { get; set; }
        public Product Product { get; set; }
    }
}
