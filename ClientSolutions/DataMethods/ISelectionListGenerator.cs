using DatabaseCode.DataMethods;
using System.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientSolutions.DataMethods
{/// <summary>
/// Interface for list generating methods
/// </summary>
   public interface ISelectionListGenerator
    {/// <summary>
    /// Form for getting the list for a viewbag
    /// </summary>
    /// <param name="source">IDataManipulation type</param>
    /// <param name="displayPath">PAth for displaying in combo box</param>
    /// <param name="valuePath">Path for selecting the value from the combo box</param>
    /// <param name="selected">Id of the pre-selected item in the combo box</param>
    /// <returns></returns>
        SelectList GetList(IDataManipulation source, string displayPath, string valuePath, int selected = -1);

    }
}
