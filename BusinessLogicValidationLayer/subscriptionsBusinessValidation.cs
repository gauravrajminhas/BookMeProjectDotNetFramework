using BookMeProject;
using DataAccessRepoPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicValidationLayer
{
    class subscriptionsBusinessValidation : Ivalidation
    {
        iRepoCommand<iPoco> commandObject;
        iRepoQuery<iPoco> queryObject;
    }
}
