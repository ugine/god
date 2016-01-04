using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace TherapyBuddy.Models
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
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<TherapyBuddy.Models.Assignment> Assignments { get; set; }

        public System.Data.Entity.DbSet<TherapyBuddy.Models.Department> Departments { get; set; }

        public System.Data.Entity.DbSet<TherapyBuddy.Models.Therapist> Therapists { get; set; }

        public System.Data.Entity.DbSet<TherapyBuddy.Models.Patient> Patients { get; set; }

        public System.Data.Entity.DbSet<TherapyBuddy.Models.Rank> Ranks { get; set; }

        public System.Data.Entity.DbSet<TherapyBuddy.Models.ExerciseInstruction> ExerciseInstructions { get; set; }

        public System.Data.Entity.DbSet<TherapyBuddy.Models.Feedback> Feedbacks { get; set; }

        public System.Data.Entity.DbSet<TherapyBuddy.Models.AssignedVideo> AssignedVideos { get; set; }

        public System.Data.Entity.DbSet<TherapyBuddy.Models.AssignedImage> AssignedImages { get; set; }
        public System.Data.Entity.DbSet<TherapyBuddy.Models.Exercise> Exercises { get; set; }

        public System.Data.Entity.DbSet<TherapyBuddy.Models.ExerciseImage> ExerciseImages { get; set; }

        public System.Data.Entity.DbSet<TherapyBuddy.Models.ExerciseVideo> ExerciseVideos { get; set; }

        public System.Data.Entity.DbSet<TherapyBuddy.Models.ExerciseRegion> ExerciseRegions { get; set; }       

        public System.Data.Entity.DbSet<TherapyBuddy.Models.ExerciseType> ExerciseTypes { get; set; }

    }
}