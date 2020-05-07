using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMeProject
{
    public class userCredentialsPoco : iPoco
    {
        
        public Guid userID { get; set; }
        public string userAlias { get; set; }
        public string password { get; set; }
        public DateTime? passwordSetDate { get; set; }


        public userPoco userNavigation { get; set; }
        



    }
}
