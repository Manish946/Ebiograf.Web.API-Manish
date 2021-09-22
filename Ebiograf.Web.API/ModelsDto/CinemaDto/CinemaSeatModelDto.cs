using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ebiograf.Web.API.ModelsDto.CinemaDto
{
    public class CinemaSeatModelDto
    {


        public int SeatNumber { get; set; }

        public int type { get; set; } //ENUM

        // Navigation Property
        public int CinemaHallID { get; set; }
    }
}
