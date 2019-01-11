using EfLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Threading.Tasks;


namespace DatabaseCode.DataMethods
{
    public class TypeOfRequestManipulation:IDataManipulation 
    {

        private readonly ModelEF _context;
        /// <summary>
        /// Constructor with new EF context
        /// </summary>
        public TypeOfRequestManipulation()
        {
            _context = _context ?? new ModelEF();

        }
        /// <summary>
        /// Adding the entity
        /// </summary>
        /// <param name="Entity">An entity</param>
        public void Add(Object Entity) =>
        _context.TypeOfRequests.Add((TypeOfRequest)Entity);
        /// <summary>
        /// Changing the state of the entity
        /// </summary>
        /// <param name="changedEntity">new values</param>
        /// <param name="id">id of the one for changing</param>
        public void ChangeState(object changedEntity, int id)
        {
            var x = changedEntity;
            var y = GetOne(id).Result;
            _context.Entry(y).CurrentValues.SetValues(x);
            _context.Entry(y).State = EntityState.Modified;
        }
        /// <summary>
        /// Getting the complete collection from the db
        /// </summary>
        /// <returns>The list of insterts</returns>
        public Task<List<Object>> GetAll() =>
        _context.TypeOfRequests.Where(x => x.Active).ToListAsync().ContinueWith(t => t.Result.Cast<Object>().ToList());

        /// <summary>
        /// Getting the object from the db
        /// </summary>
        /// <param name="id">Id of the insert</param>
        /// <returns>POCO</returns>
        public Task<Object> GetOne(int id) =>
          _context.TypeOfRequests.SingleOrDefaultAsync(m => m.TypeOfRequestId == id).ContinueWith(t => (Object)t.Result);

        /// <summary>
        /// Removing in the context
        /// </summary>
        /// <param name="Entity">Object to be removed</param>
        public void Remove(Object Entity) =>
        _context.TypeOfRequests.Remove((TypeOfRequest)Entity);
        /// <summary>
        /// Saving context
        /// </summary>
        /// <returns></returns>
        public Task SaveChanges() =>
        _context.SaveChangesAsync();

    }
}