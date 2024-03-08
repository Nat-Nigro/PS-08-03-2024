using AlbergoNigro.Models;
using Microsoft.EntityFrameworkCore;

namespace AlbergoNigro.Data
{
    public class AlbergoNigroContext : DbContext
    {
        public AlbergoNigroContext(DbContextOptions<AlbergoNigroContext> options)
            : base(options)
        {
        }

        public DbSet<AlbergoNigro.Models.Clienti> Clienti { get; set; } = default!;
        public DbSet<AlbergoNigro.Models.Camere> Camere { get; set; } = default!;
        public DbSet<AlbergoNigro.Models.Servizi> Servizi { get; set; } = default!;
        public DbSet<AlbergoNigro.Models.Pensione> Pensione { get; set; } = default!;
        public DbSet<AlbergoNigro.Models.Prenotazione> Prenotazione { get; set; } = default!;
        public DbSet<AlbergoNigro.Models.LogIn> LogIn { get; set; } = default!;
        public DbSet<AlbergoNigro.Models.CheckoutViewModel> CheckoutViewModel { get; set; } = default!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<CheckoutViewModel>().HasNoKey();
        }
    }
}
