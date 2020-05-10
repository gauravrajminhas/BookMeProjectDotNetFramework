using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMeProject
{
    public class userContactDetailsPoco :iPoco
    {
        //Forign Key attribute of the employee Table
        public Guid ecifID { get; set; }

        
        public DateTime? dateOfBirth { get; set; }
        public double? mobile { get; set; }
        public string gender { get; set; }
        public byte[] image { get; set; }
        public double? emmergencyContactDetails { get; set; }
        public string postalCode { get; set; }

        

        // Navigation  
        public userPoco userNavigation { get; set; }


    }
}
