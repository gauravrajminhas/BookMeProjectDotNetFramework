using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BookMeProject
{
    
    public class userCredentialsPoco : iPoco
    {
        // primary Key 
        
        public Guid userID { get; set; }
 
        //Foreign Keys 
        public Guid ecifID { get; set; }
        //public string status { get; set; }

        
        //properties 
        //public Guid? producID { get; set; }
        public string password { get; set; }
        public DateTime? passwordSetDate { get; set; }
        public string aliasName { get; set; }
        


        //Navigation
        
        public userPoco userNavigation { get; set; }
        
        public List<subscriptionsPoco> subscriptionListNavigation { get; set; }



    }
}
