using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class GenericRepository<TEntity> where TEntity : class
    {
        #region Private member variables...
        internal EntityDataContext _context;
        internal DbSet<TEntity> _dbSet;
        #endregion

        #region Constructor
        public GenericRepository(EntityDataContext Context)
        {
            this._context = new EntityDataContext();
            this._dbSet = Context.Set<TEntity>();
        }
        #endregion

        #region Public member methods...
        /// <summary>
        /// generic Get method for Entities
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<TEntity> Get()
        {
            try 
            { 
            IQueryable<TEntity> query = _dbSet;
            return query.ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// Generic get method on the basis of id for Entities.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual TEntity GetById(object id)
        {
            try
            {
                return _dbSet.Find(id);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// generic Insert method for the entities
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Insert(TEntity _entity)
        {  
                _dbSet.Add(_entity);
        }

        /// <summary>
        /// Generic Delete method for the entities
        /// </summary>
        /// <param name="id"></param>
        public virtual void Delete(object id)
        {
            TEntity objEntity = _dbSet.Find(id);
            Delete(objEntity);

        }

        /// <summary>
        /// Generic Delete method for the entities
        /// </summary>
        /// <param name="entityToDelete"></param>
        public virtual void Delete(TEntity _entity)
        {
            if (_context.Entry(_entity).State == EntityState.Detached)
            {
                _dbSet.Attach(_entity);
            }
            _dbSet.Remove(_entity);
        }

        /// <summary>
        /// Generic update method for the entities
        /// </summary>
        /// <param name="entityToUpdate"></param>

        public virtual void Update(TEntity _entity)
        {
            _dbSet.Attach(_entity);
            _context.Entry(_entity).State = EntityState.Modified;
        }

        /// <summary>
        /// generic method to get many record on the basis of a condition.
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>

        public virtual IEnumerable<TEntity> GetMany(Func<TEntity, bool> where)
        {
            try
            {
                return _dbSet.Where(where).ToList();
            }
            catch
            {
                return null;
            }

        }

        /// <summary>
        /// generic method to get many record on the basis of a condition but query able.
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>

        public virtual IQueryable<TEntity> GetManyQuerable(Func<TEntity, bool> where)
        {
            try
            {
                return _dbSet.Where(where).AsQueryable();
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// generic get method , fetches data for the entities on the basis of condition.
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>

        public TEntity Get(Func<TEntity, Boolean> where)
        {
            try
            {
                return _dbSet.Where(where).FirstOrDefault<TEntity>();
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// generic delete method , deletes data for the entities on the basis of condition.
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public void Delete(Func<TEntity, Boolean> where)
        {
            IQueryable objDelete = _dbSet.Where<TEntity>(where).AsQueryable();
            foreach (var obj in objDelete)
                this.Delete(obj);
        }

        /// <summary>
        /// generic method to fetch all the records from db
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<TEntity> GetAll()
        {
            try
            {
                return _dbSet.ToList();
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Generic method to check if entity exists
        /// </summary>
        /// <param name="primaryKey"></param>
        /// <returns></returns>
        public bool Exists(object primaryKey)
        {
            try
            {
                return _dbSet.Find(primaryKey) != null;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Gets a single record by the specified criteria (usually the unique identifier)
        /// </summary>
        /// <param name="predicate">Criteria to match on</param>
        /// <returns>A single record that matches the specified criteria</returns>
        public TEntity GetSingle(Func<TEntity, bool> predicate)
        {
            try
            {
                return _dbSet.Single<TEntity>(predicate);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// The first record matching the specified criteria
        /// </summary>
        /// <param name="predicate">Criteria to match on</param>
        /// <returns>A single record containing the first record matching the specified criteria</returns>
        public TEntity GetFirst(Func<TEntity, bool> predicate)
        {
            try
            {
                return _dbSet.First<TEntity>(predicate);
            }
            catch
            {
                return null;
            }
        }


        #endregion
    }
}
