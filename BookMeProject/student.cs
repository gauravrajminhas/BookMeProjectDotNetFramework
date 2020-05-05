using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMeProject 
{
    public class student : iPoco
    {
        public Guid studentID { get; set; }
        public string studentName { get; set; }


        // Navigation 
        public ICollection<course> courseListNavigation { get; set; }


    }
}
