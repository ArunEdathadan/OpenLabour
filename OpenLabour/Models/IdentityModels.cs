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

        public int? ParentUserID { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual UserImageStore UserImageStore { get; set; }
        public virtual EventMaster EventMaster { get; set; }

    }

    //[TableName("Student")]
    //public class Student
    //{
    //    public int ID { get; set; }

    //    [CustomDisplayName("Input Your Name")]
    //    public string Name { get; set; }
    //    public int Class { get; set; }
    //}


    #region Event

    public class EventMaster
    {
        [Key]
        public int EventID { get; set; }
        public string Details { get; set; }
        public string Title { get; set; }
        public string SmallDescription { get; set; }

        public string MetaTags { get; set; }
        public string MetaDescription { get; set; }

        public virtual ApplicationUser CreatedByUser { get; set; }

    }
    #endregion



    public class Customer
    {
        [Key]
        public int CustomerAddressID { get; set; }
        public string Address { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }

    public class UserImageStore
    {
        [Key]
        public int ImageID { get; set; }
        public string ImageLoc { get; set; }
        public string Description { get; set; }
        public string ProfilePic { get; set; }
        public bool Active { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<UserImageStore> UserImageStore { get; set; }
        public DbSet<EventMaster> EventMaster { get; set; }
        // public DbSet<Student> Student { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region Event

            modelBuilder.Entity<ApplicationUser>()
                .HasOptional(m => m.EventMaster)
                .WithRequired(x => x.CreatedByUser)
                .Map(p => p.MapKey("UserID"));


            #endregion

            #region Identity User

            #endregion

            #region Post

            #endregion
            // one - to - zero or one relationship between ApplicationUser and Customer
            //  UserId column in Customers table will be foreign key
            modelBuilder.Entity<ApplicationUser>()
                .HasOptional(m => m.Customer)
                .WithRequired(m => m.ApplicationUser)
                .Map(p => p.MapKey("UserId"));

            modelBuilder.Entity<ApplicationUser>().
                HasOptional(m => m.UserImageStore).
                WithRequired(m => m.ApplicationUser).
                Map(p => p.MapKey("UserID"));


        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}