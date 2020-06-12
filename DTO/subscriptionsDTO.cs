using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    [DataContract]
    public class subscriptionsDTO
    {

        // Primary Key 
        [DataMember]
        public Guid subscriptionID { get; set; }


        ////Foreign Key 
        //[DataMember]
        //public Guid statusID { get; set; }
        //[DataMember]
        //public Guid userID { get; set; }


        //Properties 
        [DataMember]
        public string discription { get; set; }
        [DataMember]
        public DateTime startDate { get; set; }
        [DataMember]
        public DateTime endDate { get; set; }

    }
}
