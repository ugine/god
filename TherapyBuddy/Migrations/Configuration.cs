namespace TherapyBuddy.Migrations
{
    using Microsoft.AspNet.Identity;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Models;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Collections.Generic;

    internal sealed class Configuration : DbMigrationsConfiguration<TherapyBuddy.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(TherapyBuddy.Models.ApplicationDbContext context)
        {
            var department = new List<Department>
            {
                new Department{DepartmentName="Occupational Therapist"},
                new Department{DepartmentName="Physiotherapist"}
            };
            department.ForEach(d => context.Departments.Add(d));
            context.SaveChanges();
            var category = new List<ExerciseRegion>
            {
                new ExerciseRegion{Name="Hand"},
                new ExerciseRegion{Name="Leg"},
                new ExerciseRegion{Name="Shoulder"},
                new ExerciseRegion{Name="Knee"},
                new ExerciseRegion{Name="Elbow"},
                new ExerciseRegion{Name="Fingers"},
            };
            category.ForEach(c => context.ExerciseRegions.Add(c));
            context.SaveChanges();
            var exerciseType = new List<ExerciseType>
            {
                new ExerciseType{Name="Strengthening"},
                new ExerciseType{Name="Ranging"},
                new ExerciseType{Name="Massaging"},
                new ExerciseType{Name="Cardiovascular"},
            };
            exerciseType.ForEach(c => context.ExerciseTypes.Add(c));
            context.SaveChanges();

            var exercise = new List<Exercise>
            {
                new Exercise{Name="Wrist Extension Stretch", Description="Rotate hands exercise",ExerciseRegionID=1, ExerciseTypeID=1},
                new Exercise{Name="Lunges", Description="Lunges exercise",ExerciseRegionID=2,ExerciseTypeID=2},
                new Exercise{Name="Theraband Shoulder Horizontal Extension", Description="Theraband Shoulder Horizontal Extension exercise",ExerciseRegionID=3, ExerciseTypeID=3},
                new Exercise{Name="Knee to Chest Stretch (single leg)", Description="Knee to Chest Stretch (single leg) exercise",ExerciseRegionID=4, ExerciseTypeID=2},
            };
            exercise.ForEach(c => context.Exercises.Add(c));
            context.SaveChanges();
            var exerciseVideos = new List<ExerciseVideo>
            {
                new ExerciseVideo{VideoURL="https://www.youtube.com/embed/JO6sNPhn634",ExerciseID=1},
                new ExerciseVideo{VideoURL="https://www.youtube.com/embed/wD2mDyaAtOA",ExerciseID=2},
                new ExerciseVideo{VideoURL="https://www.youtube.com/embed/Nh4jKEccxlM",ExerciseID=3},
                new ExerciseVideo{VideoURL="https://www.youtube.com/embed/bTN2AMriMiQ",ExerciseID=4}
            };
            exerciseVideos.ForEach(c => context.ExerciseVideos.Add(c));
            context.SaveChanges();

            var store = new RoleStore<IdentityRole>(context);
            var manager = new RoleManager<IdentityRole>(store);
            var role = new IdentityRole { Name = "Admin" };
            manager.Create(role);
            role = new IdentityRole { Name = "Therapist" };
            manager.Create(role);
            role = new IdentityRole { Name = "Patient" };
            manager.Create(role);

            ApplicationUserManager userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));
            var user = new ApplicationUser { Email = "admin@ktph.com.sg", UserName = "admin@ktph.com.sg" };
            userManager.Create(user, "admin123");
            userManager.AddToRole(user.Id, "Admin");

            user = new ApplicationUser { Email = "therapist@ktph.com.sg", UserName = "therapist@ktph.com.sg" };
            userManager.Create(user, "therapist123");
            userManager.AddToRole(user.Id, "Therapist");

            Therapist therapist = new Therapist { Name = "Emma", Email = "therapist@ktph.com.sg", Password = "therapist123", DepartmentID = 1};
            context.Therapists.Add(therapist);
            context.SaveChanges();

            user = new ApplicationUser { Email = "john@gmail.com", UserName = "john@gmail.com" };
            userManager.Create(user, "john123");
            userManager.AddToRole(user.Id, "Patient");

            user = new ApplicationUser { Email = "bob@gmail.com", UserName = "bob@gmail.com" };
            userManager.Create(user, "bob123");
            userManager.AddToRole(user.Id, "Patient");

            Patient patient = new Patient { Name = "John", Patient_Email = "john@gmail.com", Password = "john123", Gender="M", Phone_Number= 98283345, Date_Of_Birth="10/07/1982"};
            context.Patients.Add(patient);
            context.SaveChanges();

            patient = new Patient { Name = "Bob", Patient_Email = "bob@gmail.com", Password = "bob123", Gender = "M", Phone_Number = 98334538, Date_Of_Birth = "24/02/1978" };
            context.Patients.Add(patient);
            context.SaveChanges();

            Feedback feedback = new Feedback { Recipient = "Tom", Sender = "John", Date_Sent = "23/10/2015", HasReplied = true,Description="Hi tom, would need some help regarding the exercise you assigned to me."};
            context.Feedbacks.Add(feedback);
            context.SaveChanges();

            feedback = new Feedback { Recipient = "Emma", Sender = "Susan", Date_Sent = "27/10/2015", HasReplied = true, Description = "Hi Emma, i have some enquiries on how to carry out Knee to Chest Stretch (single leg)" };
            context.Feedbacks.Add(feedback);
            context.SaveChanges();
        }
    }
}
