using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EfLib
{/// <summary>
/// Problem that needs to be solved
/// </summary>
    public class Problem
    {             

        public void CopyFrom(Problem x)
        {         
            TypeOfRequestId = x.TypeOfRequestId;
            PhoneNumber = x.PhoneNumber;
            UserId = x.UserId;
            Comment = x.Comment;
            Active = x.Active;
            User = x.User;
            TypeOfRequest = x.TypeOfRequest;
        }

        /// <summary>
        /// Database generated id of a problem
        /// </summary>
        /// <returns>Problem id</returns> 
        [Key()]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Id")]
        public int ProblemId { get; set; }
        /// <summary>
        /// User request type id
        /// </summary>
        /// <returns>Type of request id</returns> 
     [DisplayName("Type of Request")]
        public int TypeOfRequestId { get; set; }
        /// <summary>
        /// User phone number
        /// </summary>
        /// <returns>Phone number</returns> 
        [DisplayName("Phone #")]
        public string PhoneNumber { get; set; }
        /// <summary>
        /// User that is calling
        /// </summary>
        /// <returns>User id</returns> 
        /// 
        [DisplayName("User")]
        public int UserId { get; set; }
        /// <summary>
        /// Comment valid to us about the problem
        /// </summary>
        /// <returns>Comment</returns> 
        /// 
        [DisplayName("Problem desc")]
        public string Comment { get; set; }
        /// <summary>
        /// Should be active in the system and visible for future use
        /// </summary>
        /// <returns>Active status</returns> 
        public bool Active { get; set; }
        /// <summary>
        /// Foreign key to the user table
        /// </summary>
        /// <returns>User object from foreign key</returns> 
        public User User { get; set; }
        /// <summary>
        /// Foreign key to the type request
        /// </summary>
        /// <returns>User object from type request</returns> 
        public TypeOfRequest TypeOfRequest { get; set; }
        /// <summary>
        /// Cloning the data
        /// </summary>
        /// <param name="x">New data</param>
        /// <returns></returns>
      
    }
}