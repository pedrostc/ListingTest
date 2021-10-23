using System.Collections.Generic;
using System.Threading.Tasks;
using RVEzy.Models;

namespace RVEzy.DAL
{
    public interface IListingRepository
    {
        public Task<ICollection<Listing>> GetListings(int pageSize, int pageNumber);

        public Task<Listing> GetListing(int listingId);
    }
}
