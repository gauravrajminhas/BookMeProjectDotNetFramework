using BookMeProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessRepoPattern
{
    public interface iRepoQuery<pocoTypePlaceholder> : iRepo<pocoTypePlaceholder>
        where pocoTypePlaceholder : class, iPoco
    {


        // how come this is not throwing a unknowtype Issue ?  Becuase i have just declared the type after function name 
        // difference Of ParametersInputTypes and function Type 

        


        // Lazy loding of the entity without Properties 
        List<anotherPocoTypePlaceholder> GetAll<anotherPocoTypePlaceholder>()
            where anotherPocoTypePlaceholder : class, iPoco;

        // loding of the entity with Properties 
        List<anotherPocoTypePlaceholder> GetAllWithProp<anotherPocoTypePlaceholder>(Expression<Func<anotherPocoTypePlaceholder, iPoco>> navigationObjectPath)
            where anotherPocoTypePlaceholder : class, iPoco;

        pocoTypePlaceholder GetSingle(Func<pocoTypePlaceholder, bool> where);


    }
}
