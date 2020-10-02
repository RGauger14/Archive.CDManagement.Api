using System;
using System.Collections.Generic;
using System.Linq;
using Archive.CDManagement.Api.DbContexts;
using Archive.CDManagement.Api.Models;
using Microsoft.Extensions.DependencyInjection;

namespace Archive.CDManagement.Seeder
{
    internal class RentalsSeeder
    {
        internal static void Seed(ServiceProvider serviceProvider, bool dropExistingData)
        {
            var dbContext = serviceProvider.GetRequiredService<CdManagementContext>();

            if (dropExistingData)
            {
                dbContext.Rentals.RemoveRange(dbContext.Rentals);
                dbContext.SaveChanges();
            }

            var isAnyRentals = dbContext.Rentals.Any();

            if (isAnyRentals)
            {
                throw new Exception("Cannot seed data since Rentals already exist");
            }

            var rentalsToSeed = GetRentalsToSeed(dbContext);
            dbContext.Rentals.AddRange(rentalsToSeed);
            dbContext.SaveChanges();
        }

        private static IEnumerable<RentalModel> GetRentalsToSeed(CdManagementContext dbContext)
        {
            int numberOfSeeds = 10;
            List<RentalModel> rentals = new List<RentalModel>();
            for (int i = 1; i < numberOfSeeds + 1; i++)
            {
                var rental = CreateRental(i, dbContext);
                rentals.Add(rental);
            }
            return rentals;
        }

        private static RentalModel CreateRental(int i, CdManagementContext dbContext)
        {
            var rental = new RentalModel();
            var staff = dbContext.Staff.Single(staff => staff.FirstName == $"First Name {i}");
            var cdToRent = dbContext.CDs.Single(cd => cd.Title == $"CD Title {i}");
            var rentalItem = new RentalItemModel
            {
                CD = cdToRent,
                Rental = rental
            };
            rental.DateRented = DateTime.Now;
            rental.Staff = staff;
            rental.RentalItems = new List<RentalItemModel>() { rentalItem };
            cdToRent.OnLoan = true;
            return rental;
        }
    }
}