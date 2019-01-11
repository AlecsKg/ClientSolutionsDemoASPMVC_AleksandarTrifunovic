using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EfLib;
using ClientSolutions.Models;
using ClientSolutions.DataMethods;
using DatabaseCode.DataMethods;

namespace ClientSolutions.Controllers
{
    
    /// <summary>
    /// Controller for problem solutions
    /// </summary>
    public class ProblemSolutionsController : Controller
    {
        private DataConversion dc = new DataConversion();
        private SolutionManipulation sm = new SolutionManipulation();
        private ProblemManipulation pm = new ProblemManipulation();
        List<ProblemSolutionView> solutions = new List<ProblemSolutionView>();
        List<ProblemSolution> solutionPOCOs = new List<ProblemSolution>();
        List<Problem> problems = new List<Problem>();
        /// <summary>
        /// Controller of the class that reads data from the database
        /// </summary>
        public ProblemSolutionsController()        {
            solutionPOCOs = sm.GetAll().Result.Cast<ProblemSolution>().ToList();
            solutions = (from x in solutionPOCOs
                         select dc.Convert_ProblemSolutionPOCOToView(x)).ToList();
            problems = pm.GetAll().Result.Cast<Problem>().ToList();      
            //these ViewBags are needed for filtering the data
            ViewBag.Names = solutions.Select(x => x.UserFullName).Distinct().ToList();           
            ViewBag.RequestDescs = solutions.Select(x => x.RequestDescription).Distinct().ToList();
            ViewBag.Finished = solutions.Select(x => x.Status).Distinct().ToList();
            ViewBag.StartsD = solutions.Select(x => x.StartDate ).Distinct().ToList();
            ViewBag.EndsD = solutions.Select(x => x.EndDate ).Distinct().ToList();        
            ViewBag.Comments = solutions.Select(x => x.Comment).Distinct().ToList();
        }
       
        // GET: ProblemSolutions
        /// <summary>
        /// Gets the list for display and filters the data
        /// </summary>
        /// <returns>View for list of solutions</returns>
        public  ActionResult Index(string selectName="", string selectProblemComment = "", bool? selectProblemStatus=null, DateTime? selectStart=null, DateTime? selectEnd = null, string selectComment="", TimeSpan? selectStartTime=null,TimeSpan? selectEndTime=null)
        {
            DateTime d1 = DateTime.MinValue;
            DateTime d2 = DateTime.MaxValue;
            if (selectStart  == null)
            { selectStart = d1; }
            if (selectEnd  == null)
            { selectEnd = d2; }
            TimeSpan t1 = TimeSpan.MinValue;
            TimeSpan t2 = TimeSpan.MaxValue;
            if (selectStartTime == null) selectStartTime = t1;
            if (selectEndTime == null) selectEndTime = t2;
            solutions = solutions.Where(x => x.UserFullName == selectName || selectName == "" || selectName == null           
            && x.RequestDescription  == selectProblemComment || selectProblemComment == "" || selectProblemComment == null
            && x.Status  == selectProblemStatus ||  selectProblemStatus == null
            && x.StartDate >= selectStart && x.EndDate >= selectEnd
            && x.Comment == selectComment || selectComment == "" || selectComment == null).ToList();        


            return View(solutions);
        }
        /// <summary>
        /// Post index for searching mainly
        /// </summary>
        /// <param name="userName">searched user full name</param>
        /// <param name="requestDescription">searched request description</param>
        /// <returns></returns>
        [HttpPost]        
        public ActionResult Index(string userName, string requestDescription)
        {
            if (!string.IsNullOrEmpty(userName))
                {
                solutions = solutions.Where(x => x.UserFullName  == userName.Trim()).ToList();
            }
        
            if (!string.IsNullOrEmpty(requestDescription))
            {
                solutions = solutions.Where(x => x.RequestDescription  == requestDescription.Trim()).ToList();
            }
            return View(solutions);
        }

        // GET: ProblemSolutions/Details/5
        /// <summary>
        /// Get details method for a solution
        /// </summary>
        /// <param name="id">Id of selected solution</param>
        /// <returns></returns>
        public  ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var problemSolution = solutions.FirstOrDefault(x=> x.ProblemSolutionId == id);
            if (problemSolution == null)
            {
                return HttpNotFound();
            }
            return View(problemSolution);
        }

        // GET: ProblemSolutions/Create
        /// <summary>
        /// Get create method of a solution
        /// </summary>
        /// <returns>List of requests for choosing</returns>
        public ActionResult Create()
        {
            ViewBag.Problems = StaticMethods.GetSelectList_Problems();
            return View();
        }
      
        // POST: ProblemSolutions/Create
        /// <summary>
        /// Post create method of a solution
        /// </summary>
        /// <param name="problemSolutionV">Object of solution of creation</param>
        /// <param name="selectedProblem">Selected problem from the view</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create( ProblemSolutionView problemSolutionV, string selectedProblem = "")
        {
            try
            {
                ProblemSolution ps = dc.Convert_ProblemSolutionViewToPOCO(problemSolutionV);
                int id =int.Parse(selectedProblem);
                ps.ProblemId = problems.FirstOrDefault(x => x.ProblemId == id).ProblemId ;
                ps.Active = true;
                sm.Add(ps);
              //  db.ProblemSolutions.Add(ps);
                await sm.SaveChanges();
                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                TempData["msg"] = "Data is incomplete";
                return RedirectToAction("Create");
            }
             
        }

        // GET: ProblemSolutions/Edit/5
        /// <summary>
        /// Get Edit method for a solution
        /// </summary>
        /// <param name="id">Id of selected solution</param>
        /// <returns></returns>
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var problemSolution = solutions.FirstOrDefault(x => x.ProblemSolutionId == id);
            if (problemSolution == null)
            {
                return HttpNotFound();
            }
            ViewBag.Problems = StaticMethods.GetSelectList_Problems();
            return View(problemSolution);
        }

        // POST: ProblemSolutions/Edit/5
       /// <summary>
       /// Post edit action for a solution
       /// </summary>
       /// <param name="problemSolutionV">Selected solution id</param>
       /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(ProblemSolutionView problemSolutionV)
        {
            if (ModelState.IsValid)
            {     
                sm.ChangeState(problemSolutionV, problemSolutionV.ProblemSolutionId);              
                await sm.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Problems = problems.Select(x => new SelectListItem { Value = x.ProblemId.ToString(), Text = x.Comment + " :: " + x.TypeOfRequest.Description + " :: " + x.User.Name + " " + x.User.Surname });
            return View(problemSolutionV);
        }

        // GET: ProblemSolutions/Delete/5
        /// <summary>
        /// Get method for id of an item to be deleted
        /// </summary>
        /// <param name="id">Id of selected item</param>
        /// <returns></returns>
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var problemSolution =solutions.FirstOrDefault(x => x.ProblemSolutionId == id);
            if (problemSolution == null)
            {
                return HttpNotFound();
            }
            return View(problemSolution);
        }

        // POST: ProblemSolutions/Delete/5
        /// <summary>
        /// Deleting on post
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]       
        public async Task<ActionResult> DeleteConfirmed(int id)
        {     
            sm.Remove(solutionPOCOs.FirstOrDefault(x => x.ProblemSolutionId == id));
            await sm.SaveChanges();
            return RedirectToAction("Index");
        }
        /// <summary>
        /// disposing model together with the class
        /// </summary>
        /// <param name="disposing">if model should be disposed</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
               // db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
