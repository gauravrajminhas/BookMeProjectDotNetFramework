using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ServiceModel;
using BookMeProject;

namespace businessServices
{
    [ServiceContract]
    interface TestInterface
    {
        [OperationContract]
        void addUser(userPoco anypoco);

        [OperationContract]
        void displayUser(userPoco anypoco);

        [OperationContract]
        List<userPoco> getAllUSers();

    }
}
