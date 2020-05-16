using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookMeProject;
using DataAccessEFGenericRepo;

namespace BusinessLogicValidationLayer
{
    public class users
    {
        SQLServerEFDataAccessCommandImplementation<iPoco> commandObject;
        SQLServerEFDataAccessQueryImplementation<iPoco> queryObject; 
        public users()
        {
            //TODO :- add DI/IOC controler here 
            commandObject = new SQLServerEFDataAccessCommandImplementation<iPoco>();
            queryObject = new SQLServerEFDataAccessQueryImplementation<iPoco>();
        }



        public void addUser (string first, string last, string emailID)
        {
            if (doesUserExist(first, last,emailID))
            {
                throw new Exception ("user Already Exists");
            }
            else
            {
                commandObject.add<userPoco>(new userPoco
                {
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


        public iPoco getUser(string emailID)
        {
            return queryObject.GetSingle<userPoco>(up => up.emailAddress == emailID);
        }

    }
}
