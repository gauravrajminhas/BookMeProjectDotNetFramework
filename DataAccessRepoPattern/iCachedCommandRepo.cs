using BookMeProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessRepoPattern
{
    public interface iCachedCommandRepo<pocoTypePlaceholder> :iRepoCommand<pocoTypePlaceholder>
        where pocoTypePlaceholder : iPoco
    {
    }
}
