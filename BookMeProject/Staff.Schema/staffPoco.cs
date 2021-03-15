using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMeProject.Staff.Schema
{
    public class staffPoco : iPoco
    {
        //PrimaryKey 
        public Guid ecifID  { get; set; }
        public string firstname { get; set; }
        public string lastName { get; set; }

        public string emailAddress { get; set; }
        public string homePhone { get; set; }
        public string mobile { get; set; }

        public bool? independentContractor { get; set; }
        public bool? canTeachClass { get; set; }

        public  byte[] image { get; set; }







        //foreigh keys 
        public Guid? cityID { get; set; }   
        public Guid? countryID { get; set; }
        public Guid? stateID { get; set; }




        
        //Navigation 
        public cityPoco cityPocoNavigation { get; set; }
        public countryPoco countryPocoNavigation { get; set; }
        public statePoco statePocoNavigation { get; set; }
        public List<classPoco> classPocoListNavigation { get; set; }

    }
}
