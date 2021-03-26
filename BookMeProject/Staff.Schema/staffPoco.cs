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
        public virtual Guid? cityID { get; set; }   
        public virtual Guid? countryID { get; set; }
        public virtual Guid? stateID { get; set; }




        
        //Navigation 
        public virtual cityPoco cityPocoNavigation { get; set; }
        public virtual countryPoco countryPocoNavigation { get; set; }
        public virtual statePoco statePocoNavigation { get; set; }
        public virtual List<classPoco> classPocoListNavigation { get; set; }

    }
}
