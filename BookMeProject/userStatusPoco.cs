using System;

namespace BookMeProject
{
    public class userStatusPoco : iPoco
    {

        public Guid userID { get; set; }
        public Guid StatusID { get; set; }

        // Navigation 
        public userCredentialsPoco UserCredentialsNavigationPoco { get; set; }

    }
}