using BookMeProject;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using FaultsAndExceptions;
using System.Runtime.Serialization;

namespace BusinessLogicServicesLayer
{
    [ServiceContract(Namespace = "userNameSpace")]
    interface IuserServicesQuery
    {
        [OperationContract]
        bool doesUserExist(string first, string last, string email);

        [OperationContract]
        [FaultContract(typeof(noClientFoundException))]
        userDTO getUser(string emailAddress);

        [OperationContract]
        List<userDTO> getAllClient();

        [OperationContract]
        userDTO getCompleteUserSnapshot(string emailAddress);


        [OperationContract]
        List<subscriptionsDTO> getAllUserSubscriptions(string emailAddress);



    }

}