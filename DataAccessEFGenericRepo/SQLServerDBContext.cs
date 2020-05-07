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
        public SQLServerDBContext() : base (@"Data Source=LAPTOP-RP1PV1SH\HUMBERBRIDGING;Initial Catalog=BookMeDBDotNetFramework ;Integrated Security=True")
        {

        }
        
        

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Console.WriteLine("\n\n Model Creation Method evoked. Mapping Started \n\n");

            modelBuilder.Entity<userPoco>()
                .HasKey(user => user.userID)
                .ToTable("users", "userSchema");

            modelBuilder.Entity<userCredentialsPoco>()
                .HasKey(userCredentials => userCredentials.userID)
                .ToTable("credentials", "userSchema");
               

            modelBuilder.Entity<userPoco>()
                .HasRequired(user => user.userCredentailsNavigation)
                .WithRequiredPrincipal(credentails => credentails.userNavigation);


            modelBuilder.Entity<userPoco>()
                .HasOptional(user => user.userContactDetailsNavigation)
                .WithRequired(contactDetails => contactDetails.userNavigation);








            base.OnModelCreating(modelBuilder);
            Console.WriteLine("\n\n Model Creation Method Ending. Mapping Completed \n\n");
        }


        public virtual DbSet<userPoco> userDBSetRecord { get; set; }
        public virtual DbSet<userCredentialsPoco> userCredentialsDBSetRecord { get; set; }
        

    }
}
