using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Archive.CDManagement.Api.DbContexts;
using Archive.CDManagement.Api.Models;
using Archive.CDManagement.Api.Repositories.Abstractions;

namespace Archive.CDManagement.Api.Repositories
{
    public class CDRepository : ICDRepository
    {
        private readonly CdManagementContext _dbContext;

        public CDRepository(CdManagementContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void CreateCD(CDModel cd)
        {
            _dbContext.CDs.Add(cd);
            _dbContext.SaveChanges();
        }

        public void DeleteCD(int id)
        {
            var cdToDelete = _dbContext.CDs.First(cd => cd.Id == id);
            _dbContext.CDs.Remove(cdToDelete);
            _dbContext.SaveChanges();
        }

        public CDModel GetCD(int id)
        {
            return _dbContext.CDs.Single(cd => cd.Id == id);
        }

        public IEnumerable<CDModel> GetAllCds()
        {
            return _dbContext.CDs.AsEnumerable();
        }

        public void UpdateCD(CDModel cd)
        {
            _dbContext.Update(cd);
            _dbContext.SaveChanges();
        }

        public void CreateCDs(IEnumerable<CDModel> cds)
        {
            _dbContext.CDs.AddRange(cds);
            _dbContext.SaveChanges();
        }
    }
}