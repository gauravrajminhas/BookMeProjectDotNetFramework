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
    public class bookMeDBContext : DbContext
    {
        

        //TODO : have to add configration manager and include the connectionsString via configration Manager object
        // Server=tcp:bookmeazuredb.database.windows.net,1433;Initial Catalog=bookMeAzureDB;Persist Security Info=False;User ID=gaurav.minhas;Password={your_password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;
        // @"Data Source=LAPTOP-RP1PV1SH\HUMBERBRIDGING;Initial Catalog=BookMeDBDotNetFramework ;Integrated Security=True"
        public bookMeDBContext() : base (@"Data Source=DESKTOP-8CDDIFO\HUMBERBRIDGING;Initial Catalog=BookMeDBDotNetFramework;Integrated Security=True")
        {

            //TODO: understand this circular referance isses here - Got it!! as there are navigation properties on pocos that are interrelated, serilization will have a endless 
            //circular referance issues. 

            //There was an error while trying to serialize parameter http://tempuri.org/:getCompleteUserSnapshotResult. 
            //The InnerException message was 'Object graph for type 'BookMeProject.medicalRecordsPoco' contains cycles 
            //and cannot be serialized if reference tracking is disabled.'.  

            base.Configuration.ProxyCreationEnabled = true;
        }


        private static bookMeDBContext _singeltonDBContextInstance = null;

        // singelton menthod for the only one instance of DB context; this thread safe however. 
        // this Approach is now causing Threading issues coz multiple threads are trying to do CRUD using one dbContext instance 
        public static bookMeDBContext bookMeDBContextSingeltonFactory()
        {
            if (_singeltonDBContextInstance == null)
            {
                _singeltonDBContextInstance = new bookMeDBContext();
                return _singeltonDBContextInstance;
            }
            else
            {
                return _singeltonDBContextInstance;
            }
                
        }

        //Adding a new Non-singelton FactoryMethod to .solve the Threading isses 
        public static bookMeDBContext bookMeDBContextNonSingeltonFactory()
        {
            _singeltonDBContextInstance = new bookMeDBContext();
            return _singeltonDBContextInstance;
        }








        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Console.WriteLine("\n\n Model Creation Method evoked. Mapping Started \n\n");

            //Keys declaration 
            modelBuilder.Entity<userPoco>()
                .HasKey(user => user.ecifID)
                .ToTable("users", "userSchema");
                

            modelBuilder.Entity<userContactDetailsPoco>()
                .HasKey(ucd => ucd.ecifID)      //dont have to mention the FK as PK is the FK too
                .ToTable("contactDetails", "userSchema");

            modelBuilder.Entity<userCredentialsPoco>()
                .HasKey(userAccess => userAccess.userID)
                .ToTable("userCredentials", "userSchema");




                 // Subscriptions 
            modelBuilder.Entity<subscriptionsPoco>()
                .HasKey(usp => usp.subscriptionID)
                .ToTable("subscriptions", "subscriptions");




                 //RecordSchema
            modelBuilder.Entity<medicalRecordsPoco>()
                .HasKey(mrp => mrp.recordID)
                .ToTable("medicalRecords", "RecordSchema");



                //Schedule Schema
            modelBuilder.Entity<classPoco>()
                .HasKey<Guid>(cp => cp.classID)
                .ToTable("class", "Schedule");

            modelBuilder.Entity<programPoco>()
                .HasKey<Guid>(pp => pp.programID)
                .ToTable("program","Schedule");

            modelBuilder.Entity<bookingPoco>()
                .HasKey<Guid>(sp => sp.bookingID)
                .ToTable("booking", "Schedule");

           





            // referenceDataSchema
            modelBuilder.Entity<statusPoco>()
                .HasKey(sp => sp.statusID)
                .ToTable("userStatus", "referenceDataSchema");

            modelBuilder.Entity<countryPoco>()
                .HasKey(cp => cp.countryID)
                .ToTable("countries", "referenceDataSchema");

            modelBuilder.Entity<cityPoco>()
                .HasKey(cp => cp.cityID)
                .ToTable("cities", "referenceDataSchema");

            modelBuilder.Entity<statePoco>()
                .HasKey(sp => sp.stateID)
                .ToTable("states", "referenceDataSchema");







            //Additional colomn Properties 
            modelBuilder.Entity<userPoco>()
                .Property(up => up.emailAddress)
                .HasMaxLength(450);

            modelBuilder.Entity<userPoco>()
                .HasIndex(up => up.emailAddress)
                .IsUnique();

 


            //Constraints decleration
            modelBuilder.Entity<userPoco>()
                .HasMany(user => user.userCredentialsListNavigation)
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



            modelBuilder.Entity<userContactDetailsPoco>()
                .HasOptional(ucdp => ucdp.cityNavigation)
                .WithMany(cp => cp.userContactDetailNavigation)
                .HasForeignKey(ucdp => ucdp.cityID);

            modelBuilder.Entity<userContactDetailsPoco>()
                .HasOptional(ucdp => ucdp.stateNavigation)
                .WithMany(sp => sp.userContactDetailNavigation)
                .HasForeignKey(ucdp => ucdp.stateID);

            modelBuilder.Entity<userContactDetailsPoco>()
                .HasOptional(ucdp => ucdp.countryNavigation)
                .WithMany(cp => cp.userContactDetailNavigation)
                .HasForeignKey(ucdp => ucdp.countryID);



                //subscriptions & status
            modelBuilder.Entity<subscriptionsPoco>()
               .HasRequired(sp => sp.userCredentialsNavigation)
               .WithMany(uap => uap.subscriptionListNavigation)
               .HasForeignKey(sp => sp.userID);

            modelBuilder.Entity<statusPoco>()
                .HasMany(sp => sp.userStatusNavigation)
                .WithRequired(sp => sp.statusNavigation)
                .HasForeignKey(sp => sp.statusID);


            // schedule and classes 
            modelBuilder.Entity<classPoco>()
                .HasRequired<programPoco>(cp => cp.programNavigation)
                .WithMany(pp => pp.classesNavigation)
                .HasForeignKey(pp => pp.programID)
                .WillCascadeOnDelete();


            modelBuilder.Entity<bookingPoco>()
                .HasRequired<classPoco>(bp => bp.classNavigation)
                .WithMany(cp => cp.bookingListNavigation)
                .HasForeignKey<Guid>(cp=>cp.classID);


            modelBuilder.Entity<bookingPoco>()
                .HasRequired<userCredentialsPoco>(bp => bp.userNavigation)
                .WithMany(up => up.bookingListNavigation)
                .HasForeignKey<Guid>(bp => bp.UserID)
                .WillCascadeOnDelete(true);

                

            //modelBuilder.Entity<classPoco>()
            //   .HasMany<userCredentialsPoco>(cp => cp.userListNaviagation)
            //   .WithMany(ucp => ucp.classesListNavigation)
            //   .Map(m =>
            //   {
            //       m.ToTable("usersRegisteredForClass", "Schedule");

            //   });


            base.OnModelCreating(modelBuilder);
            Console.WriteLine("\n\n Model Creation Method Ending. Mapping Completed \n\n");
        }


        public virtual DbSet<userPoco> userDBSetRecord { get; set; }
        public virtual DbSet<userCredentialsPoco> userCredentialsDBSetRecord { get; set; }
        public virtual DbSet<userContactDetailsPoco> userContactDetailDBSetRecord { get; set; }
        public virtual DbSet<cityPoco> cityDBSetRecord { get; set; }
        public virtual DbSet<countryPoco> countryDBSetRecord { get; set; }
        public virtual DbSet<medicalRecordsPoco> medicalRecordsDBSetRecord { get; set; }
        public virtual DbSet<statePoco> stateDBSetRecord { get; set; }
        public virtual DbSet<statusPoco> statusDBSetRecord { get; set; }
        public virtual DbSet<subscriptionsPoco> subscriptionDBSetRecord { get; set; }





    }
}
