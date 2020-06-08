using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FaultsAndExceptions
{

    public class missingUserEmailDetails : ICustomFaultsAndExceptions
    {

        public string errorMsg { get; set; }
        public int errorCode { get; set; }
    }
}
