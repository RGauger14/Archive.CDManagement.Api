using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Archive.CDManagement.Api.Models
{
    public class RentalItemModel : ControllerBase
    {
        [Key]
        public int RentalItemId { get; set; }

        public int RentalId { get; set; }

        public int CDId { get; set; }

        public CDModel CD { get; set; }

        public RentalModel Rental { get; set; }
    }
}