using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace BookMeProject
{
    
    public class statusPoco : iPoco
    {
        //public key 
        public Guid statusID { get; set; }

        //properties 
        public string statusName {get;set;}


        
        public List<subscriptionsPoco> userStatusNavigation { get; set; }

    }
}