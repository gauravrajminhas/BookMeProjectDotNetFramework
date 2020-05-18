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
        
        //TODO : have to add configration manager and include the connectionsString via configration Manager object
        private SQLServerDBContext() : base (@"Data Source=LAPTOP-RP1PV1SH\HUMBERBRIDGING;Initial Catalog=BookMeDBDotNetFramework ;Integrated Security=True")
        {

            //TODO: understand this circular referance isses here 
            //Got it!! as there are navigation properties on pocos that are interrelated, serilization will have a endless 
            //circular referance issues. 
            Configuration.ProxyCreationEnabled = false;
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

            modelBuilder.Entity<medicalRecordsPoco>()
                .HasKey(mrp => mrp.recordID)
                .ToTable("medicalRecords", "RecordSchema");

            modelBuilder.Entity<userContactDetailsPoco>()
                .HasKey(ucd => ucd.ecifID)      //dont have to mention the FK as PK is the FK too
                .ToTable("contactDetails", "userSchema");

            modelBuilder.Entity<userStatusPoco>()
                .HasKey(usp => usp.userID)
                .ToTable("userStatus", "userSchema");

            modelBuilder.Entity<userAccessPoco>()
                .HasKey(userAccess => userAccess.userID)
                .ToTable("userAccess", "userSchema");

            modelBuilder.Entity<statusPoco>()
                .HasKey(sp => sp.statusID)
                .ToTable("status", "referenceDataSchema");


            //Additional colomn Properties 
            modelBuilder.Entity<userPoco>()
                .Property(up => up.emailAddress)
                .HasMaxLength(450);

            modelBuilder.Entity<userPoco>()
                .HasIndex(up => up.emailAddress)
                .IsUnique();

 


            //Constraints decleration
            modelBuilder.Entity<userPoco>()
                .HasMany(user => user.userAccessListNavigation)
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


            modelBuilder.Entity<userStatusPoco>()
                .HasRequired(usp => usp.userAccessNavigation)
                .WithRequiredDependent(uap => uap.statusNavigation);
                //.WithRequiredPrincipal(uap => uap.statusNavigation);


            modelBuilder.Entity<statusPoco>()
                .HasMany(sp => sp.userStatusNavigation)
                .WithRequired(us => us.statusNavigation)
                .HasForeignKey(us => us.statusID);


            base.OnModelCreating(modelBuilder);
            Console.WriteLine("\n\n Model Creation Method Ending. Mapping Completed \n\n");
        }


        public virtual DbSet<userPoco> userDBSetRecord { get; set; }
        public virtual DbSet<userAccessPoco> userCredentialsDBSetRecord { get; set; }
        

    }
}
