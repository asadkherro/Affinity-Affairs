using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Models.BookEvent;
using Models.ContactUs;
using Models.Events;
using Models.EventUser;
using Models.Images;

namespace Affinity_Affairs.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<EventModel> Events { get; set; }
        public DbSet<ImagesModel> Images {  get; set; }
        public DbSet<EventUserModel> EventUsers { get; set; }
        public DbSet<ContactUsModel> ContactUs { get; set; }
        public DbSet<BookEventModel> BookEvents { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            var Admin = new IdentityRole("Admin");
            Admin.NormalizedName = "Admin";
            var User = new IdentityRole("User");
            User.NormalizedName = "User";

            builder.Entity<IdentityRole>().HasData(Admin, User);

            builder.Entity<EventUserModel>()
                .HasKey(e => new { e.EventId, e.UserId });
        }
    }
}
