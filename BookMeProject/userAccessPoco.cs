using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BookMeProject
{
    [DataContract]
    public class userAccessPoco : iPoco
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
        public userPoco userNavigation { get; set; }
        public userStatusPoco statusNavigation { get; set; }



    }
}
