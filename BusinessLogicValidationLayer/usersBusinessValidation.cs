using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using BookMeProject;
using DataAccessEFGenericRepo;
using FaultsAndExceptions;

namespace BusinessLogicValidationLayer
{
    public class usersBusinessValidation
    {
        SQLServerEFDataAccessCommandImplementation<iPoco> commandObject;
        SQLServerEFDataAccessQueryImplementation<iPoco> queryObject; 
        public usersBusinessValidation()
        {
            //TODO :- add DI/IOC controler here 
            commandObject = new SQLServerEFDataAccessCommandImplementation<iPoco>();
            queryObject = new SQLServerEFDataAccessQueryImplementation<iPoco>();
        }

        public void addUser (string first, string last, string emailID)
        {

            // Validate If email Address is blank
            if (emailID==null)
            {
                throw new FaultException<missingUserEmailDetails>(
                    new missingUserEmailDetails {
                        errorMsg ="emailID set as "+emailID,
                        errorCode =2
                    }, "EmailID not set Correctly");
            }


            // Validate If user Exists 
            if (doesUserExist(first, last, emailID))
            {
                throw new FaultException<userAlreadyExistsExceptionDetails>(
                    new userAlreadyExistsExceptionDetails { 
                        errorMsg= "Custom Application Exception:- User Already Exists",
                        errorCode=1
                        }, 
                    "Custom Application Exception:- User Already Exists, Check the inner Exception");
            }
            else
            {
                commandObject.add<userPoco>(new userPoco{
                    ecifID = Guid.NewGuid(),
                    firstName = first,
                    lastName = last,
                    emailAddress = emailID
                });
            }
        }

        public bool doesUserExist(string firstname, string last, string emailID)
        {
            var result = queryObject.GetSingle<userPoco>(user => (user.firstName == firstname && user.lastName == last && user.emailAddress == emailID));
            if (result == null)
                return false;
            else
                return true;
        }




        // User Query
        public List<userPoco> getAllUser()
        {
            return queryObject.GetAll<userPoco>();
        }

        public userPoco getUser(string emailID)
        {
            return queryObject.GetSingle<userPoco>(up=>up.emailAddress== emailID);
        }

        public userPoco getCompletUserProfile(string emailID)
        {
            return queryObject
                .GetSingle<userPoco>(
                    up => up.emailAddress == emailID,
                    up=> up.userContactDetailsNavigation,
                    up=>up.medicalRecordsListNavigation,
                    up=>up.userAccessListNavigation
                    );
        }


    }
}
