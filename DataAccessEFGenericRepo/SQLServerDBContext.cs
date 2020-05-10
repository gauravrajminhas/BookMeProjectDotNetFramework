using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookMeProject;
using System.Data.Entity.Infrastructure.Annotations;

namespace DataAccessEFGenericRepo
{
     class SQLServerDBContext : DbContext
    {
        

        private SQLServerDBContext() : base (@"Data Source=LAPTOP-RP1PV1SH\HUMBERBRIDGING;Initial Catalog=BookMeDBDotNetFramework ;Integrated Security=True")
        {

        }


        // singelton menthod for the only one instance of DB context; this not thread safe however. 
        private static SQLServerDBContext _singeltonDBContextInstance = null;
        public static SQLServerDBContext SQLServerDBContextSingeltonFactory()
        {
            if (_singeltonDBContextInstance == null)
            {
                _singeltonDBContextInstance = new SQLServerDBContext();
                return _singeltonDBContextInstance;
            }
            else
            {
                return _singeltonDBContextInstance;
            }
                
        }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Console.WriteLine("\n\n Model Creation Method evoked. Mapping Started \n\n");

            //Keys declaration 
            modelBuilder.Entity<userPoco>()
                .HasKey(user => user.ecifID)
                .ToTable("users", "userSchema");

            modelBuilder.Entity<userCredentialsPoco>()
                .HasKey(userCredentials => userCredentials.userID)
                .ToTable("credentials", "userSchema");

            modelBuilder.Entity<medicalRecordsPoco>()
                .HasKey(mrp => mrp.recordID)
                .ToTable("medicalRecords", "RecordSchema");

            modelBuilder.Entity<userContactDetailsPoco>()
                .HasKey(ucd => ucd.ecifID)      //dont have to mention the FK as PK is the FK too
                .ToTable("contactDetails", "userSchema");

            modelBuilder.Entity<userStatusPoco>()
                .HasKey(usp => new { usp.userID, usp.StatusID })
                .ToTable("userStatus", "userSchema");



            //Constraints decleration
            modelBuilder.Entity<userPoco>()
                .HasMany(user => user.userCredentailsListNavigation)
                .WithRequired(credentails => credentails.userNavigation)
                .HasForeignKey(ucl =>ucl.ecifID)
                .WillCascadeOnDelete();


            modelBuilder.Entity<userPoco>()
                .HasOptional(user => user.userContactDetailsNavigation)
                .WithRequired(contactDetails => contactDetails.userNavigation);



            modelBuilder.Entity<medicalRecordsPoco>()
                .HasRequired(mrp => mrp.usersNavigation)
                .WithMany(user => user.medicalRecordsListNavigation)
                .HasForeignKey(mrp => mrp.ecifID)
                .WillCascadeOnDelete();


            modelBuilder.Entity<userCredentialsPoco>()
                .HasOptional(ucp => ucp.statusNavigation)
                .WithRequired(usp => usp.UserCredentialsNavigationPoco);
               


            base.OnModelCreating(modelBuilder);
            Console.WriteLine("\n\n Model Creation Method Ending. Mapping Completed \n\n");
        }


        public virtual DbSet<userPoco> userDBSetRecord { get; set; }
        public virtual DbSet<userCredentialsPoco> userCredentialsDBSetRecord { get; set; }
        

    }
}
