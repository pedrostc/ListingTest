using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RVEzy.Models;

namespace RVEzy.DAL.EntityConfiguration
{
    public class CalendarEntityConfiguration : IEntityTypeConfiguration<Calendar>
    {
        public void Configure(EntityTypeBuilder<Calendar> builder)
        {
            builder.HasKey(c => new {c.ListingId, c.Date});

            //TODO: move seed data somewhere else
            builder.HasData(new List<Calendar>
            {
                new Calendar
                {
                    ListingId = 1,
                    Date = DateTime.Parse("2016-02-14"),
                    Available = true,
                    Price = 85.00M
                },
                new Calendar
                {
                    ListingId = 1,
                    Date = DateTime.Parse("2016-02-15"),
                    Available = true,
                    Price = 65.00M

                },
                new Calendar
                {
                    ListingId = 1,
                    Date = DateTime.Parse("2016-02-16"),
                    Available = true,
                    Price = 75.00M
                },
                new Calendar
                {
                    ListingId = 1,
                    Date = DateTime.Parse("2016-02-17"),
                    Available = true,
                    Price = 85.00M
                },
                new Calendar
                {
                    ListingId = 1,
                    Date = DateTime.Parse("2016-02-18"),
                    Available = true,
                    Price = 85.00M
                },
                new Calendar
                {
                    ListingId = 1,
                    Date = DateTime.Parse("2016-02-19"),
                    Available = true,
                    Price = 85.00M
                },
                new Calendar
                {
                    ListingId = 1,
                    Date = DateTime.Parse("2016-02-20"),
                    Available = true,
                    Price = 85.00M
                },
                new Calendar
                {
                    ListingId = 1,
                    Date = DateTime.Parse("2016-02-21"),
                    Available = true,
                    Price = 85.00M
                },
                new Calendar
                {
                    ListingId = 1,
                    Date = DateTime.Parse("2016-02-22"),
                    Available = false,
                    Price = 85.00M
                },
                new Calendar
                {
                    ListingId = 1,
                    Date = DateTime.Parse("2016-02-23"),
                    Available = false,
                    Price = 85.00M
                },
                new Calendar
                {
                    ListingId = 1,
                    Date = DateTime.Parse("2016-02-24"),
                    Available = false,
                    Price = 85.00M
                },
                // loc 2
                new Calendar
                {
                    ListingId = 2,
                    Date = DateTime.Parse("2016-02-14"),
                    Available = true,
                    Price = 85.00M
                },
                new Calendar
                {
                    ListingId = 2,
                    Date = DateTime.Parse("2016-02-15"),
                    Available = true,
                    Price = 65.00M

                },
                new Calendar
                {
                    ListingId = 2,
                    Date = DateTime.Parse("2016-02-16"),
                    Available = true,
                    Price = 75.00M
                },
                new Calendar
                {
                    ListingId = 2,
                    Date = DateTime.Parse("2016-02-17"),
                    Available = true,
                    Price = 85.00M
                },
                new Calendar
                {
                    ListingId = 2,
                    Date = DateTime.Parse("2016-02-18"),
                    Available = true,
                    Price = 85.00M
                },
                new Calendar
                {
                    ListingId = 2,
                    Date = DateTime.Parse("2016-02-19"),
                    Available = true,
                    Price = 85.00M
                },
                new Calendar
                {
                    ListingId = 2,
                    Date = DateTime.Parse("2016-02-20"),
                    Available = true,
                    Price = 85.00M
                },
                new Calendar
                {
                    ListingId = 2,
                    Date = DateTime.Parse("2016-02-21"),
                    Available = true,
                    Price = 85.00M
                },
                new Calendar
                {
                    ListingId = 2,
                    Date = DateTime.Parse("2016-02-22"),
                    Available = false,
                    Price = 85.00M
                },
                new Calendar
                {
                    ListingId = 2,
                    Date = DateTime.Parse("2016-02-23"),
                    Available = false,
                    Price = 85.00M
                },
                new Calendar
                {
                    ListingId = 2,
                    Date = DateTime.Parse("2016-02-24"),
                    Available = false,
                    Price = 85.00M
                },
            });
        }
    }
}
