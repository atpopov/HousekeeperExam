using Data.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class TaskBusiness
    {
        private TaskContext context;

        //Makes a list that contains all of the Tasks in the Database
        public List<Data.Model.Task> GetAll()
        {
            using (context = new TaskContext())
            {
                return context.Tasks.ToList();
            }
        }
    }
}
