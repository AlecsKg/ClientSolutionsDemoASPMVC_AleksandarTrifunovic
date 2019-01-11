using System.Collections.Generic;
using System.Web.Mvc;
using DatabaseCode.DataMethods;

namespace ClientSolutions.DataMethods
{/// <summary>
/// Global data methods
/// </summary>
    public static class StaticMethods
    {    

        /// <summary>
        /// Gets a list of Type of Requests for Viewbags (e.g.)
        /// </summary>
        /// <param name="id">Id of selected item</param>
        /// <returns>Select list</returns>
       public static SelectList GetSelectList_TypeOfRequests(int id = -1)
        {
            SelectionListGenerator slg = new SelectionListGenerator();        
         return slg.GetList(new TypeOfRequestManipulation(), "TypeOfRequestId", "Description", id);
        }
        /// <summary>
        /// Gets a list of Type of Users for Viewbags (e.g.)
        /// </summary>
        /// <param name="id">Id of selected item</param>
        /// <returns>Select list</returns>
        public static SelectList GetSelectList_Users (int id = -1)
        {
            SelectionListGenerator slg = new SelectionListGenerator();
            return slg.GetList(new UserManipulation(), "UserId", "FullName", id);
        }
        /// <summary>
        /// View bag list of problems
        /// </summary>  
        /// <returns></returns>
        public static List<SelectListItem> GetSelectList_Problems()
        {

            SelectionListGenerator slg = new SelectionListGenerator();
            return slg.GetListOfProblems();
           
        }
    }
}