using System.Collections.Generic;
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

        void CreateCDs(IEnumerable<CDModel> cds);
    }
}