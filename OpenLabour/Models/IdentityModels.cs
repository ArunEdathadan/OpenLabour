using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Web.DynamicData;
using System.ComponentModel.DataAnnotations;

namespace OpenLabour.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

       public virtual Customer Customer { get; set; }

    }

    //[TableName("Student")]
    //public class Student
    //{
    //    public int ID { get; set; }

    //    [CustomDisplayName("Input Your Name")]
    //    public string Name { get; set; }
    //    public int Class { get; set; }
    //}

    public class Customer
    {
        [Key]
        public int CustomerAddressID { get; set; }
        public string Address { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        public DbSet<Customer> Customer { get; set; }
       // public DbSet<Student> Student { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId);
            // modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id);
            // modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });



           // one - to - zero or one relationship between ApplicationUser and Customer
              //  UserId column in Customers table will be foreign key
            modelBuilder.Entity<ApplicationUser>()
                .HasOptional(m => m.Customer)
                .WithRequired(m => m.ApplicationUser)
                .Map(p => p.MapKey("UserId"));

        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}