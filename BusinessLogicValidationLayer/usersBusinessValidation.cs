using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using BookMeProject;
using DataAccessEFGenericRepo;
using DataAccessRepoPattern;
using DTO;
using FaultsAndExceptions;
using Test_MockerLibraries;

namespace BusinessLogicValidationLayer
{
    public class usersBusinessValidation : Ivalidation
    {
        iRepoCommand<iPoco> commandObject;
        iRepoQuery<iPoco> queryObject;
        
        public usersBusinessValidation()
        {
            //TODO :- add DI/IOC controler here 
            commandObject = new EFGeneric_CommandImplementation<iPoco>();
            queryObject = new EFGeneric_QueryImplementation<iPoco>();


            //mocking Test Framework 
            commandObject = new mock_EFGeneric_CommandImplementation<iPoco>();
            queryObject = new mock_EFGeneric_QueryImplementation<iPoco>();

        }


        // Validate Inputs and other business rules 
        public void addUser (string first, string last, string emailID)
        {

            // Validate If email Address is blank
            validateEmailAddress(emailID);

            // Validate If user Exists 
            isDuplicateUser(first, last, emailID);


            using (commandObject)
            {
                // Add user 
                commandObject.add<userPoco>(new userPoco
                {
                    ecifID = Guid.NewGuid(),
                    firstName = first,
                    lastName = last,
                    emailAddress = emailID
                });
            }



        }
        public bool doesUserExist(string firstName, string lastName, string emailID)
        {
            try
            {
                isDuplicateUser(firstName, lastName, emailID);
            }
            catch (Exception e)
            { 
                return false;
            }
            return true;
        }
        
        // Aux functions for Validation 
        public void isDuplicateUser(string firstName, string lastName, string emailID)
        {
            var result = queryObject.GetSingle<userPoco>(user => (user.emailAddress == emailID));
            if (result != null)
            {
                throw new FaultException<userAlreadyExistsExceptionDetails>(
                     new userAlreadyExistsExceptionDetails
                     {
                         errorMsg = "Custom Application Exception:- User Already Exists",
                         errorCode = 1
                     },
                     "Custom Application Exception:- User Already Exists, Check the inner Exception");
            }
        }
        public void validateEmailAddress(string emailID)
        {
            if (emailID == null)
            {
                throw new FaultException<missingUserEmailDetails>(
                    new missingUserEmailDetails
                    {
                        errorMsg = "emailID set as " + emailID,
                        errorCode = 2
                    }, "EmailID not set Correctly");
            }
        }

        
        //Command menthods 
        public void deleteUser(string firstName, string lastName, string emailAddress)
        {
            doesUserExist(firstName, lastName, emailAddress);
            using (commandObject)
            {
                commandObject.delete<iPoco>(getUser(emailAddress));
            }
                
        }


        // Get Methods returning Pocos and not DTOs
        public List<userPoco> getAllUser()
        {
            using (queryObject)
            {
                return queryObject.GetAll<userPoco>();
            }
                
        }
        public userPoco getUser(string emailID)
        {
            using (queryObject)
            {
                return queryObject.GetSingle<userPoco>(up => up.emailAddress == emailID);
            }
               
        }
        public userPoco getCompletUserProfile(string emailID)
        {
            using (queryObject)
            {
                return queryObject
                    .GetSingle<userPoco>(
                        up => up.emailAddress == emailID,
                        up => up.userContactDetailsNavigation,
                        up => up.medicalRecordsListNavigation,
                        up => up.userCredentialsListNavigation
                        );
            }
                
        }

        public List<subscriptionsPoco> getAllUserSubscriptionsPocos(string emailAddress)
        {
            List<subscriptionsPoco> resultList = new List<subscriptionsPoco>();
            using (queryObject)
            {
                userPoco userECIFPoco = queryObject.GetSingle<userPoco>(up => up.emailAddress == emailAddress, up => up.userCredentialsListNavigation.Select(ucn => ucn.subscriptionListNavigation));

                if (userECIFPoco != null)
                {

                    foreach (userCredentialsPoco user in userECIFPoco.userCredentialsListNavigation)
                    {

                        if (user.subscriptionListNavigation.Count != 0)
                        {
                            foreach (subscriptionsPoco subscription in user.subscriptionListNavigation)
                            {
                                resultList.Add(subscription);
                            }
                        }
                    }
                    return resultList;
                }
                else
                {
                    throw new FaultException<noClientFoundException>(new noClientFoundException(), "user not found");
                }
            }
                
        }


    }



    
}
