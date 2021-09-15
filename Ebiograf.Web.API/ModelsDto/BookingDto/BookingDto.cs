using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ebiograf.Web.API.ModelsDto.BookingDto
{
    public class BookingDto
    {
        public int NumberOfSeats { get; set; }

        public DateTime TimeStamp { get; set; }

        public int Status { get; set; } // Enum

        // Nagvigation Property for Genre

        public int UserID { get; set; }
        public int ShowID { get; set; }
       

    }
}
