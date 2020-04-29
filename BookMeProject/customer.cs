using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMeProject
{
    public class customer : iPoco
    {
        public Guid customerID { get; set; }
        public string customerName { get; set; }
        public bool isActive { get; set; }

        //will try and entity split this via EF mapping 
        public string customerAddress { get; set; }
        public int? phoneNumber { get; set; }
        public string emailAddress { get; set; }
        public byte[] pic { get; set; }

    }
}
