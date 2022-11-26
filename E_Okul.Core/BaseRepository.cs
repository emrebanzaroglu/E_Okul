using E_Okul.Dal;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Okul.Core
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        EOkulContext _db;

        public BaseRepository(EOkulContext db)
        {
            _db = db;
        }
        public DbSet<T> Set()
        {
            return _db.Set<T>();
        }

        public List<T> List()
        {
            return Set().ToList();
        }
        public T Find(int Id)
        {
            return Set().Find(Id);
        }
        public bool Add(T entity)
        {
            try
            {
                Set().Add(entity);
                return true;    
            }
            catch (Exception)
            {

                return false;
            }
        }
        public bool Update(T entity)
        {
            try
            {
                Set().Update(entity);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
 
        public bool Delete(int Id)
        {
            try
            {
                Set().Remove(Find(Id));
                return true;
            }
            catch (Exception)
            {

                return false;
            };
        }
    }
}
