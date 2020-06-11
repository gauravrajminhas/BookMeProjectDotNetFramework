using BookMeProject;
using DataAccessEFGenericRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicValidationLayer
{
    public class SeedDataForTesting
    {
        public void seedData()
        {
            SQLServerEFDataAccessCommandImplementation<iPoco> commandRepo = new SQLServerEFDataAccessCommandImplementation<iPoco>();
            SQLServerEFDataAccessQueryImplementation<iPoco> queryRepo = new SQLServerEFDataAccessQueryImplementation<iPoco>();





            // populating the Referance Datas tables 
            if (queryRepo.GetAll<statusPoco>() == null)
            {
                commandRepo.add<statusPoco>(new statusPoco
                {
                    statusID = Guid.NewGuid(),
                    statusName = "customer",
                });

                commandRepo.add<statusPoco>(new statusPoco
                {
                    statusID = Guid.NewGuid(),
                    statusName = "Prospect",
                });

                commandRepo.add<statusPoco>(new statusPoco
                {
                    statusID = Guid.NewGuid(),
                    statusName = "staff",
                });

            }

            if (queryRepo.GetAll<countryPoco>() == null)
            {
                commandRepo.add<countryPoco>(new countryPoco {
                    countryID = Guid.NewGuid(),
                    countryName = "India"
                });
            }
            if (queryRepo.GetAll<statePoco>() == null)
            {
                commandRepo.add<statePoco>(new statePoco
                {
                    stateID = Guid.NewGuid(),
                    stateName = "Maharashtra"
                });
            }
            if (queryRepo.GetAll<cityPoco>() == null)
            {
                commandRepo.add<cityPoco>(new cityPoco
                {
                    cityID = Guid.NewGuid(),
                    cityName = "Bombay"
                });
            }










            // setup a complete test user
            if (queryRepo.GetSingle<userPoco>(up => up.emailAddress == "completeUser1@qa.com")==null)
            {
                commandRepo.add<userPoco>(
                    new userPoco {
                        ecifID=Guid.NewGuid(),
                        ecifAlias= "Test QA User",
                        emailAddress = "completeUser1@qa.com",
                        firstName = "firstName",
                        lastName ="lastName",
                        medicalRecordsListNavigation = null,
                        userAccessListNavigation = null,
                        userContactDetailsNavigation = null
                    });


                

                userPoco updateTestUserPoco = queryRepo.GetSingle<userPoco>(up=>up.emailAddress== "completeUser1@qa.com");

                updateTestUserPoco.userContactDetailsNavigation = new userContactDetailsPoco {
                    ecifID = updateTestUserPoco.ecifID,
                    dateOfBirth = DateTime.Now,
                    emergencyContactInfoPhone = 4167082644,
                    gender = "male",
                    image = new byte[3] { 1, 2, 3 },
                    mobile = 8106504251,
                    postalCode = "postalCode",
                    userNavigation = updateTestUserPoco,
                    cityNavigation = new cityPoco{
                        cityID = Guid.NewGuid(),
                        cityName = "Toronto"
                    },
                    
                    countryNavigation = new countryPoco
                    {
                        countryID =Guid.NewGuid(),
                        countryName = "Canada",  
                    },

                    stateNavigation = new statePoco
                    {
                        stateID =Guid.NewGuid(),
                        stateName ="Ontario"
                    }


                };

                
                

                updateTestUserPoco.userAccessListNavigation = new List<userAccessPoco>();
                updateTestUserPoco.userAccessListNavigation.Add(new userAccessPoco {
                    ecifID = updateTestUserPoco.ecifID,
                    password= "password",
                    passwordSetDate=DateTime.Now,
                    userID = Guid.NewGuid(),
                    aliasName = "testAccount1",
                    userNavigation = updateTestUserPoco
                });
                updateTestUserPoco.userAccessListNavigation.Add(new userAccessPoco {
                    ecifID = updateTestUserPoco.ecifID,
                    password = "password",
                    passwordSetDate = DateTime.Now,
                    userID = Guid.NewGuid(),
                    userNavigation = updateTestUserPoco
                });




                commandRepo.add<subscriptionsPoco>(
                    new subscriptionsPoco {
                        subscriptionID = Guid.NewGuid(),
                        userID = queryRepo.GetSingle<userAccessPoco>(asp => asp.aliasName == "testAccount1").userID,
                        statusID = queryRepo.GetSingle<statusPoco>(sp => sp.statusName == "customer").statusID,
                        discription = "Subscribed to Crossfit Services",
                        startDate = DateTime.Now,
                        endDate = DateTime.Now,
                        userAccessNavigation= queryRepo.GetSingle<userAccessPoco>(asp => asp.aliasName == "testAccount1"),
                        statusNavigation = queryRepo.GetSingle<statusPoco>(sp => sp.statusName == "customer")

                    });

               
                commandRepo.add<subscriptionsPoco>(
                    new subscriptionsPoco {
                        subscriptionID = Guid.NewGuid(),
                        userID = queryRepo.GetSingle<userAccessPoco>(asp => asp.aliasName == "testAccount1").userID,
                        statusID = queryRepo.GetSingle<statusPoco>(sp => sp.statusName == "customer").statusID,
                        discription = "Subscribed to weightLifting Services",
                        startDate = DateTime.Now,
                        endDate = DateTime.Now,
                        userAccessNavigation= queryRepo.GetSingle<userAccessPoco>(asp => asp.aliasName == "testAccount1"),
                        statusNavigation = queryRepo.GetSingle<statusPoco>(sp => sp.statusName == "customer")

                    });



                updateTestUserPoco.medicalRecordsListNavigation = new List<medicalRecordsPoco>();
                updateTestUserPoco.medicalRecordsListNavigation.Add( new medicalRecordsPoco {
                    documents= new byte[3] { 1, 2, 3 },
                    ecifID = updateTestUserPoco.ecifID,
                    recordID = Guid.NewGuid(),
                    usersNavigation = updateTestUserPoco
                });
                updateTestUserPoco.medicalRecordsListNavigation.Add(new medicalRecordsPoco{
                    documents = new byte[3] { 1, 2, 3 },
                    ecifID = updateTestUserPoco.ecifID,
                    recordID = Guid.NewGuid(),
                    usersNavigation = updateTestUserPoco
                });



                commandRepo.update<userPoco>(updateTestUserPoco);




            }




                


           





            for (int i = 0; i < 0 ; i++)
            {

                userPoco newTruncatedCustomerPoco = new userPoco
                {
                    ecifID = Guid.NewGuid(),
                    firstName = "Truncated Test User - No Contact Details",
                    lastName = "minhas",
                    ecifAlias = "login name",
                    emailAddress = "gaurav.minhas@gmail.com" + new Random().Next().ToString(),
                userAccessListNavigation = new List<userAccessPoco>(),
                medicalRecordsListNavigation = new List<medicalRecordsPoco>()
            };


                
            newTruncatedCustomerPoco.userAccessListNavigation
                .Add(new userAccessPoco
                {
                    userID = Guid.NewGuid(),
                    password = "TestPassword1",
                    passwordSetDate = DateTime.Now,
                    userNavigation = newTruncatedCustomerPoco,
                        //ecifID = newTruncatedCustomerPoco.ecifID
                    });

            newTruncatedCustomerPoco.medicalRecordsListNavigation
                .Add(new medicalRecordsPoco
                {
                    recordID = Guid.NewGuid(),
                    documents = null,
                    usersNavigation = newTruncatedCustomerPoco,
                        //ecifID = newTruncatedCustomerPoco.ecifID
                    });

            commandRepo.add<userPoco>(newTruncatedCustomerPoco);

            


            userPoco minhasUser = queryRepo.GetSingle<userPoco>(
                cus => cus.lastName == "minhas",
                cus => cus.userAccessListNavigation,
                cus => cus.userContactDetailsNavigation);



            if (minhasUser.userContactDetailsNavigation != null)
                minhasUser.userContactDetailsNavigation.emergencyContactInfoPhone = 000000000;
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



                var userAccessObject = queryRepo.GetSingle<userAccessPoco>(uap => uap.password == "TestPassword1");
                var statusObj = queryRepo.GetSingle<statusPoco>(sp => sp.statusName == "customer");

                //commandRepo.add<userStatusPoco>(new userStatusPoco {
                //    userAccessNavigation = userAccessObject,
                //    statusNavigation =statusObj
                //});

            }
        }
    }
}
