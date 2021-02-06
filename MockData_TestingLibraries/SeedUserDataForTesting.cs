using BookMeProject;
using Castle.Windsor;
using DataAccessEFGenericRepo;
using DataAccessRepoPattern;
using Test_Poco_seedData_mockData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Poco_seedData_mockData
{
    public class SeedUserDataForTesting : BaseIOCDependencyClass, IMockDataTestingValidation
    {

        
       
        
        public SeedUserDataForTesting(iRepoCommand<iPoco> commandRepoInjection, iRepoQuery<iPoco> queryRepoInjection): base(commandRepoInjection, queryRepoInjection)
        {           
        }

        

        public void seedData()
        {
            
            // populating the Referance Datas tables 
            if (queryObjectReferace.GetAll<statusPoco>().Count == 0)
            {
                commandObjectReferance.add<statusPoco>(new statusPoco
                {
                    statusID = Guid.NewGuid(),
                    statusName = "customer",
                });

                commandObjectReferance.add<statusPoco>(new statusPoco
                {
                    statusID = Guid.NewGuid(),
                    statusName = "Prospect",
                });

                commandObjectReferance.add<statusPoco>(new statusPoco
                {
                    statusID = Guid.NewGuid(),
                    statusName = "staff",
                });

            }

            if (queryObjectReferace.GetAll<countryPoco>().Count == 0)
            {
                commandObjectReferance.add<countryPoco>(new countryPoco {
                    countryID = Guid.NewGuid(),
                    countryName = "India"
                });
            }
            if (queryObjectReferace.GetAll<statePoco>().Count == 0)
            {
                commandObjectReferance.add<statePoco>(new statePoco
                {
                    stateID = Guid.NewGuid(),
                    stateName = "Maharashtra"
                });
            }
            if (queryObjectReferace.GetAll<cityPoco>().Count == 0)
            {
                commandObjectReferance.add<cityPoco>(new cityPoco
                {
                    cityID = Guid.NewGuid(),
                    cityName = "Bombay"
                });
            }


            // setup a complete test user
            if (queryObjectReferace.GetSingle<userPoco>(up => up.emailAddress == "completeUser1@qa.com")==null)
            {
                commandObjectReferance.add<userPoco>(
                    new userPoco {
                        ecifID = Guid.NewGuid(),
                        ecifAlias = "Test QA User",
                        emailAddress = "completeUser1@qa.com",
                        firstName = "firstName",
                        lastName = "lastName",
                        medicalRecordsListNavigation = null,
                        userCredentialsListNavigation = null,
                        userContactDetailsNavigation = null
                    });


                

                userPoco updateTestUserPoco = queryObjectReferace.GetSingle<userPoco>(up=>up.emailAddress== "completeUser1@qa.com");

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

                
                

                updateTestUserPoco.userCredentialsListNavigation = new List<userCredentialsPoco>();
                updateTestUserPoco.userCredentialsListNavigation.Add(new userCredentialsPoco {
                    ecifID = updateTestUserPoco.ecifID,
                    password= "password",
                    passwordSetDate=DateTime.Now,
                    userID = Guid.NewGuid(),
                    aliasName = "testAccount1",
                    userNavigation = updateTestUserPoco
                });
                updateTestUserPoco.userCredentialsListNavigation.Add(new userCredentialsPoco {
                    ecifID = updateTestUserPoco.ecifID,
                    password = "password",
                    passwordSetDate = DateTime.Now,
                    userID = Guid.NewGuid(),
                    userNavigation = updateTestUserPoco
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



                commandObjectReferance.update<userPoco>(updateTestUserPoco);



                commandObjectReferance.add<subscriptionsPoco>(
                    new subscriptionsPoco
                    {
                        subscriptionID = Guid.NewGuid(),

                        userID = queryObjectReferace.GetSingle<userCredentialsPoco>(asp => asp.aliasName == "testAccount1").userID,
                        statusID = queryObjectReferace.GetSingle<statusPoco>(sp => sp.statusName == "customer").statusID,
                        discription = "Subscribed to Crossfit Services",
                        startDate = DateTime.Now,
                        endDate = DateTime.Now,
                        userCredentialsNavigation = queryObjectReferace.GetSingle<userCredentialsPoco>(asp => asp.aliasName == "testAccount1"),
                        statusNavigation = queryObjectReferace.GetSingle<statusPoco>(sp => sp.statusName == "customer")

                    });

                commandObjectReferance.add<subscriptionsPoco>(
                    new subscriptionsPoco
                    {
                        subscriptionID = Guid.NewGuid(),
                        userID = queryObjectReferace.GetSingle<userCredentialsPoco>(asp => asp.aliasName == "testAccount1").userID,
                        statusID = queryObjectReferace.GetSingle<statusPoco>(sp => sp.statusName == "customer").statusID,
                        discription = "Subscribed to weightLifting Services",
                        startDate = DateTime.Now,
                        endDate = DateTime.Now,
                        userCredentialsNavigation = queryObjectReferace.GetSingle<userCredentialsPoco>(asp => asp.aliasName == "testAccount1"),
                        statusNavigation = queryObjectReferace.GetSingle<statusPoco>(sp => sp.statusName == "customer")

                    });


            }

            // Other Users
            for (int i = 0; i < 30 ; i++)
            {

                userPoco newTruncatedCustomerPoco = new userPoco
                {
                    ecifID = Guid.NewGuid(),
                    firstName = "Truncated Test User - No Contact Details",
                    lastName = "minhas",
                    ecifAlias = "login name",
                    emailAddress = "gaurav.minhas@gmail.com" + i.ToString(),
                    userCredentialsListNavigation = new List<userCredentialsPoco>(),
                medicalRecordsListNavigation = new List<medicalRecordsPoco>()
            };


                
            newTruncatedCustomerPoco.userCredentialsListNavigation
                .Add(new userCredentialsPoco
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

                commandObjectReferance.add<userPoco>(newTruncatedCustomerPoco);

            


            userPoco minhasUser = queryObjectReferace.GetSingle<userPoco>(
                cus => cus.lastName == "minhas",
                cus => cus.userCredentialsListNavigation,
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
                commandObjectReferance.update<userPoco>(minhasUser);

           

                var userAccessObject = queryObjectReferace.GetSingle<userCredentialsPoco>(uap => uap.password == "TestPassword1");
                var statusObj = queryObjectReferace.GetSingle<statusPoco>(sp => sp.statusName == "customer");

                //commandRepo.add<userStatusPoco>(new userStatusPoco {
                //    userAccessNavigation = userAccessObject,
                //    statusNavigation =statusObj
                //});

            }


        }
    }
}
