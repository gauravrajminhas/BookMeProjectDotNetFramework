using System;
using System.Collections.Generic;
using System.Linq;
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
      
        void add(params pocoTypePlaceholder[] pocosToBeAdded);
        void update(params pocoTypePlaceholder[] pocosToBeUpdated);


        void delete(params pocoTypePlaceholder[] pocosTobeDeleted);

        pocoTypePlaceholder GetSingle(Func<pocoTypePlaceholder, bool> where);


        // how come this is not throwing a unknowtype Issue ? 
        // difference Of ParametersInputTypes and function Type 
        List<anotherPocoTypePlaceholder> GetAll<anotherPocoTypePlaceholder>()
            where anotherPocoTypePlaceholder: class, iPoco ;




    }
}
