using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Archive.CDManagement.Api.Models;

namespace Archive.CDManagement.Api.Repositories.Abstractions
{
    public interface IReportRepository
    {

        CDRentedModel SingleCDCount(int id);

        IEnumerable<CDRentedModel> AllCDCount();
    }
}
