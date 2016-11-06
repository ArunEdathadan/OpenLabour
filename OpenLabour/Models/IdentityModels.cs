using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Web.DynamicData;
using System.ComponentModel.DataAnnotations;
using System;

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

        /// <summary>
        /// self referencing for multiple password for same account
        /// </summary>
        public int? ParentUserID { get; set; }
    }

    #region Assets (User)
    public class UserAssets
    {
        [Key]
        public int UserAssetID { get; set; }
        public string AssetTitle { get; set; }
        public string AssetDetails { get; set; }
        public string PhoneNumber { get; set; }

        public string VehicleNumber { get; set; }
        public string InstitutionNumber { get; set; }

        public DateTime CreatedOn { get; set; }

        public int AssetID { get; set; }
        public virtual AssetType AssetType { get; set; }
    }

    public class AssetType
    {
        [Key]
        public int AssetID { get; set; }
        public string AssectType { get; set; }
    }

    public class UserImages
    {
        [Key]
        public int UserImageID { get; set; }
        public string ImageUrl { get; set; }
        public string ImageDesc { get; set; }
        public bool? IsActive { get; set; }

        public string UserID { get; set; }
        public virtual ApplicationUser ApplicationUserParent { get; set; }
    }
    #endregion

    #region Job
    public class JobEngagement
    {
        [Key]
        public int JobEngID { get; set; }
        public string JobDescription { get; set; }

        public int ConfirationCount { get; set; }
        public string JobTitle { get; set; }
        public string JobDetails { get; set; }

        public int OrgID { get; set; }
        public virtual OrgInstitutionCompany OrgInstitutionCompanyParent { get; set; }

        public string UserID { get; set; }
        public virtual ApplicationUser ApplicationUserParent { get; set; }
    }

    public class JobType
    {
        [Key]
        public int JobTypeID { get; set; }
        public string JobTitle { get; set; }

        public int? JobParentID { get; set; }
        public virtual JobType JobTypeParent { get; set; }
    }
    #endregion

    #region Subscriptions
    public class SubsriptionToUser
    {
        [Key]
        public int UserSubsriptionID { get; set; }
        public string Description { get; set; }

        public string SubscribedByUserID { get; set; }
        public virtual ApplicationUser ApplicationUserParent { get; set; }

        public string SubscribedOnUserID { get; set; }


        public bool? Active { get; set; }
        public DateTime SubscribedDate { get; set; }

    }
    #endregion


    #region Organisation , Institutions or Companies
    public class OrgInstitutionCompany
    {
        [Key]
        public int OrgInstCompID { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Brief { get; set; }
        public string Description { get; set; }
        public string IdentificationNumber { get; set; }
        public string IdentificationType { get; set; }
        public bool IsActive { get; set; }
        public string GoogleMaps { get; set; }
        public bool? IsVerfied { get; set; }
        public string OwnerID { get; set; }
        public bool? IsBranch { get; set; }

        public int? ParentID { get; set; }
        public virtual OrgInstitutionCompany OrgInstitutionCompanyParent { get; set; }
    }

    public class OrganisationAssets
    {
        [Key]
        public int UserAssetID { get; set; }
        public string AssetTitle { get; set; }
        public string AssetDetails { get; set; }
        public string PhoneNumber { get; set; }

        public string VehicleNumber { get; set; }
        public string InstitutionNumber { get; set; }

        public DateTime CreatedOn { get; set; }

        public int AssetID { get; set; }
        public virtual AssetType AssetType { get; set; }
    }
    #endregion


    #region country and areas
    public class Country
    {
        [Key]
        public int CountryID { get; set; }
        public string CountryName { get; set; }
        public string Description { get; set; }
    }

   public class State
   {
      [Key]
      public int StateID { get; set; }
      public string SateName { get; set; }
      public string Description { get; set; }
      public bool? Active { get; set; }

      public int CountryID{get;set;}
      public virtual Country Country { get; set; }
        //   public virtual ApplicationUser CreatedByUser { get; set; }
    }

    public class City
    {
        [Key]
        public int CityID { get; set; }
        public string CityName { get; set; }
        public string Description { get; set; }
        public bool? Active { get; set; }

        //  public virtual ApplicationUser CreatedByUser { get; set; }
    }

    public class Area
    {
        [Key]
        public int AreaID { get; set; }
        public string AreaName { get; set; }
        public string Description { get; set; }
        public bool? Active { get; set; }

        //  public virtual ApplicationUser CreatedByUser { get; set; }
    }

    public class PostOffice
    {
        [Key]
        public int PostOfficeID { get; set; }
        public string PostOfficeName { get; set; }
        public string Description { get; set; }
        public bool? Active { get; set; }

        //   public virtual ApplicationUser CreatedByUser { get; set; }
    }

    public class LocalPlace
    {
        [Key]
        public int LocalPlaceID { get; set; }
        public string LocalPlaceName { get; set; }
        public string Description { get; set; }
        public bool? Active { get; set; }

        //  public virtual ApplicationUser CreatedByUser { get; set; }
    }

    public class Address
    {
        public City c { get; set; }

    }

    #endregion


    #region Category
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }


        public string CreatedByUserID { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

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
        public virtual EventMaster EventMasterParent { get; set; }

        public string CreatedByUserID { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        public int? CategoryID { get; set; }
        //   public virtual Category Category { get; set; }

        public int? CityID { get; set; }
        public virtual City City { get; set; }

        public int? StateID { get; set; }
        public virtual State State { get; set; }

        public int? CountryID { get; set; }
        public virtual Country Country { get; set; }

        public int? AreaID { get; set; }
        public virtual Area Area { get; set; }

        public int? PostOfficeID { get; set; }
        public virtual PostOffice PostOffice { get; set; }

        public int? LocalPlaceID { get; set; }
        public virtual LocalPlace LocalPlace { get; set; }

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

        public int EventID { get; set; }
        public virtual EventMaster EventMaster { get; set; }

        public string CommentedByID { get; set; }
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

        public string CommentedByID { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        public int? ParentID { get; set; }
        public virtual CommentReplyMaster CommentReplyMasterParent { get; set; }
    }

    #endregion


    public class UserImageStore
    {
        [Key]
        public int ImageID { get; set; }
        public string ImageLoc { get; set; }
        public string Description { get; set; }
        public string ProfilePic { get; set; }
        public bool Active { get; set; }

        public string UserID { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        public DbSet<UserImageStore> UserImageStore { get; set; }
        public DbSet<UserImages> UserImages { get; set; }
        public DbSet<EventMaster> EventMaster { get; set; }

        public DbSet<AssetType> AssetType { get; set; }
        public DbSet<UserAssets> UserAssets { get; set; }

        #region  country and areas
        public DbSet<Country> Country { get; set; }
        public DbSet<State> State { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<Area> Area { get; set; }
        public DbSet<PostOffice> PostOffice { get; set; }
        public DbSet<LocalPlace> LocalPlace { get; set; }
        #endregion

        public DbSet<CommentReplyMaster> CommentReplyMaster { get; set; }
        public DbSet<CommentMaster> CommentMaster { get; set; }
        public DbSet<Category> Category { get; set; }

        public DbSet<OrganisationAssets> OrganisationAssets { get; set; }
        public DbSet<OrgInstitutionCompany> OrgInstitutionCompany { get; set; }

        public DbSet<SubsriptionToUser> SubsriptionToUser { get; set; }
        public DbSet<JobType> JobType { get; set; }
        public DbSet<JobEngagement> JobEngagement { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region User Assets
            modelBuilder.Entity<UserAssets>()
                .HasRequired(x => x.AssetType)
                .WithMany()
                .HasForeignKey(x => x.AssetID);

            modelBuilder.Entity<UserImages>()
                .HasRequired(x => x.ApplicationUserParent)
                .WithMany()
                .HasForeignKey(x => x.UserID);
            #endregion

            #region Job
            modelBuilder.Entity<JobEngagement>()
                .HasRequired(x => x.OrgInstitutionCompanyParent)
                .WithMany()
                .HasForeignKey(x => x.OrgID);

            modelBuilder.Entity<JobEngagement>()
                .HasRequired(x => x.ApplicationUserParent)
                .WithMany()
                .HasForeignKey(x => x.UserID);

            modelBuilder.Entity<JobType>()
                .HasOptional(x => x.JobTypeParent)
                .WithMany()
                .HasForeignKey(x => x.JobParentID);
            #endregion

            modelBuilder.Entity<OrgInstitutionCompany>()
                .HasOptional(x => x.OrgInstitutionCompanyParent)
                .WithMany()
                .HasForeignKey(x => x.ParentID);

            #region Subsription     
            modelBuilder.Entity<SubsriptionToUser>()
                .HasRequired(x => x.ApplicationUserParent)
                .WithMany()
                .HasForeignKey(x => x.SubscribedByUserID);

            modelBuilder.Entity<SubsriptionToUser>()
                .HasRequired(x => x.ApplicationUserParent)
                .WithMany()
                .HasForeignKey(x => x.SubscribedOnUserID);
         #endregion

         #region country and areas
         modelBuilder.Entity<State>()
            .HasRequired(x => x.Country)
            .WithMany()
            .HasForeignKey(x => x.CountryID);

            modelBuilder.Entity<EventMaster>()
                .HasOptional(x => x.Area)
                .WithMany()
                .HasForeignKey(x => x.AreaID);

            modelBuilder.Entity<EventMaster>()
               .HasOptional(x => x.City)
               .WithMany()
               .HasForeignKey(x => x.CityID);

            modelBuilder.Entity<EventMaster>()
                .HasOptional(x => x.Country)
                .WithMany()
                .HasForeignKey(x => x.CountryID);

            modelBuilder.Entity<EventMaster>()
                .HasOptional(x => x.LocalPlace)
                .WithMany()
                .HasForeignKey(x => x.LocalPlaceID);

            modelBuilder.Entity<EventMaster>()
                .HasOptional(x => x.PostOffice)
                .WithMany()
                .HasForeignKey(x => x.PostOfficeID);

            modelBuilder.Entity<EventMaster>()
                .HasOptional(x => x.State)
                .WithMany()
                .HasForeignKey(x => x.StateID);

            #endregion


            #region Event

            modelBuilder.Entity<EventMaster>()
                .HasOptional(e => e.EventMasterParent)
                .WithMany()
                .HasForeignKey(m => m.ParentID);


            modelBuilder.Entity<CommentMaster>()
                .HasRequired(e => e.EventMaster)
                .WithMany()
                .HasForeignKey(m => m.EventID);

            modelBuilder.Entity<CommentMaster>()
                .HasRequired(e => e.ApplicationUser)
                .WithMany()
                .HasForeignKey(m => m.CommentedByID);


            //modelBuilder.Entity<EventMaster>()
            //  .HasOptional(m => m.Category)
            //  .WithMany()
            //  .HasForeignKey(x=>x.EventID);

            modelBuilder.Entity<EventMaster>()
                .HasOptional(m => m.ApplicationUser)
                .WithMany()
                .HasForeignKey(x => x.CreatedByUserID);


            modelBuilder.Entity<CommentReplyMaster>()
                .HasOptional(m => m.CommentReplyMasterParent)
                .WithMany()
                .HasForeignKey(x => x.ParentID);

            modelBuilder.Entity<CommentReplyMaster>()
                .HasRequired(m => m.ApplicationUser)
                .WithMany()
                .HasForeignKey(x => x.CommentedByID);

            modelBuilder.Entity<UserImageStore>()
                .HasOptional(m => m.ApplicationUser)
                .WithMany()
                .HasForeignKey(x => x.UserID);

            #endregion

            #region Identity User

            #endregion


            modelBuilder.Entity<Category>()
                .HasOptional(x => x.ApplicationUser)
                .WithMany()
                .HasForeignKey(x => x.CreatedByUserID);
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}