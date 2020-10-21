using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace FTMS.Models
{
	public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<ManageTrainee> ManageTrainees { get; set; }
        public DbSet<ManageTrainer> ManageTrainers { get; set; }
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}