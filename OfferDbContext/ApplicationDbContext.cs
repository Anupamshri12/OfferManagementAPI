using Microsoft.EntityFrameworkCore;
using PiePayAssignment.Enitites;

namespace PiePayAssignment.OfferDbContext
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<AvailableOffers> OfferAvailable { get; set; }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Contributors>().HasNoKey();
        //}

    }
}
