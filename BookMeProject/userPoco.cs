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
    public class userPoco : iPoco
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
        [DataMember(IsRequired =true)]
        public string emailAddress { get; set; }
        [DataMember]
        public string ecifAlias { get; set; }

        //navigation
        [DataMember]
        public virtual userContactDetailsPoco userContactDetailsNavigation { get; set; }

        //one-to-many
        [DataMember]
        public virtual ICollection<userAccessPoco> userAccessListNavigation { get; set; }
        [DataMember]
        public virtual ICollection<medicalRecordsPoco> medicalRecordsListNavigation { get; set; }

    }
}
