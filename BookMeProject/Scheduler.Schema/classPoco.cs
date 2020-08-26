using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMeProject
{
    public class classPoco : commonProperties, iPoco
    {

        // Primary Key
        public Guid classID { get; set; }


        //foreign key 
        public Guid programID { get; set; }


        public DateTime startTime { get; set; }
        public DateTime dateTime { get; set; }
        public string  notes { get; set; }


        public int? thisClassCapacity { get; set; }
        

        // navigation property
        public programPoco programNavigation { get; set; }
        public List<bookingPoco> bookingListNavigation { get; set; }



    }
}
