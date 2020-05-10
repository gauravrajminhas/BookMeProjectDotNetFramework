using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMeProject
{
    public class userPoco : iPoco
    {
        //Primark Key
        public Guid ecifID { get; set; }

        //Properties
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string emailAddress { get; set; }
        public string ecifAlias { get; set; }
        
        //navigation

        public virtual userContactDetailsPoco userContactDetailsNavigation { get; set; }

        //one-to-many
        public virtual ICollection <userCredentialsPoco> userCredentailsListNavigation { get; set; }
        public virtual ICollection<medicalRecordsPoco> medicalRecordsListNavigation { get; set; }

    }
}
