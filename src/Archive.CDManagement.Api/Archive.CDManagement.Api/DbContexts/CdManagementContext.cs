using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Archive.CDManagement.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Archive.CDManagement.Api.DbContexts
{
    public class CdManagementContext : DbContext
    {
        public CdManagementContext(DbContextOptions<CdManagementContext> options) : base(options)
        {
        }

        public DbSet<CDModel> CDs { get; set; }

        public DbSet<RentalModel> Rentals { get; set; }
    }
}