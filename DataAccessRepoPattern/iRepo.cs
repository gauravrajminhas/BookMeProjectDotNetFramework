using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BookMeProject;


namespace DataAccessRepoPattern
{

    //Defination of the iRepo Interface ! 
    // dont have to define SourcePocoTypes rite now ! 
    public interface iRepo<pocoTypePlaceholder>
        where pocoTypePlaceholder : iPoco
    {
      
      


    }
}
