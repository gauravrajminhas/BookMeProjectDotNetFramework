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
        
        public Guid userID { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string emailAddress { get; set; }


        public userContactDetailsPoco userContactDetailsNavigation { get; set; }
        public userCredentialsPoco userCredentailsNavigation { get; set; }


    }
}
