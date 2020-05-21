using BookMeProject;
using DTO;
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
        userDTO getClient(string emailAddress);

        [OperationContract]
        List<userDTO> getAllClient();

        [OperationContract]     
        userDTO getCompleteUserSnapshot(string emailAddress);
    }
}
