using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using RVEzy.DAL;
using RVEzy.Models;

namespace RVEzy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListingsController : ControllerBase
    {
        private readonly IListingRepository _listingRepository;
        private readonly ILogger<ListingsController> _logger;

        public ListingsController(
            IListingRepository listingRepository,
            ILogger<ListingsController> logger)
        {
            _listingRepository = listingRepository;
            _logger = logger;
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<Listing> Get(int id)
        {
            return await _listingRepository.GetListing(id);
        }


        [HttpGet]
        public async Task<IEnumerable<Listing>> Get(int pageSize = 1, int pageNumber = 1, PropertyType? propertyType = null)
        {
            return await _listingRepository.GetListings(pageSize, pageNumber, propertyType);
        }
    }
}
