using BookMeProject;
using DataAccessEFGenericRepo;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace testConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Read();
            SQLServerEFDataAccessCommandImplementation<iPoco> commandRepo = new SQLServerEFDataAccessCommandImplementation<iPoco>();
            SQLServerEFDataAccessQueryImplementation<iPoco> queryRepo = new SQLServerEFDataAccessQueryImplementation<iPoco>();


            userPoco newTruncatedCustomerPoco = new userPoco {
                userID = Guid.NewGuid(),
                firstName = "rahul",
                //userContactDetailsNavigation = new userContactDetailsPoco
                //{
                //    dateOfBirth = DateTime.Now,
                //    emmergencyContactDetails = 9000102154,
                //    gender = "male",
                //    postalCode = "K2a1z5"
                //},
                userCredentailsNavigation = new userCredentialsPoco
                {
                    password = "TestPassword1"
                }
                
                
            };


            //customerPoco newOptCustomerPoco = new customerPoco
            //{
            //    customerID = Guid.NewGuid(),
            //    firstName = "OptionLoginUser",
            //    CustomerContactDetailsNavigation = new customerContactDetailsPoco
            //    {
            //        dateOfBirth = DateTime.Now,
            //        emmergencyContactDetails = 23423412,
            //        gender = "male",
            //        postalCode = "500043"
            //    }
                

            //};






            commandRepo.add<userPoco>(newTruncatedCustomerPoco);
            //commandRepo.add<customerPoco>(newOptCustomerPoco);
            //customerPoco gauravTruncated = queryRepo.GetSingle<customerPoco>(cus => cus.firstName == "gaurav");
            userPoco gauravTruncated = queryRepo.GetSingle<userPoco>(cus => cus.firstName == "rahul", cus => cus.userCredentailsNavigation,cus=>cus.userContactDetailsNavigation);

            gauravTruncated.lastName = "minhas";
            gauravTruncated.firstName = "minhas";
            //gauravTruncated.CustomerContactDetailsNavigation.emmergencyContactDetails = 9966929340;
            commandRepo.update<userPoco>(gauravTruncated);








            userPoco newCustomerPoco = new userPoco
            {
                userID = Guid.NewGuid(),
                firstName = "rahul",
                userContactDetailsNavigation = new userContactDetailsPoco
                {
                    dateOfBirth = DateTime.Now,
                    emmergencyContactDetails = 9000102154,
                    gender = "male",
                    postalCode = "K2a1z5"
                },
                userCredentailsNavigation = new userCredentialsPoco
                {
                    password = "TestPassword1"
                }


            };


            commandRepo.add<userPoco>(newCustomerPoco);
            //commandRepo.add<customerPoco>(newOptCustomerPoco);
            //customerPoco gauravTruncated = queryRepo.GetSingle<customerPoco>(cus => cus.firstName == "gaurav");
            userPoco gauravNonTruncated = queryRepo.GetSingle<userPoco>(cus => cus.firstName == "rahul", cus => cus.userCredentailsNavigation, cus => cus.userContactDetailsNavigation);

            //gauravTruncated.lastName = "minhas";
            gauravNonTruncated.userContactDetailsNavigation.emmergencyContactDetails = 9966929340;
            commandRepo.update<userPoco>(gauravNonTruncated);
            //seedMockData.seedMore();

            //new testClass().doSomething();



            Console.WriteLine("\n\n\n --- Terminating --- ");
            Console.Read();
        }
    }
}
