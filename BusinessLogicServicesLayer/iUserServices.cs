using BookMeProject;
using FaultsAndExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace BusinessLogicServicesLayer
{
    [ServiceContract(Name = "BookMeUserServices", Namespace = "bookMeNameSpace")]
    interface IUserServices
    {
        
        [OperationContract (IsOneWay = true)]
        void seedTestData();

        [FaultContract(typeof (userAlreadyExistsExceptionDetails))]
        [FaultContract(typeof (userNotAddedExceptionDetails))]
        [OperationContract]
        void addUser(string first, string last, string email);


        [OperationContract]
        bool doesUserExist(string first, string last, string email);

        [OperationContract]
        iPoco getClient(string emailAddress);
        

    }
}
