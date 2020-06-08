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
    public class userDTO : iDTO
    {

        //Primark Key
        [DataMember(IsRequired = true)]
        public Guid ecifID { get; set; }

        //Properties
        [DataMember]
        public string firstName { get; set; }
        [DataMember]
        public string lastName { get; set; }
        //this is a required unique Index Property 
        [DataMember(IsRequired = true)]
        public string emailAddress { get; set; }
        [DataMember]
        public string ecifAlias { get; set; }

        //navigation
        [DataMember]
        public virtual userContactDetailsDTO userContactDetailsNavigation { get; set; }

        //one-to-many
        [DataMember]
        public virtual List<userAccessDTO> userAccessListNavigation { get; set; }
        [DataMember]
        public virtual List<medicalRecordsDTO> medicalRecordsListNavigation { get; set; }

    }
}

