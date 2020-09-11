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
        private readonly CdDbContext _dbContext;

        public CDRepository(CdDbContext dbContext)
        {
           _dbContext = dbContext;
        }

        public void AddCD(CDModel cd)
        {
            _dbContext.CDs.Add(cd);
            _dbContext.SaveChanges();
        }

        public CDModel GetCDModel(int id)
        {
            return _dbContext.CDs.Single(cd => cd.Id == id);
        }

        public IEnumerable<CDModel> GetCDModelsByTitle(string title)
        {
            throw new NotImplementedException();
        }
    }
}
