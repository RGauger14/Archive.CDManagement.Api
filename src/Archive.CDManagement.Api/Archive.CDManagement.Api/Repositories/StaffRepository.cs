using System.Collections.Generic;
using System.Linq;
using Archive.CDManagement.Api.DbContexts;
using Archive.CDManagement.Api.Models;
using Archive.CDManagement.Api.Repositories.Abstractions;

namespace Archive.CDManagement.Api.Repositories
{
    public class StaffRepository : IStaffRepository
    {
        private readonly CdManagementContext _dbContext;

        public StaffRepository(CdManagementContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void CreateStaff(StaffModel staff)
        {
            _dbContext.Staff.Add(staff);
            _dbContext.SaveChanges();
        }

        public void DeleteStaff(int id)
        {
            var staffToDelete = _dbContext.Staff.First(staff => staff.Id == id);
            _dbContext.Staff.Remove(staffToDelete);
            _dbContext.SaveChanges();
        }

        public IEnumerable<StaffModel> GetAllStaff()
        {
            return _dbContext.Staff.AsEnumerable();
        }

        public StaffModel GetStaff(int id)
        {
            return _dbContext.Staff.Single(staff => staff.Id == id);
        }

        public void UpdateStaff(StaffModel staff)
        {
            _dbContext.Update(staff);
            _dbContext.SaveChanges();
        }
    }
}