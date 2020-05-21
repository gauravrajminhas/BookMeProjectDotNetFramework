using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace BookMeProject
{
    
    public class statusPoco : iPoco
    {
        //public key 
        //foreign Key 
        
        public Guid statusID { get; set; }

        //properties 
        
        public string statusName {get;set;}


        
        public List<userStatusPoco> userStatusNavigation { get; set; }

    }
}