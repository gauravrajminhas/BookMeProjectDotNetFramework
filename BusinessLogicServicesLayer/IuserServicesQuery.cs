using BookMeProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicServicesLayer
{
    [ServiceContract]
    interface IuserServicesQuery
    {
        [OperationContract]
        bool doesUserExist(string first, string last, string email);

        [OperationContract]
        userPoco getClient(string emailAddress);

        [OperationContract]
        List<userPoco> getAllClient();

        [OperationContract]
        userPoco getCompleteUserSnapshot(string emailAddress);
    }
}
