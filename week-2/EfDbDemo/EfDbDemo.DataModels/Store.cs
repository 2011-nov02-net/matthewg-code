using System;
using System.Collections.Generic;

#nullable disable

namespace EfDbDemo.DataModels
{
    public partial class Store
    {
        public Store()
        {
            Locations = new HashSet<Location>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Location> Locations { get; set; }
    }
}
