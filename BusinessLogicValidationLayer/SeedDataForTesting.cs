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
                    emmergencyContactDetails = 4167082644,
                    gender = "male",
                    image = new byte[3] { 1, 2, 3 },
                    mobile = 8106504251,
                    postalCode = "postalCode",
                    userNavigation = updateTestUserPoco
                };


                updateTestUserPoco.userAccessListNavigation = new List<userAccessPoco>();
                updateTestUserPoco.userAccessListNavigation.Add(new userAccessPoco {
                    ecifID = updateTestUserPoco.ecifID,
                    password= "password",
                    passwordSetDate=DateTime.Now,
                    producID = Guid.NewGuid(),
                    status = "customer",
                    userID = Guid.NewGuid(),
                    userNavigation = updateTestUserPoco
                });
                updateTestUserPoco.userAccessListNavigation.Add(new userAccessPoco {
                    ecifID = updateTestUserPoco.ecifID,
                    password = "password",
                    passwordSetDate = DateTime.Now,
                    producID = Guid.NewGuid(),
                    status = "customer",
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



                commandRepo.update<userPoco>(updateTestUserPoco);




            }




                



            if (queryRepo.GetAll<statusPoco>()== null)
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
                    producID = Guid.NewGuid(),
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
