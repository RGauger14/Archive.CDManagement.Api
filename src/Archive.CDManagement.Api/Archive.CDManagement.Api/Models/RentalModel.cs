using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        [Required]
        [ForeignKey("Staff")]
        public int StaffId { get; set; }

        public StaffModel Staff { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DateRented { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime DateReturned { get; set; }
        }
}