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
            
            SQLServerEFDataAccessCommandImplementation<iPoco> commandRepo = new SQLServerEFDataAccessCommandImplementation<iPoco>();
            SQLServerEFDataAccessQueryImplementation<iPoco> queryRepo = new SQLServerEFDataAccessQueryImplementation<iPoco>();


            //for (int i = 0; i < 10 ; i++)
            //{

                userPoco newTruncatedCustomerPoco = new userPoco
                {
                    ecifID = Guid.NewGuid(),
                    firstName = "Truncated Test User - No Contact Details",
                    lastName ="minhas",
                    ecifAlias = "login name",
                    userCredentailsListNavigation = new List<userCredentialsPoco>(),
                    medicalRecordsListNavigation = new List<medicalRecordsPoco>()
                };

                newTruncatedCustomerPoco.userCredentailsListNavigation
                    .Add(new userCredentialsPoco {
                        userID = Guid.NewGuid(),
                        password = "TestPassword1",
                        passwordSetDate = DateTime.Now,
                        producID = Guid.NewGuid(),
                        userNavigation = newTruncatedCustomerPoco,
                        //ecifID = newTruncatedCustomerPoco.ecifID
                    });

                newTruncatedCustomerPoco.medicalRecordsListNavigation
                    .Add(new medicalRecordsPoco {
                        recordID = Guid.NewGuid(),
                        documents = null,
                        usersNavigation = newTruncatedCustomerPoco,
                        //ecifID = newTruncatedCustomerPoco.ecifID
                    });

                commandRepo.add<userPoco>(newTruncatedCustomerPoco);





                userPoco minhasUser = queryRepo.GetSingle<userPoco>(
                    cus => cus.lastName == "minhas", 
                    cus => cus.userCredentailsListNavigation, 
                    cus => cus.userContactDetailsNavigation);



            if (minhasUser.userContactDetailsNavigation != null)
                minhasUser.userContactDetailsNavigation.emmergencyContactDetails = 000000000;
            else
                minhasUser.userContactDetailsNavigation = new userContactDetailsPoco
                {
                    mobile = 9999999999,
                    gender = "male",
                    postalCode = "Updated PostalCode",
                    userNavigation = minhasUser,
                    ecifID = minhasUser.ecifID
                };
                

            
                //minhasUser.lastName = "changed";
                commandRepo.update<userPoco>(minhasUser);

            //}

            Console.Read();

            Console.WriteLine("\n\n\n --- Terminating --- ");
            Console.Read();
        }
    }
}
