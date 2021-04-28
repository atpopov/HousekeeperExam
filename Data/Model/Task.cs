using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model
{
    public class Task
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter the name of the task!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The description cannot be left blank!")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Please choose one of the locations!")]
        public int LocationId { get; set; }
        [Required]
        public int UserId { get; set; }

        [DataType(DataType.DateTime), Required(ErrorMessage = "Please enter the deadline of the task!")]
        public DateTime DeadLine { get; set; }

        [Required(ErrorMessage = "Please enter a budget!")]
        public double Budget { get; set; }

        [Required(ErrorMessage = "Please choose the category of the task!")]
        public string Category { get; set; }

        public string Status { get; set; }

        [DataType(DataType.ImageUrl)]
        public string ImageUrl { get; set; }

        public DateTime DateOfAssignment { get; set; }
    }
}
