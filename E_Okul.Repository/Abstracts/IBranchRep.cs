using E_Okul.Core;
using E_Okul.Entity.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Okul.Repository.Abstracts
{
    public interface IBranchRep : IBaseRepository<Branches>
    {
        Branches FindDetail(int Id);
    }
}
