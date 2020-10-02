using System;
using System.Collections.Generic;
using System.Linq;
using Archive.CDManagement.Api.DbContexts;
using Archive.CDManagement.Api.Models;
using Archive.CDManagement.Api.Repositories.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Archive.CDManagement.Seeder
{
    internal class CDSeeder
    {
        internal static void Seed(ServiceProvider serviceProvider, bool dropExistingData)
        {
            var dbContext = serviceProvider.GetRequiredService<CdManagementContext>();

            if (dropExistingData)
            {
                dbContext.CDs.RemoveRange(dbContext.CDs);
                dbContext.SaveChanges();
            }

            var isAnyCDs = dbContext.CDs.Any();

            if (isAnyCDs)
            {
                throw new Exception("Cannot seed data since CDs already exist");
            }

            var cdsToSeed = GetCdsToSeed();
            dbContext.CDs.AddRange(cdsToSeed);
            dbContext.SaveChanges();
        }

        private static IEnumerable<CDModel> GetCdsToSeed()
        {
            int numberOfSeeds = 10;
            List<CDModel> cds = new List<CDModel>();
            for (int i = 1; i < numberOfSeeds + 1; i++)
            {
                var barcodeSuffix = i >= 10 ? $"{i}" : $"0{i}";
                cds.Add(new CDModel
                {
                    Title = $"CD Title {i}",
                    Author = $"CD Author {i}",
                    Section = $"Section {i}",
                    X = i,
                    Y = i + 1,
                    Barcode = $"00000000000{barcodeSuffix}",
                    Description = $"Description {i}",
                    OnLoan = false
                });
            }
            return cds;
        }
    }
}