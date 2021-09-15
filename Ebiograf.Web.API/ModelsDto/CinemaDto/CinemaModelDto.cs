using Ebiograf.Web.API.Models.Cinema;
using Ebiograf.Web.API.ModelsDto.CinemaAddressDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Ebiograf.Web.API.ModelsDto.CinemaDto
{
    public class CinemaModelDto
    {
        [JsonIgnore]
        public int CinemaID { get; set; }
        public string Name { get; set; }
        public int TotalCinemaHalls { get; set; }
        public AddressDto CinemaAddress { get; set; }

    }
}
