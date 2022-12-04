using E_Okul.Core;
using E_Okul.Dal;
using E_Okul.Entity.Concretes;
using E_Okul.Repository.Abstracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Okul.Repository.Concretes
{
    public class BranchRep<T> : BaseRepository<Branches>, IBranchRep where T : class
    {
        public BranchRep(EOkulContext db) : base(db)
        {
        }
        public Branches FindDetail(int Id)
        {
            return Set().Include(x => x.Teachers).Include(x => x.Students).FirstOrDefault(x => x.Id == Id);
        }
    }
}
