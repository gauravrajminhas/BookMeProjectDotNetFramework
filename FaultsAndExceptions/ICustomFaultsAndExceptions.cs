using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FaultsAndExceptions
{
    
    public interface ICustomFaultsAndExceptions
    {

        string errorMsg { get; set; }
        int errorCode { get; set; }
    }
}
