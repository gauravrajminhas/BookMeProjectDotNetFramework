using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using FaultsAndExceptions;

namespace BusinessLogicServicesLayer
{
    [ServiceContract(SessionMode = SessionMode.Required)]
    interface iTest
    {
        [OperationContract]
        [FaultContract(typeof (missingUserEmailDetails))]
        void testException();


        [OperationContract]
        [FaultContract(typeof(noClientFoundException))]
        void testNoClientfoundException();



        [OperationContract]
        void add(string text);

        [OperationContract]
        string get(int position);

        [OperationContract]
        void seedTestData();

    }
}
