using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseCode.DataMethods
{/// <summary>
/// Manipulation of raw data from the db
/// </summary>
    public interface IDataManipulation
    {/// <summary>
    /// Getting them all
    /// </summary>
    /// <returns></returns>
         Task<List<object>> GetAll();
        /// <summary>
        /// Getting the one
        /// </summary>
        /// <param name="id">Id of the one</param>
        /// <returns>Entity</returns>
        Task<object> GetOne(int id);
        /// <summary>
        /// Adding the one
        /// </summary>
        /// <param name="Entity">The one</param>
        void Add(object Entity);
        /// <summary>
        /// Removing the one
        /// </summary>
        /// <param name="Entity">The one</param>
        void Remove(object Entity);
        /// <summary>
        /// Changing state of the entity
        /// </summary>
        /// <param name="newEntity">the new entity</param>
        void ChangeState(object newEntity, int id);
        /// <summary>
        /// Saving changes from the context
        /// </summary>
        /// <returns>Int</returns>
        Task SaveChanges();
        
    }
}
