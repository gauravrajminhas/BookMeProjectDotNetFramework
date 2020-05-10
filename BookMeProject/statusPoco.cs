using System;

namespace BookMeProject
{
    public class statusPoco : iPoco
    {
        //public key 
        //foreign Key 
        public Guid userID { get; set; }


        //properties 
        public string statusName {get;set;}

    }
}