using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMeProject
{
    public class centerContactDetails : iPoco
    {
        public Guid centerID { get; set; }
        public string  centerAddress { get; set; }
        public int? centerPhone { get; set; }
        public byte[] centerImage { get; set; }
       


        //navigation 
        public virtual center centerNavigation { get; set; } 

    }
}
