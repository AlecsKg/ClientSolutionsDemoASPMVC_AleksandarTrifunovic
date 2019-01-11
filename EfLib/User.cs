using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EfLib
{
    /// <summary>
    /// User that contacts our company    
    /// </summary>     
    public class User
    {
        public void CopyFrom (User x)
        {
            UserId = x.UserId;
            Name = x.Name;
            Surname = x.Surname;
            Comment = x.Comment;
            Active = x.Active;
        }

        /// <summary>
        /// Database generated id of the user
        /// </summary>
        /// <returns>User id</returns> 
        [Key()]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Id")]
        public int UserId { get; set; }
        /// <summary>
        /// First name of the user
        /// </summary>
        /// <returns>Name of the user</returns> 
        [DisplayName("Name")]
        public string Name { get; set; }
        /// <summary>
        /// Last or more names of the user
        /// </summary>
        /// <returns>Surname of the user</returns> 
        [DisplayName("Surname")]
        public string Surname { get; set; }
        /// <summary>
        /// Comment valid to us about the user
        /// </summary>
        /// <returns>Comment</returns> 
        public string Comment { get; set; }
        /// <summary>
        /// Should be active in the system and visible for future use
        /// </summary>
        /// <returns>Active startus</returns> 
        public bool Active { get; set; }
        /// <summary>
        /// Full name of the user
        /// </summary>
        /// <returns>Gets the full name</returns>
        public string FullName 
        {
            get
            {
                return this.Name + " " + this.Surname;
            }
           

        }
      
    }
}