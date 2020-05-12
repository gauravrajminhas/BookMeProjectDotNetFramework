﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMeProject
{
    public class userPoco : iPoco
    {
        //Primark Key
        public Guid ecifID { get; set; }

        //Properties
        public string firstName { get; set; }
        public string lastName { get; set; }
        //this is a required unique Index Property 
        public string emailAddress { get; set; }
        public string ecifAlias { get; set; }
        
        //navigation

        public virtual userContactDetailsPoco userContactDetailsNavigation { get; set; }

        //one-to-many
        public virtual ICollection <userAccessPoco> userAccessListNavigation { get; set; }
        public virtual ICollection<medicalRecordsPoco> medicalRecordsListNavigation { get; set; }

    }
}
