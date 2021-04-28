using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Data
{
    public class TaskContext : DbContext
    {
        public TaskContext()
           : base("name = TaskContext")
        {

        }

        public DbSet<Model.Task> Tasks { get; set; }
    }
}
