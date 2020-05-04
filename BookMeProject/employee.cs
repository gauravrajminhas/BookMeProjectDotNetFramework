using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMeProject
{
    public class employee
    {
        public Guid employeeID { get; set; }
        public string employeeName { get; set; }
        public Guid managerID { get; set; }



        // gives a 
        public employee boss { get; set; }
        public List<employee> direct { get; set; }

    }
}
