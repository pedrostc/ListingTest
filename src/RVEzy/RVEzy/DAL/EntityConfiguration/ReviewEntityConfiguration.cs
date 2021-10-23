using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RVEzy.Models;

namespace RVEzy.DAL.EntityConfiguration
{
    public class ReviewEntityConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.HasKey(l => l.Id);

            //TODO: move seed data somewhere else
            builder.HasData(new List<Review>
            {
                new Review
                {
                    Id = 38917982,
                    ListingId = 1,
                    Date = new DateTime(2015, 07, 19),
                    ReviewerId = 28943674,
                    ReviewerName = "Bianca",
                    Comments = "Cute and cozy place."
                },
                new Review
                {
                    Id = 38917981,
                    ListingId = 2,
                    Date = new DateTime(2015, 07, 19),
                    ReviewerId = 28943675,
                    ReviewerName = "Bianca",
                    Comments = "Perfect location to everything!"
                }
            });
        }
    }
}
