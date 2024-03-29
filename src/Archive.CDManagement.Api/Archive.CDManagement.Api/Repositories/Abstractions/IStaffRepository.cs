﻿using System.Collections.Generic;
using Archive.CDManagement.Api.Models;

namespace Archive.CDManagement.Api.Repositories.Abstractions
{
    public interface IStaffRepository
    {
        StaffModel GetStaff(int id);

        IEnumerable<StaffModel> GetAllStaff();

        void DeleteStaff(int id);

        void CreateStaff(StaffModel staff);

        void UpdateStaff(StaffModel staff);
    }
}