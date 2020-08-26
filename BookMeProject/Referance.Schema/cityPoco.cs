using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMeProject
{
    public class cityPoco : commonProperties, iPoco
    {

        //Public Key 
        public Guid cityID { get; set; }
        public string cityName { get; set; }



        //Navigation Property 
        public virtual List<userContactDetailsPoco> userContactDetailNavigation { get; set; }

    }
}
