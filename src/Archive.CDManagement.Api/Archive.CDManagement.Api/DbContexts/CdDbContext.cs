using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Archive.CDManagement.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Archive.CDManagement.Api.DbContexts
{
    public class CdDbContext : DbContext
    {
       public CdDbContext(DbContextOptions<CdDbContext> options) : base(options)
       {
        
       }

       public DbSet<CDModel> CDs { get; set; }
    }
}
