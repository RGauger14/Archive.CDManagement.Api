using System;
using System.Collections.Generic;
using System.Linq;
using Archive.CDManagement.Api.DbContexts;
using Archive.CDManagement.Api.Models;
using Microsoft.Extensions.DependencyInjection;

namespace Archive.CDManagement.Seeder
{
    internal class StaffSeeder
    {
        internal static void Seed(ServiceProvider serviceProvider, bool dropExistingData)
        {
            var dbContext = serviceProvider.GetRequiredService<CdManagementContext>();

            if (dropExistingData)
            {
                dbContext.Staff.RemoveRange(dbContext.Staff);
                dbContext.SaveChanges();
            }

            var isAnyStaff = dbContext.Staff.Any();

            if (isAnyStaff)
            {
                throw new Exception("Cannot seed data since Staff already exist");
            }

            var staffToSeed = GetStaffToSeed();
            dbContext.Staff.AddRange(staffToSeed);
            dbContext.SaveChanges();
        }

        private static IEnumerable<StaffModel> GetStaffToSeed()
        {
            int numberOfSeeds = 10;
            List<StaffModel> staff = new List<StaffModel>();
            for (int i = 1; i < numberOfSeeds + 1; i++)
            {
                var phoneSuffix = i >= 10 ? $"{i}" : $"0{i}";
                staff.Add(new StaffModel
                {
                    FirstName = $"First Name {i}",
                    LastName = $"Last Name {i}",
                    Address = $"Address {i}",
                    Email = $"Staff{i}@staff.com",
                    MobileNumber = $"00000000000{phoneSuffix}",
                    Active = true
                });
            }
            return staff;
        }
    }
}