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

            modelBuilder.Entity<customer>()
                .Map( map => 
                    {
                        map.Properties(
                            customerProperties => new {
                                customerProperties.customerID,
                                customerProperties.customerName
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

            Console.WriteLine("\n\n Model Creation Method evoked. Mapping Completed \n\n");
            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<customer> customerDBSetRecord { get; set; }

    }
}
