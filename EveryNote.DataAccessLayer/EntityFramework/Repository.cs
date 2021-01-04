using EveryNote.Common;
using EveryNote.DataAccessLayer;
using EveryNote.DataAccessLayer.Abstract;
using EveryNote.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EveryNote.DataAccessLayer.EntityFramework
{
    public class Repository<T> : RepositoryBase, IRepository<T> where T : class
    {
        // private DataBaseContext db = new DataBaseContext(); // bu singletondan önce böyle erişiyordu.

        private DbSet<T> _dbSet;
        public Repository()
        {
            //<!-- Repository base'den miras aldıgımız için gerke kalmadı-->db = RepositoryBase.CreateContex();//SINGLETON PATTERNDEN SONRA DATABASECONTEXT E BU ŞEKİLDE ERİŞİLİR.
            _dbSet = _db.Set<T>();
        }
        public List<T> List()
        {

            return _dbSet.ToList();
        }

        public List<T> List(Expression<Func<T, bool>> expression)
        {
            return _dbSet.Where(expression).ToList();
        }
        public int Save()
        {
            try
            {
                return _db.SaveChanges();
            }
            catch (Exception ex)
            {

                Console.Write(ex);
            }

            return 0;
        }

        public int Insert(T obj)
        {
            _dbSet.Add(obj);
            if (obj is EntityBase)
            {
                EntityBase eb = obj as EntityBase;
                DateTime now = DateTime.Now;
                eb.CreatedOn = now;
                eb.ModifiedOn = now;
                eb.ModifiedUser = App.Common.GetCurrentUserName(); // TODO : sistemdeki kullanıcı yazılacak.

            }

            return Save();
        }

        public int Delete(T obj)
        {
            _dbSet.Remove(obj);
            return Save();
        }

        public int Update(T obj)
        {
            if (obj is EntityBase)
            {
                EntityBase eb = obj as EntityBase;
                eb.ModifiedOn = DateTime.Now;
                eb.ModifiedUser = App.Common.GetCurrentUserName(); // TODO : sistemdeki kullanıcı yazılacak.

            }
            return Save();
        }
        public T Find(Expression<Func<T, bool>> expression)
        {
            return _dbSet.FirstOrDefault(expression);
        }

    }
}
