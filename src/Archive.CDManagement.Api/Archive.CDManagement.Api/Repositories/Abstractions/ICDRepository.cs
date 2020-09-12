using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Archive.CDManagement.Api.Models;

namespace Archive.CDManagement.Api.Repositories.Abstractions
{
    public interface ICDRepository
    {
        CDModel GetCD(int id);
        IEnumerable<CDModel> GetAllCds();

        void CreateCD(CDModel cd);
        void UpdateCD(CDModel cd);
        void DeleteCD(int id);
        

    }
}
