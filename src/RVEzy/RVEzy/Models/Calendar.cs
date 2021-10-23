using System;

namespace RVEzy.Models
{
    public class Calendar
    {
        public int ListingId { get; set; }
        public Listing Listing { get; set; }
        public DateTime Date { get; set; }
        public bool Available { get; set; }
        public decimal Price { get; set; }
    }
}
