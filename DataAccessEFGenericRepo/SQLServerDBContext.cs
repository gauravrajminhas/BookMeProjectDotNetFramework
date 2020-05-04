using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookMeProject;

namespace DataAccessEFGenericRepo
{
    class SQLServerDBContext : DbContext
    {
        public SQLServerDBContext() : base (@"Data Source=LAPTOP-RP1PV1SH\HUMBERBRIDGING;Initial Catalog=BookMeDBDotNetFramework ;Integrated Security=True")
        {

        }
        
        

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            // center table has been split into Entities ! 
            modelBuilder.Entity<center>()
                .HasKey(c=>c.centerID)
                .ToTable("centers");
            

            modelBuilder.Entity<centerContactDetails>()
                .HasKey(ccd=>ccd.centerID)
                .ToTable("centers");

            modelBuilder.Entity<center>()
                .HasRequired(cen => cen.centerContactDetailsNavigation)
                .WithRequiredPrincipal(ccd =>ccd.centerNavigation);



            // Customer entitie has been split into tables 
            modelBuilder.Entity<customer>()
                .Map(map =>
                   {
                       map.Properties(
                           customerProperties => new {
                               customerProperties.customerID,
                               customerProperties.customerName,
                               customerProperties.isActive
                           });
                       map.ToTable("customer");
                   })

                .Map(map =>
                    {
                        map.Properties(
                           customerProperties => new {
                               customerProperties.emailAddress,
                               customerProperties.customerAddress,
                               customerProperties.phoneNumber,
                               customerProperties.pic
                           });
                        map.ToTable("customerContactDetails");
                    });


            // many to many relationships 
            modelBuilder.Entity<course>()
                .HasMany(c => c.studentsListNavigation)
                .WithMany(s => s.courseListNavigation)
                .Map( map=>
                        {
                            map.ToTable("StudentAndCourse","StudentsCoursesSchema");
                            map.MapLeftKey("courseID");
                            map.MapRightKey("studentID");
                        }
                );






            //Bug- this is throwing an Error !! 
            //modelBuilder.Entity<customer>()
            //     .Map(MapconfigObject => MapconfigObject.Requires("isActive").HasValue(false))
            //     .Ignore(cus => cus.isActive);



            Console.WriteLine("\n\n Model Creation Method evoked. Mapping Completed \n\n");
            base.OnModelCreating(modelBuilder);
        }



        public virtual DbSet<customer> customerDBSetRecord { get; set; }
        public  virtual DbSet<center> centerBDSetRecord { get; set; }

        public virtual DbSet<student>  studentDBSetRecord { get; set; }
        public virtual DbSet<course> courseDBSetRecord { get; set; }

    }
}
