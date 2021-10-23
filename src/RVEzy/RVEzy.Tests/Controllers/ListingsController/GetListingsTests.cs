using System;
using System.Linq;
using AutoFixture;
using AutoFixture.AutoMoq;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using RVEzy.Controllers;
using RVEzy.DAL;
using RVEzy.Models;

namespace RVEzy.Tests.Controllers.ListingsController
{
    [TestFixture]
    public partial class ListingsControllerTests
    {
        public class GetListings
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

            [TestCase(1, 1, 1)]
            [TestCase(3, 2, 0)]
            [TestCase(2, 2, 1)]
            [TestCase(2, 1, 2)]
            [TestCase(4, 1, 3)]
            public void PageInfoNoTypeFilter_ReturnsListings(int pageSize, int pageNumber,
                int expectedCount)
            {
                var listingsApp = Fixture
                    .Build<RVEzy.Controllers.ListingsController>()
                    .OmitAutoProperties()
                    .Create();

                var result = listingsApp.Get(pageSize, pageNumber).Result;


                Assert.AreEqual(expectedCount, result.Count());
            }

            [TestCase(PropertyType.House, 1)]
            [TestCase(PropertyType.Apartment, 2)]
            public void PropertyTypeFilter_ReturnsListings(PropertyType propertyType, int expectedCount)
            {
                var listingsApp = Fixture
                    .Build<RVEzy.Controllers.ListingsController>()
                    .OmitAutoProperties()
                    .Create();

                var result = listingsApp.Get(3, 1, propertyType).Result;


                Assert.AreEqual(expectedCount, result.Count());
            }

            [Test]
            public void ExistingId_ReturnsMatchingListing()
            {
                var listingsApp = Fixture
                    .Build<RVEzy.Controllers.ListingsController>()
                    .OmitAutoProperties()
                    .Create();

                var result = listingsApp.Get(2).Result;

                Assert.AreEqual(2, result.Id);
            }

            [Test]
            public void NonExistingId_ReturnsNull()
            {
                var listingsApp = Fixture
                    .Build<RVEzy.Controllers.ListingsController>()
                    .OmitAutoProperties()
                    .Create();

                var result = listingsApp.Get(0).Result;

                Assert.IsNull(result);
            }
        }
    }
}