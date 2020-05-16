using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using BookMeProject;
using BusinessLogicValidationLayer;
using FaultsAndExceptions;

namespace BusinessLogicServicesLayer
{
    class userServices : IUserServices
    {
        users usersObject;

        public userServices()
        {
            //TODO add CI/IOC  container here 
            usersObject = new users();
        }

        public void addUser(string first, string last, string email)
        {
            usersObject.addUser(first, last, email);
            
            throw new FaultException<userAlreadyExistsExceptionDetails>( new userAlreadyExistsExceptionDetails
            {
                errorCode = 500,
                errorMsg = "Daum Son...... the nigger you are trying to add, already Exists bitch !"
            }, "See the inner details of the exception bitch !!"); 
        }

        public bool doesUserExist(string first, string last, string email)
        {
            return usersObject.doesUserExist(first, last, email);
        }

        public iPoco getClient(string emailAddress)
        {
            return usersObject.getUser(emailAddress);
        }

        public void seedTestData()
        {
            new SeedDataForTesting().seedData();
        }
    }
}
