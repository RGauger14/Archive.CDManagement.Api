using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Archive.CDManagement.Api.Models
{
    public class RentalModel 
    {
        [Key]
        public int Id { get; set; }

        public List<RentalItemModel> RentalItems { get; set; }

        public int StaffId { get; set; }
        public StaffModel Staff { get; set; }

        public DateTime DateRented { get; set; }

        public DateTime DateReturned { get; set; }
    }
}