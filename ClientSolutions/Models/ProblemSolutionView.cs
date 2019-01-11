using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClientSolutions.Models
{/// <summary>
/// View of a problem solution for the management of the dates and foreign keys
/// </summary>
    public class ProblemSolutionView
    {/// <summary>
    /// Id that matches id from the database
    /// </summary>
   [DisplayName("Id")]
        public int ProblemSolutionId { get; set; }
        /// <summary>
        /// User name + surname from User foreign key
        /// </summary>
            [DisplayName("User full name")]
        public string UserFullName { get; set; }
        /// <summary>
        /// Description of the referenced request
        /// </summary>
        /// 
        [DisplayName("Request desc")]
        public string RequestDescription { get; set; }
        /// <summary>
        /// Projected start of the problem solving step
        /// </summary>
        /// <returns>Starting date</returns>   
        
        [DisplayName("Start date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yy H:mm:ss tt}")]
        public DateTime StartDate { get; set; }
        /// <summary>
        /// Projected start of the problem solving step
        /// </summary>
        /// <returns>Starting date time</returns>
        [DataType(DataType.Time)]
        public TimeSpan StartTime { get; set; }
        /// <summary>
        /// Projected end of the problem solving step
        /// </summary>
        /// <returns>Ending date</returns> 
        /// 
        [DisplayName("End date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yy H:mm:ss tt}")]
        public DateTime EndDate { get; set; }
        /// <summary>
        /// Projected end of the problem solving step
        /// </summary>
        /// <returns>Ending date time</returns> 

        [DataType(DataType.Time)]
        public TimeSpan EndTime { get; set; }
        /// <summary>
        ///Status reflecting the completion of the solution
        /// </summary>
        /// <returns>Status of the solution</returns> 
        /// 
        [DisplayName("Finished")]
        public bool Status { get; set; }
        /// <summary>
        /// Id of the problem that needs to be solved with solution(s)
        /// </summary>
        /// <returns>Problem id</returns> 
        [DisplayName("Problem")]
        public int ProblemId { get; set; }
        /// <summary>
        /// Comment valid to us about the problem
        /// </summary>
        /// <returns>Comment</returns> 

        [DisplayName("Solution desc")]
        public string Comment { get; set; }
        /// <summary>
        /// Should be active in the system and visible for future use
        /// </summary>
        /// <returns>Active status</returns> 
        public bool Active { get; set; }
        /// <summary>
        /// Foreign key to the problem table
        /// </summary>
        /// <returns>Problem object from foreign key</returns> 
    }
}