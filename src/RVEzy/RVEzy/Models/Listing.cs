using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RVEzy.Models
{
    public class Listing
    {
        public int Id { get; set; }
        public string ListingUrl { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public PropertyType PropertyType { get; set; }
    }

    public enum PropertyType
    {
        Apartment,
        House
    }
}
