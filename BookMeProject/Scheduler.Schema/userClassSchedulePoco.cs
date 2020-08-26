using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMeProject
{
    public class userClassSchedulePoco : commonProperties, iPoco
    {
        //PrimaryKey 
        public Guid scheduleID { get; set; }


        // Foreign Key 
        public Guid userID { get; set; }
        public Guid classID { get; set; }



        //Navigation Property 
        public userPoco userNavigation { get; set; }
        public classPoco classNavigation { get; set; }

    }
}
