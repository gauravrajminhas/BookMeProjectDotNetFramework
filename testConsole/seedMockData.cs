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
    static class seedMockData
    {

        public static void seedMore()
        {
            SQLServerEFDataAccessCommandImplementation<iPoco> commandRepo = new SQLServerEFDataAccessCommandImplementation<iPoco>();
            SQLServerEFDataAccessQueryImplementation<iPoco> queryRepo = new SQLServerEFDataAccessQueryImplementation<iPoco>();
            commandRepo.add(new center
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

            commandRepo.add(new center
            {
                centerID = Guid.NewGuid(),
                centerName = "Kolkatta Ft. victoria",
                centerContactDetailsNavigation = new centerContactDetails
                {
                    centerImage = new byte[0],
                    centerAddress = "sealda",
                    centerPhone = 9000100

                }
            });


            commandRepo.add(new customer
            {
                customerID = Guid.NewGuid(),
                customerName = "Test customer",
                customerAddress = "NYC",
                phoneNumber = 123456789,
                emailAddress = "gaurav.minhas@gmail.com",
                pic = new byte[0]
            });

            commandRepo.add(new customer
            {
                customerID = Guid.NewGuid(),
                customerName = "Crossfit customer",
                customerAddress = "NYC",
                phoneNumber = 123456789,
                emailAddress = "gaurav.minhas@gmail.com",
                pic = new byte[0]
            });




            //objRef.delete<customer>(pocp => pocp.customerName == "Test customer");
            //objRef.delete<center>(cent => cent.centerName == "abc");
            //objRef.delete((center c) => c.centerName == "abc");

            //this is lazy loading !!! 
            IEnumerable customerList = queryRepo.GetAll<customer>();
            foreach (customer cust in customerList)
            {
                Console.WriteLine(cust.customerID + "\t " + cust.customerName + "\t " + cust.customerAddress);
            }



        }


    }
}
