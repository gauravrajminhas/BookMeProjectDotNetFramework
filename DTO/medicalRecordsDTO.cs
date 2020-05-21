using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    [DataContract]
    public class medicalRecordsDTO : iDTO
    {
        [DataMember]
        public Guid recordID { get; set; }
        [DataMember]
        public Guid ecifID { get; set; }
        [DataMember]
        public byte[] documents { get; set; }

        ////Navigation
        //public userDTO usersNavigation { get; set; }
    }
}
