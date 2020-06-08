using BookMeProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    [DataContract(Namespace = "DTO")]
    public class userContactDetailsDTO : iDTO
    {
        [DataMember]
        public Guid ecifID { get; set; }

        [DataMember]
        public DateTime? dateOfBirth { get; set; }
        [DataMember]
        public double? mobile { get; set; }
        [DataMember]
        public string gender { get; set; }
        [DataMember]
        public byte[] image { get; set; }
        [DataMember]
        public double? emmergencyContactDetails { get; set; }
        [DataMember]
        public string postalCode { get; set; }



        //// Navigation  
        //[DataMember] //Doubt :- why should not be a Data member ?
        //public userDTO userNavigation { get; set; }
    }
}
