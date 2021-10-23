using System;

namespace RVEzy.Models
{
    public class Review
    {
        public int Id { get; set; }
        public int ListingId { get; set; }
        public Listing Listing { get; set; }
        public DateTime Date { get; set; }
        public int ReviewerId { get; set; }
        public string ReviewerName { get; set; }
        public string Comments { get; set; }
    }
}
