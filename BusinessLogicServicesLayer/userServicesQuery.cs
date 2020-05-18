using BookMeProject;
using BusinessLogicValidationLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicServicesLayer
{
    class userServicesQuery : IuserServicesQuery
    {
        users usersObject;


        public userServicesQuery()
        {
            usersObject = new users();
        }


        

        public bool doesUserExist(string first, string last, string email)
        {
            return usersObject.doesUserExist(first, last, email);
        }

        public List<userPoco> getAllClient()
        {
            return usersObject.getAllUser();
        }

        public userPoco getClient(string emailAddress)
        {
            return usersObject.getUser(emailAddress);
        }

        public userPoco getCompleteUserSnapshot(string emailAddress)
        {
            return usersObject.getCompletUserProfile(emailAddress);
        }


    }
}
