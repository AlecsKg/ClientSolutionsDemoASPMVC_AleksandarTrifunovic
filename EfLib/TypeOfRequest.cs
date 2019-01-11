using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EfLib
{/// <summary>
/// Type of request that is generated through seed method to the database
/// </summary>
    public class TypeOfRequest
    {
        public void CopyFrom(TypeOfRequest x)
        {
            TypeOfRequestId = x.TypeOfRequestId;
            Description = x.Description ;
            Active =x.Active;
        }

        /// <summary>
        /// Id of a type
        /// </summary>
        [Key()]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Id")]
        public int TypeOfRequestId { get; set; }
        /// <summary>
        /// Description of a type
        /// </summary>
        /// 
        [DisplayName("Type")]
        public string Description { get; set; }
        /// <summary>
        /// Active status for further use
        /// </summary>
        public bool Active { get; set; }
    }
}