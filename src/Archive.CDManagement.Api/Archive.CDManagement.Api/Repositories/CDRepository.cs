using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Archive.CDManagement.Api.Models;
using Archive.CDManagement.Api.Repositories.Abstractions;

namespace Archive.CDManagement.Api.Repositories
{
    public class CDRepository : ICDRepository
    {
        public CDModel GetCDModel(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CDModel> GetCDModelsByTitle(string title)
        {
            throw new NotImplementedException();
        }
    }
}
