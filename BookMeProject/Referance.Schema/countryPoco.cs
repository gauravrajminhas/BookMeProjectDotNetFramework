using BookMeProject.Staff.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMeProject
{
    public class countryPoco : commonProperties, iPoco
    {

        //Public Key 
        public Guid countryID { get; set; }
        public string countryName { get; set; }


        //Navigation Property
        public virtual List<userContactDetailsPoco> userContactDetailNavigation { get; set; }
        public virtual List<staffPoco> staffPocoListNavigation { get; set; }


    }
}
