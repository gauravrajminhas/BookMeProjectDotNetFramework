using BookMeProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessRepoPattern
{
    public interface iCachedQueryRepo<pocoTypePlaceholder> :iRepoQuery<pocoTypePlaceholder>
        where pocoTypePlaceholder : iPoco
    {
    }
}
