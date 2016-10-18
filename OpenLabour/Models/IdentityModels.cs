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
        public virtual Category Category { get; set; }

    }


    #region country and areas
    public class Country
    {
        [Key]
        public int CountryID { get; set; }
        public string CountryName { get; set; }
        public string Description { get; set; }

        public virtual EventMaster EventMaster { get; set; }
    }

    public class State
    {
        [Key]
        public int StateID { get; set; }
        public string SateName { get; set; }
        public string Description { get; set; }
        public bool? Active { get; set; }

        public virtual ApplicationUser CreatedByUser { get; set; }
        public virtual EventMaster EventMaster { get; set; }
    }

    public class City
    {
        [Key]
        public int CityID { get; set; }
        public string CityName { get; set; }
        public string Description { get; set; }
        public bool? Active { get; set; }

        public virtual ApplicationUser CreatedByUser { get; set; }
        public virtual EventMaster EventMaster { get; set; }
    }

    public class Area
    {
        [Key]
        public int AreaID { get; set; }
        public string AreaName { get; set; }
        public string Description { get; set; }
        public bool? Active { get; set; }

        public virtual ApplicationUser CreatedByUser { get; set; }
        public virtual EventMaster EventMaster { get; set; }
    }

    public class PostOffice
    {
        [Key]
        public int PostOfficeID { get; set; }
        public string PostOfficeName { get; set; }
        public string Description { get; set; }
        public bool? Active { get; set; }

        public virtual ApplicationUser CreatedByUser { get; set; }
        public virtual EventMaster EventMaster { get; set; }
    }

    public class LocalPlace
    {
        [Key]
        public int LocalPlaceID { get; set; }
        public string LocalPlaceName { get; set; }
        public string Description { get; set; }
        public bool? Active { get; set; }

        public virtual ApplicationUser CreatedByUser { get; set; }
        public virtual EventMaster EventMaster { get; set; }
    }


    #endregion


    #region Category
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string MyProperty { get; set; }

        public virtual ApplicationUser CreatedByUser { get; set; }
        public virtual EventMaster EventMaster { get; set; }
    }
    #endregion

    #region Event

    public class EventMaster
    {
        [Key]
        public int EventID { get; set; }

        public string TitleNative { get; set; }
        public string Title { get; set; }
        public string SmallDescriptionNative { get; set; }
        public string SmallDescription { get; set; }
        public string BigDescriptionNative { get; set; }
        public string BigDescription { get; set; }

        /// <summary>
        /// No jquery or javasript should be allowed
        /// </summary>
        public string HtmlContent { get; set; }

        public string MetaTags { get; set; }
        public string MetaNative { get; set; }
        public string MetaDescription { get; set; }

        public int? ParentID { get; set; }
        public virtual EventMaster Parent { get; set; }

        public virtual ApplicationUser CreatedByUser { get; set; }
        public virtual Category Category { get; set; }

        public virtual City City { get; set; }
        public virtual State State { get; set; }
        public virtual Country Country { get; set; }
        public virtual Area Area { get; set; }
        public virtual PostOffice PostOffice { get; set; }
        public virtual LocalPlace LocalPlace { get; set; }

        public virtual CommentMaster CommentMaster { get; set; }
    }

    public class CommentMaster
    {
        [Key]
        public int CommentID { get; set; }

        public string CommentDetails { get; set; }
        public int UpVoteCount { get; set; }
        public int DownVoteCount { get; set; }
        public int CommentEmotion { get; set; }

        // public int? ParentID { get; set; }
        // public virtual CommentMaster Parent { get; set; }

        public int? EventID { get; set; }
        public virtual EventMaster EventMaster { get; set; }

        public string CommentedBy { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }

    /// <summary>
    /// First inserting of the comment is added to this, when a reply to a certain comment is started, the first comment is taken from the main, rest is here
    /// </summary>
    public class CommentReplyMaster
    {
        [Key]
        public int CommentReplyID { get; set; }
        public string CommentDetail { get; set; }

        public string CommentedBy { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        public int? ParentID { get; set; }
        public virtual CommentReplyMaster Parent { get; set; }
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


        #region  country and areas
        public DbSet<Country> Country { get; set; }
        public DbSet<State> State { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<Area> Area { get; set; }
        public DbSet<PostOffice> PostOffice { get; set; }
        public DbSet<LocalPlace> LocalPlace { get; set; }
        #endregion

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region country and areas
            modelBuilder.Entity<EventMaster>()
                .HasOptional(x => x.Area)
                .WithRequired(x => x.EventMaster)
                .Map(x => x.MapKey("EventID"));

            modelBuilder.Entity<EventMaster>()
               .HasOptional(x => x.City)
               .WithRequired(x => x.EventMaster)
               .Map(x => x.MapKey("EventID"));

            modelBuilder.Entity<EventMaster>()
                .HasOptional(x => x.Country)
                .WithRequired(x => x.EventMaster)
                .Map(x => x.MapKey("EventID"));

            modelBuilder.Entity<EventMaster>()
                .HasOptional(x => x.LocalPlace)
                .WithRequired(x => x.EventMaster)
                .Map(x => x.MapKey("EventID"));

            modelBuilder.Entity<EventMaster>()
                .HasOptional(x => x.PostOffice)
                .WithRequired(x => x.EventMaster)
                .Map(x => x.MapKey("EventID"));

            modelBuilder.Entity<EventMaster>()
                .HasOptional(x => x.State)
                .WithRequired(x => x.EventMaster)
                .Map(x => x.MapKey("EventID"));

            #endregion


            #region Event

            modelBuilder.Entity<EventMaster>()
                .HasOptional(e => e.Parent)
                .WithMany()
                .HasForeignKey(m => m.ParentID);


            modelBuilder.Entity<EventMaster>()
                .HasOptional(x => x.Area)
                .WithRequired(x => x.EventMaster)
                .Map(x => x.MapKey("EventID"));


            modelBuilder.Entity<CommentMaster>()
                .HasOptional(e => e.EventMaster)
                .WithMany()
                .HasForeignKey(m => m.EventID);

            modelBuilder.Entity<CommentMaster>()
                .HasRequired(e => e.ApplicationUser)
                .WithMany()
                .HasForeignKey(m => m.CommentedBy);


            modelBuilder.Entity<EventMaster>()
              .HasOptional(m => m.Category)
              .WithRequired(x => x.EventMaster)
              .Map(p => p.MapKey("EventID"));


            modelBuilder.Entity<CommentReplyMaster>()
                .HasOptional(m => m.Parent)
                .WithMany()
                .HasForeignKey(x => x.ParentID);

            modelBuilder.Entity<CommentReplyMaster>()
                .HasRequired(m => m.ApplicationUser)
                .WithMany()
                .HasForeignKey(x => x.CommentedBy);

            #endregion

            #region Identity User

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

            modelBuilder.Entity<ApplicationUser>()
                .HasOptional(m => m.EventMaster)
                .WithRequired(x => x.CreatedByUser)
                .Map(p => p.MapKey("UserID"));

            modelBuilder.Entity<ApplicationUser>()
                .HasOptional(x => x.Category)
                .WithRequired(x => x.CreatedByUser)
                .Map(m => m.MapKey("UserID"));
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}