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

            objRef.add(new center
            {
                centerID = Guid.NewGuid(),
                centerName = "Bangalore Indiranagar",
                centerContactDetailsNavigation = new centerContactDetails
                {
                    centerImage = new byte[0],
                    centerAddress = "abc",
                    centerPhone = 9000100

                }
            });

            List<center> centerList = objRef.GetAll<center>();
            List<center> completedCenterList =  objRef.GetAllWithProp<center>(c=>c.centerContactDetailsNavigation);

           

            Console.WriteLine("\n\n\n --- Terminating --- ");
            Console.Read();



            objRef.add(new customer {
                customerID = Guid.NewGuid(),
                customerName = "Test customer",
                customerAddress = "NYC",
                phoneNumber = 123456789,
                emailAddress = "gaurav.minhas@gmail.com",
                pic = new byte[0]
            });



            objRef.delete<customer>(pocp => pocp.customerName == "Test customer");
            objRef.delete<center>(cent => cent.centerName == "abc");
            objRef.delete((center c) => c.centerName == "abc" );




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
