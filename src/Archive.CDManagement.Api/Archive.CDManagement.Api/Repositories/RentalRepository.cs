using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Archive.CDManagement.Api.DbContexts;
using Archive.CDManagement.Api.Models;
using Archive.CDManagement.Api.Repositories.Abstractions;
using Microsoft.AspNetCore.Builder;

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
            var cd = _dbContext.CDs.First(cd => cd.Id == rentalItem.CDId);
            if(cd.OnLoan)
            {
                throw new Exception("CD is already on loan");
            }

            cd.OnLoan = true;

            var rental = _dbContext.Rentals.First(rental => rental.Id == rentalItem.RentalId);
                if(rental.RentalItems is null)
            {
                rental.RentalItems = new List<RentalItemModel>();
            }

            rental.RentalItems.Add(rentalItem);
            _dbContext.SaveChanges();
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

        public IEnumerable<RentalModel> GetAllRentals()
        {
            return _dbContext.Rentals.AsEnumerable();
        }

        public RentalModel GetRental(int id)
        {
            return _dbContext.Rentals.Single(rental => rental.Id == id);
        }

        public void RemoveRentalItem(int rentalId, int rentalItemId)
        {
            var rental = _dbContext.Rentals.First(rental => rental.Id == rentalId);
            var rentalItem = rental.RentalItems.First(rentalItem => rentalItem.Id == rentalItemId);
            var cd = _dbContext.CDs.First(cd => cd.Id == rentalItem.CDId);
            cd.OnLoan = false;
            rental.RentalItems.Remove(rentalItem);
            _dbContext.SaveChanges();
        }  

        public void UpdateRental(RentalModel rental)
        {
            _dbContext.Update(rental);
            _dbContext.SaveChanges();

        }
    }
}