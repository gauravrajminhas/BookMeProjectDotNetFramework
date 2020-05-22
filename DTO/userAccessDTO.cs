using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    [DataContract]
    public class userAccessDTO : iDTO
    {
        // primary Key 
        [DataMember]
        public Guid userID { get; set; }

        //properties 
        [DataMember]
        public Guid? producID { get; set; }
        [DataMember]
        public string password { get; set; }
        [DataMember]
        public DateTime? passwordSetDate { get; set; }

        //Foreign Keys 
        [DataMember]
        public Guid ecifID { get; set; }
        [DataMember]
        public string status { get; set; }


        //Navigation
        //public userDTO userNavigation { get; set; }
        [DataMember]
        public userStatusDTO statusNavigation { get; set; }

    }
}
