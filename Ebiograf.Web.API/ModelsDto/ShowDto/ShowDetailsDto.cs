using Ebiograf.Web.API.Models.Cinema;
using Ebiograf.Web.API.Models.Movie;
using Ebiograf.Web.API.Models.Show;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ebiograf.Web.API.ModelsDto.ShowDto
{
    public class ShowDetailsDto
    {

        public DateTime Date { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public int MovieID { get; set; }
        public int CinemaHallID { get; set; }

        

    }
}
