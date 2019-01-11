using DatabaseCode.DataMethods;
using EfLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ClientSolutions.DataMethods
{/// <summary>
/// Creates lists for viewbags mostly
/// </summary>
    public class SelectionListGenerator : ISelectionListGenerator
    {/// <summary>
    /// Method for retrieving the list
    /// </summary>
    /// <param name="source">IDataManipulation interface</param>
    /// <param name="displayPath">Path for display in combo box</param>
    /// <param name="valuePath">Path for getting the value from in combo box</param>
    /// <param name="selected">Id of the selected item</param>
    /// <returns></returns>
        public SelectList GetList(IDataManipulation source,  string valuePath, string displayPath, int selected = -1)
        {

            var all = source.GetAll().Result;
            //Func<SelectList> deleg = () => {
            //    SelectList res = selected == -1 ? new SelectList(all, displayPath, valuePath) : new SelectList(all, displayPath, valuePath, selected);
            //    return res;
            //};
            // var t1 = new Task<SelectList>(deleg);
            SelectList res = selected == -1 ? new SelectList(all, valuePath, displayPath) : new SelectList(all, valuePath, displayPath, selected);

            return res;
        }
        /// <summary>
        /// Method for retrieving the list of problems to be shown in a combo box
        /// </summary>      
        /// <returns>list of problem views</returns>
        public List<SelectListItem> GetListOfProblems ()
        {
            var all = (new ProblemManipulation()).GetAll().Result.Cast<Problem>().ToList();            
            return all.Select(x => new SelectListItem { Value = x.ProblemId.ToString().Trim(), Text = x.Comment + " :: " + x.TypeOfRequest.Description + " :: " + x.User.FullName }).ToList();
        }
    }
}