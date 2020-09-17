using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Archive.CDManagement.Api.Models;

namespace Archive.CDManagement.Api.Repositories.Abstractions
{
    public interface IStaffRepository
    {
        StaffModel GetStaff(int id);

        IEnumerable<StaffModel> GetAllStaff();

        void CreateStaff(CDModel cd);

        void UpdateStaff(CDModel cd);

        void DeleteStaff(int id);
    }
}