using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ebiograf.Web.API.Models.Cinema
{
    public class CinemaSeat
    {
        [Key] // DataAnnotations used to declare that it is a primary key.
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Creating a Auto incremented ID - sql example(Identity(1,1))
        [Column(TypeName = "int")]
        [Required]
        public int CinemaSeatID { get; set; }


        [Column(TypeName = "int")]
        [Required]
        public int SeatNumber { get; set; }

        [Column(TypeName = "int")]
        [Required]
        public int type { get; set; } //ENUM

        // Navigation Property
        public int CinemaHallID { get; set; }
        public CinemaHall CinemaHall { get; set; }
    }
}
