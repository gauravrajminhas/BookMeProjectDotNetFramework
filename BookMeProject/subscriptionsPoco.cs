using System;
using System.Runtime.Serialization;

namespace BookMeProject
{
    
    public class subscriptionsPoco : iPoco
    {
        // Primary Key 
        public Guid subscriptionID { get; set; }


        //Foreign Key 
        public Guid statusID { get; set; }
        public Guid userID { get; set; }
        
        
        //Properties 
        public string discription { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }

        
        // Navigation 
        
        public userAccessPoco userAccessNavigation { get; set; }
        public statusPoco statusNavigation { get; set; }

    }
}