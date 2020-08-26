using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMeProject
{
    public class programPoco :commonProperties, iPoco
    {
        //public key
        public Guid programID { get; set; }

        public string programDescription { get; set; }
        public int capacity { get; set; }
        

        //navigation 
        public List<classPoco> classesNavigation { get; set; }

    }
}
