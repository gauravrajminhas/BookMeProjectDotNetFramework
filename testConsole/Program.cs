using BookMeProject;
using DataAccessEFGenericRepo;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            SQLServerEFDataAccessRepositoryImplementation<iPoco> objRef = new SQLServerEFDataAccessRepositoryImplementation<iPoco>();


            

            objRef.add(new customer {
                customerID = Guid.NewGuid(),
                customerName = "Test customer",
                customerAddress = "NYC",
                phoneNumber = 123456789,
                emailAddress = "gaurav.minhas@gmail.com",
                pic = new byte[0]
            });




            //this is lazy loading !!! 
            IEnumerable customerList = objRef.GetAll<customer>();
            foreach (customer cust  in customerList)
            {
                Console.WriteLine(cust.customerID+"\t "+cust.customerName + "\t " + cust.customerAddress);
            }

            Console.WriteLine("\n\n\n --- Terminating --- ");
            Console.Read();
        }
    }
}
