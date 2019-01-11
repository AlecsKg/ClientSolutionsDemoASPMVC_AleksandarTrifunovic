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
    /// Controller for user class
    /// </summary>
    public class UsersController : Controller
    {
        UserManipulation um = new UserManipulation();
        // GET: Users
        /// <summary>
        /// Index method for displaying User table data
        /// </summary>
        /// <returns>View of list of users</returns>
        public async Task<ActionResult> Index()
        {
            var l = await um.GetAll();
            return View(l.Cast<User>().ToList());
        }

        // GET: Users/Details/5
        /// <summary>
        /// Gets details of a user
        /// </summary>
        /// <param name="id">Id of the selected user</param>
        /// <returns></returns>
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user =(User)await um.GetOne((int)id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Users/Create
        /// <summary>
        /// Gets view for a creation of a user
        /// </summary>
        /// <returns>View</returns>
        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        /// <summary>
        /// Post create method of a user
        /// </summary>
        /// <param name="user">Generated object from the get method</param>
        /// <returns></returns>
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "UserId,Name,Surname,Comment,Active")] User user)
        {
            if (ModelState.IsValid)
            {
                um.Add(user);
                await um.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user);
        }

        // GET: Users/Edit/5
        /// <summary>
        /// Creates a view for editing a user
        /// </summary>
        /// <param name="id">Id of the selected user</param>
        /// <returns></returns>
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }         
            User user =(User)await um.GetOne((int)id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
       /// <summary>
       /// Post edit method for a user
       /// </summary>
       /// <param name="user">Object of a user created in get method</param>
       /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "UserId,Name,Surname,Comment,Active")] User user)
        {
            if (ModelState.IsValid)
            {
                um.ChangeState(user, user.UserId);              
                await um.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET: Users/Delete/5
        /// <summary>
        /// Returns delete view for a user
        /// </summary>
        /// <param name="id">Id of the selected user</param>
        /// <returns></returns>
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = (User)await um.GetOne((int)id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Delete/5
        /// <summary>
        /// Post method for deletion of a user
        /// </summary>
        /// <param name="id">Id of the selected user</param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            User user = (User)await um.GetOne((int)id);
            um.Remove(user);
            await um.SaveChanges();
            return RedirectToAction("Index");
        }
        /// <summary>
        /// Disposing method for disposing model object alongside this class
        /// </summary>
        /// <param name="disposing">Should the database model be disposed</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
              //  db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
