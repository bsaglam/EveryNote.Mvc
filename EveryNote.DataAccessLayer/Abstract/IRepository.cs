using EveryNote.DataAccessLayer;
using EveryNote.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Summary description for Class1
/// </summary>
public Interface IRepository<T>
{

    List<T> List();
    List<T> List(Expression<Func<T, bool>> expression);
    int Save();
    int Insert(T obj);
    int Delete(T obj);
    int Update(T obj);
    T Find(Expression<Func<T, bool>> expression);

}
