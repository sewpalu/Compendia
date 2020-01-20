using Compendia.Model.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compendia.Database.Base
{
    public class TableRepository<T> : BaseRepository where T : BaseModel
    {
        #region Constructor
        protected TableRepository(DatabaseContext context) : base(context)
        {

        }

        #endregion ConStructor

        #region GetObjetct
        public virtual List<T> GetObjects()
        {
            try
            {
                var models = DatabaseContext.Set<T>().ToList();
                return models;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }
        public virtual async Task<List<T>> GetObjectsAsync()
        {
            try
            {
                var models = await DatabaseContext.Set<T>().ToListAsync();
                return models;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message.ToString());
                return null;
            }
        }
        #endregion GetObject

        #region GetLastObject

        public virtual T GetLastObject()
        {
            try
            {
                var model = DatabaseContext.Set<T>().Last();
                return model;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }

        }
        public virtual async Task<T> GetLastObjectAsync()
        {
            try
            {
                var model = await DatabaseContext.Set<T>().LastAsync();
                return model;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message.ToString());

                Console.WriteLine(e.InnerException.Message.ToString());
                return null;
            }

        }


        #endregion GetLastObject

        #region GetObjectById
        public virtual T GetObjectById(int id)
        {
            try
            {
                var model = DatabaseContext.Set<T>().Find(id);
                return model;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message.ToString());
                return null;
            }
        }
        public virtual async Task<T> GetObjectByIdAsync(int id)
        {
            try
            {
                var model = await DatabaseContext.Set<T>().FindAsync(id);
                return model;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message.ToString());
                return null;
            }


        }

        #endregion GetObjectById

        #region AddObject
        public virtual bool AddObject(T t)
        {
            try
            {
                var state = DatabaseContext.Set<T>().Add(t);
                var result = state.State == EntityState.Added;
                DatabaseContext.SaveChanges();
                return result;

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;

            }
        }

        public virtual async Task<bool> AddObjectAsync(T t)
        {
            try
            {
                var state = await DatabaseContext.Set<T>().AddAsync(t);
                var result = state.State == EntityState.Added;
                await DatabaseContext.SaveChangesAsync();
                return result;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                Console.WriteLine(e.InnerException.Message);

                return false;
            }
        }
        #endregion AddObject

        #region UpdateObject
        public virtual bool UpdateObject(T t)
        {
            try
            {
                var state = DatabaseContext.Set<T>().Update(t);
                var result = state.State == EntityState.Modified;
                DatabaseContext.SaveChanges();
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public virtual async Task<bool> UpdateObjectAsync(T t)
        {
            try
            {
                var state = DatabaseContext.Set<T>().Update(t);
                var result = state.State == EntityState.Modified;
                await DatabaseContext.SaveChangesAsync();

                return result;
            }
            catch (Exception e)
            {

                Console.WriteLine(e);
                return false;
            }
        }

        #endregion UpdateObject

        #region DeleteObjects
        // Delete all objects from a tabel
        public virtual bool DeleteObjects()
        {
            try
            {
                var models = GetObjects();
                DatabaseContext.Set<T>().RemoveRange(models);
                DatabaseContext.SaveChanges();

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        // Delete all objects from a tabel async
        public virtual async Task<bool> DeleteObjectsAsync()
        {
            try
            {
                var models = await GetObjectsAsync();
                DatabaseContext.Set<T>().RemoveRange(models);
                await DatabaseContext.SaveChangesAsync();

                return true;

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }

        }

        #endregion DeleteObjects

        #region DeleteObject

        // Delete a specific object from a tabel 
        public virtual bool DeleteObject(int id)
        {
            try
            {
                var model = DatabaseContext.Set<T>().Find(id);
                var state = DatabaseContext.Set<T>().Remove(model);
                var result = state.State == EntityState.Deleted;
                DatabaseContext.SaveChanges();

                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        // Delete a specific object from a tabel  async
        public virtual async Task<bool> DeleteObjectAsync(int id)
        {
            try
            {
                var model = await DatabaseContext.Set<T>().FindAsync(id);
                var state = DatabaseContext.Set<T>().Remove(model);
                var result = state.State == EntityState.Deleted;
                await DatabaseContext.SaveChangesAsync();

                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
        #endregion DeleteObject

        #region QueryObject

        protected T QueryObject(Func<T, bool> predicate)
        {
            try
            {
                var model = DatabaseContext.Set<T>().Where(predicate).First();
                return model;


            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        protected List<T> QueryObjects(Func<T, bool> predicate)
        {
            try
            {
                var models = DatabaseContext.Set<T>().Where(predicate).ToList();
                return models;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }


        #endregion QueryObject

    }
}
