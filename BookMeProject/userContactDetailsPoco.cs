using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BookMeProject
{  
    [DataContract]
    public class userContactDetailsPoco :iPoco
    {
        //Forign Key attribute of the employee Table
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

        

        // Navigation  
        public userPoco userNavigation { get; set; }


    }
}
