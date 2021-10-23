using Microsoft.EntityFrameworkCore;
using RVEzy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RVEzy.DAL.EntityConfiguration;


namespace RVEzy.DAL
{
    public class ListingRepository : DbContext, IListingRepository
    {
        private DbSet<Listing> Listings { get; set; }

        public ListingRepository(DbContextOptions<ListingRepository> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ListingEntityConfiguration).Assembly);
        }

        public async Task<Listing> GetListing(int listingId)
        {
            return await Listings.FirstOrDefaultAsync(l => l.Id == listingId);
        }

        public async Task<ICollection<Listing>> GetListings(int pageSize, int pageNumber, PropertyType? propertyType = null)
        {
            var query = ApplyPagination(Listings, pageSize, pageNumber);
            query = ApplyFilter(query, propertyType);

            return await query
                .ToListAsync();
        }

        private IQueryable<Listing> ApplyFilter(IQueryable<Listing> query, PropertyType? propertyType)
        {
            return !propertyType.HasValue
                ? query
                : query.Where(l => l.PropertyType == propertyType);

        }

        private IQueryable<Listing> ApplyPagination(IQueryable<Listing> query, int pageSize, int pageNumber)
        {
            return Listings
                .Skip(pageSize * (pageNumber - 1))
                .Take(pageSize);
        }
    }
}
