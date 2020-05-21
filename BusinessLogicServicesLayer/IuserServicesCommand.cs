﻿using BookMeProject;
using FaultsAndExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace BusinessLogicServicesLayer
{
    /// <summary>
    /// Dont change this Service interface often else the clients will break 
    /// start adding version to the services insead of changing the services 
    /// </summary>
    [ServiceContract]
    interface IuserServicesCommand
    {
        
        [OperationContract]
        void seedTestData();

        [FaultContract(typeof (userAlreadyExistsExceptionDetails))]
        [FaultContract(typeof (userNotAddedExceptionDetails))]
        [OperationContract]
        void addUser(string first, string last, string email);


    }
}
