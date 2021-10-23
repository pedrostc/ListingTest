﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RVEzy.Models;

namespace RVEzy.DAL.EntityConfiguration
{
    public class ListingEntityConfiguration : IEntityTypeConfiguration<Listing>
    {
        public void Configure(EntityTypeBuilder<Listing> builder)
        {
            builder.HasKey(l => l.Id);

            builder.HasData(new List<Listing>
            {
                new Listing
                {
                    Id = 1,
                    ListingUrl =
                        "https://www.airbnb.com/rooms/241032,20160104002432,2016-01-04,Stylish Queen Anne Apartment",
                    Name = "Queen Anne Apartment",
                    Description = "Enjoy Queen Anne Living",
                    PropertyType = PropertyType.Apartment
                },
                new Listing
                {
                    Id = 2,
                    ListingUrl =
                        "https://www.airbnb.com/rooms/278830,20160104002432,2016-01-04,Charming craftsman 3 bdm house",
                    Name = "Queen Anne Apartment",
                    Description = "Charming craftsman",
                    PropertyType = PropertyType.Apartment
                },
                new Listing
                {
                    Id = 3,
                    ListingUrl =
                        "https://www.airbnb.com/rooms/1909058,20160104002432,2016-01-04,Queen Anne Private Bed and Bath",
                    Name = "Queen Anne Private",
                    Description = "RVezy is awesome!",
                    PropertyType = PropertyType.House
                }
            });
        }
    }
}