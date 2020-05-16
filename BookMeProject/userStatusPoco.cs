using System;

namespace BookMeProject
{
    public class userStatusPoco : iPoco
    {

        public Guid userID { get; set; }
        public Guid statusID { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }

        // Navigation 
        public userAccessPoco userAccessNavigation { get; set; }
        public statusPoco statusNavigation { get; set; }

    }
}