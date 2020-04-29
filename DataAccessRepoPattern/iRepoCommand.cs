using BookMeProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessRepoPattern
{
    public interface iRepoCommand<pocoTypePlaceholder> : iRepo<pocoTypePlaceholder>
        where pocoTypePlaceholder : iPoco
    {

        void add(params pocoTypePlaceholder[] pocosToBeAdded);
        void update(params pocoTypePlaceholder[] pocosToBeUpdated);

        //will not work with entities with Navigation properties 
        void delete(params pocoTypePlaceholder[] pocosTobeDeleted);
        void delete(Expression<Func<pocoTypePlaceholder, bool>> wherePredicate);
        void delete<anotherPocoTypePlaceholder>(Expression<Func<anotherPocoTypePlaceholder, bool>> wherePredicate)
            where anotherPocoTypePlaceholder : class, iPoco;
        


    }
}
