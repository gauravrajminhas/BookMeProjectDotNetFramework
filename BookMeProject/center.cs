using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMeProject
{
    public class center : iPoco
    {
        public Guid centerID { get; set; }
        public string centerName { get; set; }


        //navigation 
        public virtual centerContactDetails centerContactDetailsNavigation { get; set; }

    }
}
