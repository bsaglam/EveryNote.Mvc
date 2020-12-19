using EveryNote.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EveryNote.BussinessLayer
{
    public class Repository<T> where T : class
    {
        private DataBaseContext db = new DataBaseContext();
        private DbSet<T> _dbSet;
        public Repository()
        {
            _dbSet = db.Set<T>();
        }
        public List<T> List()
        {

            return _dbSet.ToList();
        }

        public List<T> List(Expression<Func<T,bool>> expression)
        {
            return _dbSet.Where(expression).ToList();
        }
        public int Save()
        {
            return db.SaveChanges();
        }

        public int Insert(T obj)
        {
            _dbSet.Add(obj);
            return Save();
        }

        public int Delete(T obj)
        {
            _dbSet.Remove(obj);
            return Save();
        }

        public int Update(T obj)
        {
            return Save();
        }
        public T Find(Expression<Func<T, bool>> expression)
        {
            return _dbSet.FirstOrDefault(expression);
        }

    }
}
