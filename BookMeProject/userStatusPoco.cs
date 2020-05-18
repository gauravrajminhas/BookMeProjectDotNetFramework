using System;
using System.Runtime.Serialization;

namespace BookMeProject
{
    [DataContract]
    public class userStatusPoco : iPoco
    {
        [DataMember]
        public Guid userID { get; set; }
        [DataMember]
        public Guid statusID { get; set; }
        [DataMember]
        public DateTime startDate { get; set; }
        [DataMember]
        public DateTime endDate { get; set; }

        // Navigation 
        public userAccessPoco userAccessNavigation { get; set; }
        public statusPoco statusNavigation { get; set; }

    }
}