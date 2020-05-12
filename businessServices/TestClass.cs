using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookMeProject;
using DataAccessEFGenericRepo;

namespace businessServices
{
    class TestClass : TestInterface
    {
        private SQLServerEFDataAccessCommandImplementation<iPoco> commandObject;
        private SQLServerEFDataAccessQueryImplementation<iPoco> queryObject;

        public TestClass()
        {
            commandObject = new SQLServerEFDataAccessCommandImplementation<iPoco>();
            queryObject = new SQLServerEFDataAccessQueryImplementation<iPoco>();
        }
        public void addUser(userPoco userToBeAdded)
        {
            SQLServerEFDataAccessCommandImplementation<iPoco> commandObject = new SQLServerEFDataAccessCommandImplementation<iPoco>();
            commandObject.add<userPoco>(userToBeAdded);
        }

        public void displayUser(userPoco anypoco)
        {
            throw new NotImplementedException();
        }

        public List<userPoco> getAllUSers()
        {
            var results = queryObject.GetAll<userPoco>();
            foreach (var users in results)
            {
                Console.WriteLine(users.ecifID);
            }
            return results;
        }
    }
}
