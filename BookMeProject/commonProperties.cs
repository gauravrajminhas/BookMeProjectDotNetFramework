using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMeProject
{
    public class commonProperties : iPoco
    {
        [Timestamp]
        public byte[] timeStampCreated { get; set; }
        
    }
}
