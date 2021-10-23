using System;
using System.Linq;
using AutoFixture;
using AutoFixture.AutoMoq;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using RVEzy.Controllers;
using RVEzy.DAL;

namespace RVEzy.Tests.Controllers
{
    public class ListingsControllerTests
    {
        public Fixture Fixture { get; private set; }
        private ListingRepository _repository;

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

        [TestCase(1, 1, 1)]
        [TestCase(3, 2, 0)]
        [TestCase(2, 2, 1)]
        [TestCase(2, 1, 2)]
        [TestCase(4, 1, 3)]
        public void GetListings_ReturnsListings(int pageSize, int pageNumber, int expectedCount)
        {
            var listingsApp = Fixture
                .Build<ListingsController>()
                .OmitAutoProperties()
                .Create();

            var result = listingsApp.Get(pageSize, pageNumber).Result;

            
            Assert.AreEqual(expectedCount, result.Count());
        }

        [Test]
        public void GetListing_ExistingId_ReturnsMatchingListing()
        {
            var listingsApp = Fixture
                .Build<ListingsController>()
                .OmitAutoProperties()
                .Create();

            var result = listingsApp.Get(2).Result;

            Assert.AreEqual(2, result.Id);
        }

        [Test]
        public void GetListing_NonExistingId_ReturnsNull()
        {
            var listingsApp = Fixture
                .Build<ListingsController>()
                .OmitAutoProperties()
                .Create();

            var result = listingsApp.Get(0).Result;

            Assert.IsNull(result);
        }
    }
}