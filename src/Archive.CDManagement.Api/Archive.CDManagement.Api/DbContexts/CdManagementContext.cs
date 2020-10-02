using Archive.CDManagement.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Archive.CDManagement.Api.DbContexts
{
    public class CdManagementContext : DbContext
    {
        public CdManagementContext(DbContextOptions<CdManagementContext> options) : base(options)
        {
        }

        public DbSet<StaffModel> Staff { get; set; }

        public DbSet<CDModel> CDs { get; set; }

        public DbSet<RentalModel> Rentals { get; set; }
    }
}