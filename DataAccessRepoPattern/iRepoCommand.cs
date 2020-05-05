using BookMeProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessRepoPattern
{
    /// <summary>
    /// Chnages May-4-2020 :- all the methods have there own generic Type now; its longer deendent on the CType defined in the class
    /// </summary>
    /// <typeparam name="pocoTypePlaceholder"></typeparam>
    
    public interface iRepoCommand<pocoTypePlaceholder> : iRepo<pocoTypePlaceholder>
        where pocoTypePlaceholder : iPoco
    {

        void add<anotherPocoTypePlaceholder> (params anotherPocoTypePlaceholder[] pocosToBeAdded)
            where anotherPocoTypePlaceholder : class, BookMeProject.iPoco;

        void update<anotherPocoTypePlaceholder>(params anotherPocoTypePlaceholder[] pocosToBeUpdated)
            where anotherPocoTypePlaceholder : class, BookMeProject.iPoco;


        //will not work with entities with Navigation properties 
        void delete<anotherPocoTypePlaceholder>(params anotherPocoTypePlaceholder[] pocosTobeDeleted)
            where anotherPocoTypePlaceholder : class, BookMeProject.iPoco;

        void delete<anotherPocoTypePlaceholder>(Expression<Func<anotherPocoTypePlaceholder, bool>> wherePredicate)
            where anotherPocoTypePlaceholder : class, BookMeProject.iPoco;

       
        


    }
}
