using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model
{
    public class Location
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter the name of the location!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter the address of the location!")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Please enter the id of the owner of this location!")]
        public int UserId { get; set; }
    }
}
