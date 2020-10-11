using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Archive.CDManagement.Api.DbContexts;
using Archive.CDManagement.Api.Models;
using Archive.CDManagement.Api.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Archive.CDManagement.Api.Repositories
{
    public class ReportRepository : IReportRepository
    {
        private readonly CdManagementContext _dbContext;

        public ReportRepository(CdManagementContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<CDRentedModel> AllCDCount()
        {
            var cdsByRentalItems = _dbContext.Rentals
                .SelectMany(rental => rental.RentalItems)
                .ToList()
                .GroupBy(rentalItem => rentalItem.CDId);

            List<CDRentedModel> cdRentals = new List<CDRentedModel>();

            foreach (var cdByRentalItem in cdsByRentalItems)
            {
                var cd = _dbContext.CDs.Single(cd => cd.Id == cdByRentalItem.Key);
                cdRentals.Add(new CDRentedModel
                {
                    CD = cd,
                    RentedCount = cdByRentalItem.Count()
                });
            }

            return cdRentals;
                
        }

        public CDRentedModel SingleCDCount(int id)
        {
            var rentedCount = _dbContext.Rentals
                .SelectMany(rental => rental.RentalItems)
                .Where(rentalItem => rentalItem.CDId == id)
                .Count();

            var cd = _dbContext.CDs.Single(cd => cd.Id == id);

            var cdRented = new CDRentedModel
            {
                CD = cd,
                RentedCount = rentedCount
            };

            return cdRented;
        }
    }
}
