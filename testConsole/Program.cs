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
            SQLServerEFDataAccessCommandImplementation<iPoco> commandRepo = new SQLServerEFDataAccessCommandImplementation<iPoco>();
            SQLServerEFDataAccessQueryImplementation<iPoco> queryRepo = new SQLServerEFDataAccessQueryImplementation<iPoco>();

            //seedMockData.seedMore();

            new testClass().doSomething();


            



            List<customer> customers = queryRepo.GetAll<customer>();
            foreach (customer cust in customers)
            {
                Console.WriteLine(cust.customerName+"\t"+cust.emailAddress);
            }
            


            //objRef.delete<center>(c => c.centerName == "Bangalore Indiranagar");

            List<center> centerList = queryRepo.GetAll<center>();
            foreach (center center in centerList)
            {
                Console.WriteLine(center.centerID + "\t " + center.centerName );
            }


            List<center> completedCenterList = queryRepo.GetAll<center>(c => c.centerContactDetailsNavigation);
            foreach (center center in centerList)
            {
                Console.WriteLine(center.centerID + "\t " + center.centerName + "\t "  + center.centerContactDetailsNavigation.centerAddress + "\t" + center.centerContactDetailsNavigation.centerPhone + "\t" + center.centerContactDetailsNavigation.centerImage);
            }



            
            


            Console.WriteLine("\n\n\n --- Terminating --- ");
            Console.Read();
        }
    }
}
