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
    [ServiceBehavior(MaxItemsInObjectGraph = 2147483646)]
    class userServicesCommand : IuserServicesCommand
    {
        usersBusinessValidation usersObject;

        public userServicesCommand()
        {
            //TODO add CI/IOC  container here 
            usersObject = new usersBusinessValidation();
        }

        public void addUser(string first, string last, string email)
        {
            usersObject.addUser(first, last, email);

            //throw new FaultException<userAlreadyExistsExceptionDetails>( new userAlreadyExistsExceptionDetails
            //{
            //    errorCode = 500,
            //    errorMsg = "Daum Son...... the nigger you are trying to add, already Exists bitch !"
            //}, "See the inner details of the exception bitch !!"); 
        }

        public void seedTestData()
        {
            new SeedDataForTesting().seedData();
        }
    }
}
