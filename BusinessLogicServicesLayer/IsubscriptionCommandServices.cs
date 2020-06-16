using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicServicesLayer
{
    [ServiceContract]
    interface IsubscriptionCommandServices
    {
        [OperationContract]
        bool addUserSubscription(string userid, DateTime startDate, DateTime endDate);
    }
}
