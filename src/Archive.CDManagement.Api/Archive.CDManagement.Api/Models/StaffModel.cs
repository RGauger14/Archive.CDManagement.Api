﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Archive.CDManagement.Api.Models
{
    public class StaffModel 
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(10)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(10)]
        public string LastName { get; set; }

        [Required]
        [StringLength(25)]
        public string Address { get; set; }
        
        [Required]
        [StringLength(40)]  //Could use [DataType(EmailAddressAttribute] **Review**
        public string Email { get; set; }

        [Required]
        [StringLength(12)]
        public string MobileNumber { get; set; }

        [Required]
        public bool Active { get; set; }
    }
}