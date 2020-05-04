using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BookMeProject
{
    public class course : iPoco
    {
        public int courseID { get; set; }
        public string courseName { get; set; }

        //navigatuions properties 
        public List<student> studentsListNavigation { get; set; }
    }
}