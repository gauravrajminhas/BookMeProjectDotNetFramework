using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    [DataContract]
    public class statusDTO : iDTO
    {
        //public key 
        //foreign Key 
        [DataMember]
        public Guid statusID { get; set; }

        //properties 
        [DataMember]
        public string statusName { get; set; }


        [DataMember]
        public List<userStatusDTO> userStatusNavigation { get; set; }
    }
}
