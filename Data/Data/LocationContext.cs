using Data.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Data
{
    public class LocationContext : DbContext
    {
        public LocationContext()
           : base("name = LocationContext")
        {

        }

        public DbSet<Location> Locations { get; set; }
    }
}
