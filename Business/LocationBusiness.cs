using Data.Data;
using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class LocationBusiness
    {
        private LocationContext context;

        //Makes a list that contains all of the Locations in the Database
        public List<Location> GetAll()
        {
            using (context = new LocationContext())
            {
                return context.Locations.ToList();
            }
        }
    }
}
