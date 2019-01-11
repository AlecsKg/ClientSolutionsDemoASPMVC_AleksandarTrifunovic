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
using ClientSolutions.DataMethods;
using DatabaseCode.DataMethods;

namespace ClientSolutions.Controllers
{
    /// <summary>
    /// Controller for problems/requests
    /// </summary>
    public class ProblemsController : Controller
    {
        private ProblemManipulation pm = new ProblemManipulation();
        List<Problem> problems = new List<Problem>();   
        /// <summary>
        /// Constructor that creates list of requests from database
        /// </summary>
        public ProblemsController()
        {
            problems = pm.GetAll().Result.Cast<Problem>().ToList();
        }
        // GET: Problems
        /// <summary>
        /// Index action for displaying requests
        /// </summary>
        /// <returns>View for list of requests</returns>
        public  ActionResult Index()
        {
           
            return View(problems);
        }

        // GET: Problems/Details/5
        /// <summary>
        /// Details action
        /// </summary>
        /// <param name="id">id of selected request</param>
        /// <returns></returns>
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Problem problem = problems.Find(x => x.ProblemId == id);
            if (problem == null)
            {
                return HttpNotFound();
            }
            return View(problem);
        }

        // GET: Problems/Create
        /// <summary>
        /// Creating action
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            ViewBag.TypeOfRequestId =StaticMethods.GetSelectList_TypeOfRequests();
            ViewBag.UserId = StaticMethods.GetSelectList_Users();
            return View();
        }

        // POST: Problems/Create   
        /// <summary>
        /// Creating on post
        /// </summary>
        /// <param name="problem">selected problem as object</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ProblemId,TypeOfRequestId,PhoneNumber,UserId,Comment,Active")] Problem problem)
        {
            if (ModelState.IsValid)
            {
                problem.Active = true;
                pm.Add(problem);             
                await pm.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TypeOfRequestId = StaticMethods.GetSelectList_TypeOfRequests(problem.TypeOfRequestId);
            ViewBag.UserId = StaticMethods.GetSelectList_Users(problem.UserId);
            return View(problem);
        }

        // GET: Problems/Edit/5
        /// <summary>
        /// Edit that gets selected id
        /// </summary>
        /// <param name="id">Selected request id</param>
        /// <returns></returns>
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Problem problem = problems.FirstOrDefault (x => x.ProblemId == id);
            if (problem == null)
            {
                return HttpNotFound();
            }
            ViewBag.TypeOfRequestId = StaticMethods.GetSelectList_TypeOfRequests(problem.TypeOfRequestId);
            ViewBag.UserId = StaticMethods.GetSelectList_Users(problem.UserId);
            return View(problem);
        }

        // POST: Problems/Edit/5
        /// <summary>
        /// Post action for editing directly from selected object
        /// </summary>
        /// <param name="problem"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ProblemId,TypeOfRequestId,PhoneNumber,UserId,Comment,Active")] Problem problem)
        {
            if (ModelState.IsValid)
            {
                pm.ChangeState(problem,problem.ProblemId);
                await pm.SaveChanges();
                return RedirectToAction("Index","Problems");
            }
            ViewBag.TypeOfRequestId = StaticMethods.GetSelectList_TypeOfRequests(problem.TypeOfRequestId);
            ViewBag.UserId = StaticMethods.GetSelectList_Users(problem.UserId);
            return View(problem);
        }

        // GET: Problems/Delete/5
        /// <summary>
        /// Get action for deleting by selected id
        /// </summary>
        /// <param name="id">Id of selected request</param>
        /// <returns></returns>
        public  ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Problem problem = problems.FirstOrDefault(x => x.ProblemId == id);
            if (problem == null)
            {
                return HttpNotFound();
            }
            return View(problem);
        }

        // POST: Problems/Delete/5
        /// <summary>
        /// Post delete action
        /// </summary>
        /// <param name="id">Id of confirmed request for delete</param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Problem problem = problems.FirstOrDefault(x => x.ProblemId == id);
            pm.Remove(problem);    
            await pm.SaveChanges();
            return RedirectToAction("Index");
        }
        /// <summary>
        /// Disposing the model with class
        /// </summary>
        /// <param name="disposing">should the model be disposed</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
               
            }
            base.Dispose(disposing);
        }
    }
}
