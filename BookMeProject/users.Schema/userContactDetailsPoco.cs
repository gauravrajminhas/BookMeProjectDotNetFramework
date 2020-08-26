using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BookMeProject
{  
    
    public class userContactDetailsPoco :commonProperties, iPoco
    {

        //Public Key Attribute 
        //Forign Key attribute of the employee Table
        public Guid ecifID { get; set; }

        public Guid? cityID { get; set; }
        public Guid? stateID { get; set; }
        public Guid? countryID { get; set; }


        public DateTime? dateOfBirth { get; set; }
        public double? mobile { get; set; }
        public string gender { get; set; }
        public byte[] image { get; set; }
        
        public string emergencyContactInfoEmail { get; set; }
        public string emergencyContactInfoName { get; set; }
        public double? emergencyContactInfoPhone { get; set; }
        public string emergencyContactInfoRelationship { get; set; }



        public string postalCode { get; set; }

        // Navigation  
        public userPoco userNavigation { get; set; }
        public cityPoco cityNavigation { get; set; }
        public statePoco stateNavigation { get; set; }
        public countryPoco countryNavigation { get; set; }

    }
}
