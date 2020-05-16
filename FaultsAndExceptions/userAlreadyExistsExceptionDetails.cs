using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FaultsAndExceptions
{
    // this is not a Exception Type but rather a ExceptionDetails 
    [DataContract]
    public class userAlreadyExistsExceptionDetails 
    {
        [DataMember]
        public string errorMsg { get; set; }

        [DataMember]
        public int errorCode { get; set; }
    }
}
