using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogicValidationLayer;


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
        }

        public bool doesUserExist(string first, string last, string email)
        {
            return usersObject.doesUserExist(first, last, email);
        }

        public void seedTestData()
        {
            new SeedDataForTesting().seedData();
        }
    }
}
