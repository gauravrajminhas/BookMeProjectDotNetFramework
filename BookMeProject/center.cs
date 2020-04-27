using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BookMeProject
{
    public class center : iPoco
    {
        [Key]
        public Guid centerID { get; set; }
        public string centerName { get; set; }

    }
}
