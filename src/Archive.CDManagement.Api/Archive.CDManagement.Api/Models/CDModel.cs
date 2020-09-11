using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Archive.CDManagement.Api.Models
{
    public class CDModel
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        //TODO add shelf location (Look up requirements 532 + 503) 
    }
}
