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
    /// <summary>
    /// changes May-4-2020 :- making this repo non Generic and but all the interface mentho
    /// </summary>
   

    //this interface add the iDisposable interface for managing the DBContext Properly 
    public interface iRepo<pocoTypePlaceholder> : IDisposable
        where pocoTypePlaceholder : iPoco
    {


       

    }
}
