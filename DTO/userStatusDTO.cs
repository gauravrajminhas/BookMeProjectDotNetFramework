using BookMeProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    [DataContract]
    public class userStatusDTO : iDTO
    {
        [DataMember]
        public Guid userID { get; set; }
        [DataMember]
        public Guid statusID { get; set; }
        [DataMember]
        public DateTime startDate { get; set; }
        [DataMember]
        public DateTime endDate { get; set; }

        //// Navigation 
        //[DataMember]
        //public userAccessDTO userAccessNavigation { get; set; }

        //[DataMember]
        //public statusDTO statusNavigation { get; set; }
    }
}
