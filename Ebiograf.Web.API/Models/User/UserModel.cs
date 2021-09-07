using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EBiograf.Web.Api.Models
{
    public class UserModel
    {
        public int UserID { get; set; }

        public string UserName { get; set; }
        [JsonIgnore] // Ignoring password data to be not shown.
        public string Password { get; set; } // Password will be Bcrypted and stored in the database.

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string EmailAddress { get; set; }

        public DateTime DateCreated { get; set; }

        public string Phone { get; set; }
        public string Token { get; set; }

    }
}
