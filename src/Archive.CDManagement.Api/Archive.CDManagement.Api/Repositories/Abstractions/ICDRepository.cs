using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Archive.CDManagement.Api.Models;

namespace Archive.CDManagement.Api.Repositories.Abstractions
{
    public interface ICDRepository
    {
        CDModel GetCDModel(int id);
        IEnumerable<CDModel> GetCDModelsByTitle(string title);

    }
}
