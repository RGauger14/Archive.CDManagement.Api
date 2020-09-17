using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Archive.CDManagement.Api.DbContexts;
using Archive.CDManagement.Api.Models;
using Archive.CDManagement.Api.Repositories.Abstractions;

namespace Archive.CDManagement.Api.Repositories
{
    public class RentalRepository : IRentalRepository
    {
        private readonly CdManagementContext _dbContext;

        public RentalRepository(CdManagementContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddRentalItem(RentalItemModel rentalItem)
        {
            throw new NotImplementedException();
        }

        public void CreateRental(RentalModel rental)
        {
            _dbContext.Rentals.Add(rental);
            _dbContext.SaveChanges();
        }

        public void DeleteRental(int id)
        {
            var rentalToDelete = _dbContext.Rentals.First(rental => rental.Id == id);
            _dbContext.Rentals.Remove(rentalToDelete);
            _dbContext.SaveChanges();
        }

        public IEnumerable<RentalModel> GetAllRental()
        {
            return _dbContext.Rentals.AsEnumerable();
        }

        public RentalModel GetRentals(int id)
        {
            return _dbContext.Rentals.Single(rental => rental.Id == id);
        }

        public void RemoveRentalItem(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateRental(RentalModel rental)
        {
            throw new NotImplementedException();
        }
    }
}