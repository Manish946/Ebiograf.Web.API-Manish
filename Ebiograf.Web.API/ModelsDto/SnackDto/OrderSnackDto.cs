using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ebiograf.Web.API.ModelsDto.SnackDto
{
    public class OrderSnackDto
    {

        public int Quantity { get; set; }
        //Navigartion Properties

        public int BookingID { get; set; }
        public int ProductID { get; set; }
    }
}
