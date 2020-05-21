using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FaultsAndExceptions
{
    [DataContract]
    public class missingUserEmailDetails
    {
        [DataMember]
        public string errorMsg { get; set; }

        [DataMember]
        public int errorCode { get; set; }
    }
}
