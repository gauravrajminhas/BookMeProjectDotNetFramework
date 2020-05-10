using BookMeProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Bug :- this appraoch has introduced a new issue 
/// Child objects are not being saved as they are retirived by QueryDBContext and saved by commandDBContext 
/// https://stackoverflow.com/questions/18054798/entity-framework-not-saving-modified-children
/// </summary>




namespace DataAccessRepoPattern
{
    /// <summary>
    /// Chnages May-4-2020 :- all the methods have there own generic Type now; its longer deendent on the CType defined in the class
    /// </summary>
    // do not need PocoTypePlacolder here
    public interface iRepoQuery<pocoTypePlaceholder> : iRepo<pocoTypePlaceholder>
        where pocoTypePlaceholder : class, iPoco
    {
        // Lazy loding of the entity without Properties 
        List<anotherPocoTypePlaceholder> GetAll<anotherPocoTypePlaceholder>()
            where anotherPocoTypePlaceholder : class, iPoco;

        // loding of the entity with Properties 
        // Func<anotherPocoTypePlaceholder, object> navigationObjectPath
        // Important :- OUT has to be Object and not iPoco 
        // coz for Many-to-Many  .Include <T, TEntityType> path     >> needs a Type that reflects a entity Navigation
        // now that will be a Poco for 1-1 and List for 1-many 
        // ref https://docs.microsoft.com/en-us/dotnet/api/system.data.entity.queryableextensions.include?view=entity-framework-6.2.0#System_Data_Entity_QueryableExtensions_Include__2_System_Linq_IQueryable___0__System_Linq_Expressions_Expression_System_Func___0___1___

        List<anotherPocoTypePlaceholder> GetAll<anotherPocoTypePlaceholder>(Expression<Func<anotherPocoTypePlaceholder, object>> navigationObjectPath)
            where anotherPocoTypePlaceholder : class, iPoco;


        // does not load the navigation properties 
        anotherPocoTypePlaceholder GetSingle<anotherPocoTypePlaceholder> (Func<anotherPocoTypePlaceholder, bool> wherePredicate)
            where anotherPocoTypePlaceholder: class, iPoco;

        // This GetSingle is to load navigation objects as well. 
        anotherPocoTypePlaceholder GetSingle<anotherPocoTypePlaceholder> (Func<anotherPocoTypePlaceholder, bool> wherePredicate, params Expression<Func<anotherPocoTypePlaceholder, object>>[] navigationPropertyPathObjectList)
            where anotherPocoTypePlaceholder : class, iPoco;

    }
}
