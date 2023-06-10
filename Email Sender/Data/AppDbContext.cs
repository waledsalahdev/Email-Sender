using Microsoft.EntityFrameworkCore;

namespace Email_Sender.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
                
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
   
        }
        public DbSet<MailRequest> MailRequests { get; set; }
    }

}
