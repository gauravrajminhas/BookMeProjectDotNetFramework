using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace BusinessLogicServicesLayer
{
    [ServiceContract]
    interface IUserServices
    {
        [OperationContract]
        void seedTestData();

        [OperationContract]
        void addUser(string first, string last, string email);

        [OperationContract]
        bool doesUserExist(string first, string last, string email);

    }
}
