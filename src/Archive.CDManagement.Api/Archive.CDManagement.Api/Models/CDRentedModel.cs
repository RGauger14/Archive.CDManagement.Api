using System.Collections.Generic;
using Archive.CDManagement.Api.Controllers;

namespace Archive.CDManagement.Api.Models
{
    public class CDRentedModel
    {
        public CDModel CD { get; set; }
        public int RentedCount { get; set; }
    }
}