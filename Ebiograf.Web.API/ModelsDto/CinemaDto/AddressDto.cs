
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Ebiograf.Web.API.ModelsDto.CinemaAddressDto
{
    public class AddressDto
    {
        [JsonIgnore]
        public int CinemaAdressID { get; set; }

        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string ZipCode { get; set; }

        public string City { get; set; }

        public string Country { get; set; }
    }
}
