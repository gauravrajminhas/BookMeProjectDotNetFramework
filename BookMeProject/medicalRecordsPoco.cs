﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BookMeProject
{
    
    public class medicalRecordsPoco : commonProperties, iPoco
    {
        
        public Guid recordID { get; set; }
        
        public Guid ecifID { get; set; }
        
        public byte[] documents {get;set;}


        
        public userPoco usersNavigation { get;  set; }
    }
}
