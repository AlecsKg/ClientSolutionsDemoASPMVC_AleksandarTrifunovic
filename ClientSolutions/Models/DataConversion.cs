using EfLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClientSolutions.Models
{/// <summary>
/// Class for converting data from POCO to Views and vice versa
/// </summary>
    public class DataConversion
    {
        /// <summary>
        /// Converting problem solution view to database object 
        /// </summary>
        /// <param name="psv"></param>
        /// <returns>Problem solution POCO</returns>
        public ProblemSolution Convert_ProblemSolutionViewToPOCO (ProblemSolutionView psv)
        {
            ProblemSolution ps = new ProblemSolution();
            Convert_ProblemSolutionViewToExistingPOCO(psv, ps);
            return ps;
        }
        /// <summary>
        /// Converting problem solution view to existing database object
        /// </summary>
        /// <param name="psv">View of problem solution</param>
        /// <param name="ps">Existing poco of problem solution</param>
        /// <returns></returns>
        public void Convert_ProblemSolutionViewToExistingPOCO(ProblemSolutionView psv, ProblemSolution ps )
        {

                           
                        ps.Active = psv.Active;
            ps.Comment = psv.Comment;
            ps.End = psv.EndDate.Date.AddMilliseconds(psv.EndTime.TotalMilliseconds);
            ps.ProblemId = psv.ProblemId;
            ps.ProblemSolutionId = psv.ProblemSolutionId;
            ps.Start = psv.StartDate.Date.AddMilliseconds(psv.StartTime.TotalMilliseconds);
            ps.Status = psv.Status;       


        }
        /// <summary>
        /// Converting problem solution database object to view
        /// </summary>
        /// <param name="x">Input problem solution poco</param>
        /// <returns>Problem solution view</returns>
        public ProblemSolutionView Convert_ProblemSolutionPOCOToView (ProblemSolution x)
        {
            return new ProblemSolutionView
            {
                Active = x.Active,
                Comment = x.Comment,
                EndDate = x.End,
                EndTime = x.End.TimeOfDay,
                ProblemId = x.ProblemId,
                ProblemSolutionId = x.ProblemSolutionId,
                StartDate = x.Start,
                StartTime = x.Start.TimeOfDay,
                Status = x.Status,
                RequestDescription = x.Problem.Comment,
                UserFullName = x.Problem.User.Name + " " + x.Problem.User.Surname
            };
        }


        
    }
}