﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMeProject
{
    public class statePoco : iPoco
    {

        //Public Key 
        public Guid stateID { get; set; }
        public string stateName { get; set; }



        //Navigation Property 
        public virtual List<userContactDetailsPoco> userContactDetailNavigation { get; set; }

    }
}
