using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Archive.CDManagement.Api.Models;

namespace Archive.CDManagement.Api.Repositories.Abstractions
{
    public interface IRentalRepository
    {
        void CreateRental(RentalModel rental);

        void UpdateRental(RentalModel rental);

        void DeleteRental(int id);

        void AddRentalItem(RentalItemModel rentalItem);

        void RemoveRentalItem(int rentalId, int rentalItemId);

        RentalModel GetRental(int id);

        IEnumerable<RentalModel> GetAllRentals();

    }
}