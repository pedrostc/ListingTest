using System;
using System.Linq;
using AutoFixture;
using AutoFixture.AutoMoq;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using RVEzy.DAL;
using RVEzy.Models;

namespace RVEzy.Tests.Controllers.ListingsController
{
    [TestFixture]
    public partial class ListingsControllerTests
    {
        public class PostListingTests
        {
            public Fixture Fixture { get; private set; }
            protected ListingRepository _repository;

            [SetUp]
            public void Setup()
            {
                Fixture = new Fixture();
                Fixture.Customize(new AutoMoqCustomization());
                var options = new DbContextOptionsBuilder<ListingRepository>()
                    .UseInMemoryDatabase(Guid.NewGuid().ToString())
                    .Options;
                _repository = new ListingRepository(options);
                _repository.Database.EnsureCreated();

                Fixture.Register<IListingRepository>(() => _repository);
            }

            [Test]
            public void EmptyListing_Throws()
            {
                var listingsApp = Fixture
                    .Build<RVEzy.Controllers.ListingsController>()
                    .OmitAutoProperties()
                    .Create();

                
                Assert.ThrowsAsync<ArgumentNullException>(() => listingsApp.Create(null));
            }

            // Stopped on this step.
            // From here I'm going to implement the necessary logic to save a new listing on the context and tie that to the controller
            [Test]
            public void ValidNewListing_ReturnsSavedEntityOnDbWithPopulatedId()
            {
                var listingsApp = Fixture
                    .Build<RVEzy.Controllers.ListingsController>()
                    .OmitAutoProperties()
                    .Create();

                var newListing = new Listing
                {
                    Description = "A new place to visit",
                    ListingUrl = "http://site.com/myListing",
                    Name = "amazing place",
                    PropertyType = PropertyType.House
                };

                var result = listingsApp.Create(newListing).Result;
                
                Assert.IsNotNull(result);
                Assert.AreNotEqual(0, result.Id);
            }
        }
    }
}
