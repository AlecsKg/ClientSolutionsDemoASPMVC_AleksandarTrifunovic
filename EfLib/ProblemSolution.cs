using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EfLib
{/// <summary>
/// Solution for a specific problem
/// </summary>
    public class ProblemSolution
    {
        public void CopyFrom(ProblemSolution x)
        {
            ProblemSolutionId = x.ProblemSolutionId;
            Start = x.Start;
            End = x.End;
            Status =x.Status;
            ProblemId = x.ProblemId;
            Comment = x.Comment;
            Active = x.Active;
            Problem = x.Problem;
        }

        /// <summary>
        /// Database generated id of a problem solution
        /// </summary>
        /// <returns>Id of the solution</returns> 
        [Key()]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Id")]
        public int ProblemSolutionId { get; set; }
        /// <summary>
        /// Projected start of the problem solving step
        /// </summary>
        /// <returns>Starting date</returns> 
      
        public DateTime Start { get; set; }
       
        /// <summary>
        /// Projected end of the problem solving step
        /// </summary>
        /// <returns>Ending date</returns>        
     
        public DateTime End { get; set; }
 
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
        public Problem Problem  { get; set; }
    }
}