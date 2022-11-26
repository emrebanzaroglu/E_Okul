using E_Okul.Core;
using E_Okul.Dal;
using E_Okul.Entity.Concretes;
using E_Okul.Repository.Abstracts;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Okul.Repository.Concretes
{
    public class StudentRep<T> : BaseRepository<Students>, IStudentRep where T : class
    {
        public StudentRep(EOkulContext db) : base(db)
        {
        }
    }
}
