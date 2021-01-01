using EveryNote.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveryNote.DataAccessLayer.EntityFramework
{
    public class RepositoryBase
    {
        protected static DataBaseContext _db;
        private static object obj = new object();
        protected RepositoryBase()
        {
            CreateContex(); //Repository class'ı miras aldıgında new() lenecek ve bu constructor çalışacak.

        }
        private static DataBaseContext CreateContex()
        {
            if (_db==null)
            {
                lock (obj)
                {
                    _db = new DataBaseContext();
                }
                
            }
            return _db;
        }
    }
}
