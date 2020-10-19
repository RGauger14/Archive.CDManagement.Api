using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
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

        public string GetCdCountCsvReport()
        {
            var cdsRentalCount = AllCDCount();
            return GenerateCsvCdCountData(cdsRentalCount);
        }

        private static string GenerateCsvCdCountData(IEnumerable<CDRentedModel> cdsRentalCount)
        {
            var builder = new StringBuilder();
            builder.AppendLine("CD ID, CD Title, Times Rented");
            foreach (var cdRentalCount in cdsRentalCount)
            {
                var line = string.Join(
                    ',',
                    cdRentalCount.CD.Id,
                    cdRentalCount.CD.Title,
                    cdRentalCount.RentedCount);

                builder.AppendLine(line);
            }

            return builder.ToString();
        }

        public string GetRentalCsvReport(int staffId, int cdId)
        {
            var rentals = GetRentalsByStaffIdAndCdId(staffId, cdId);
            return GenerateCsvRentalData(rentals);
        }

        private static string GenerateCsvRentalData(IEnumerable<RentalModel> rentals)
        {
            var builder = new StringBuilder();
            builder.AppendLine("Date Rented, Staff Member, CDs Rented");
            foreach (var rental in rentals)
            {
                var line = string.Join(
                    ',',
                    rental.DateRented,
                    $"{rental.Staff.FirstName} {rental.Staff.LastName}",
                    string.Join(';', rental.RentalItems.Select(rentalItem => rentalItem.CD.Title)));

                builder.AppendLine(line);
            }

            return builder.ToString();
        }

        private IEnumerable<RentalModel> GetRentalsByStaffIdAndCdId(int staffId, int cdId)
        {
            return _dbContext.Rentals
                .Include(rental => rental.RentalItems)
                .ThenInclude(rentalItem => rentalItem.CD)
                .Include(rental => rental.Staff)
                .AsEnumerable().Where(rental =>
                {
                    var hasNotSpecifiedFilters = staffId == 0 && cdId == 0;
                    if (hasNotSpecifiedFilters)
                    {
                        return true;
                    }

                    var hasMatchingStaff = rental.StaffId == staffId || staffId == 0;
                    var hasMatchingCd = rental.RentalItems.Any(rentalItem => rentalItem.CDId == cdId) || cdId == 0;

                    return hasMatchingStaff && hasMatchingCd;
                });
        }
    }
}
