using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMeProject
{
    public class bookingPoco : commonProperties, iPoco
    {
        //public Key 
        public Guid bookingID { get; set; }

        //Foreign Keys 
        public Guid classID { get; set; }
        public Guid UserID { get; set; }


        public bool isWaitlisted { get; set; }

        //Navigation Propeperties 
        public userCredentialsPoco userNavigation { get; set; }
        public classPoco classNavigation { get; set; }

        
    }
}
