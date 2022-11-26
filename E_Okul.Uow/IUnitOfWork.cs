using E_Okul.Repository.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Okul.Uow
{
    public interface IUnitOfWork
    {
        IStudentRep _studentRep { get; }
        ITeacherRep _teacherRep { get; }
        IBranchRep _branchRep { get; }
        void Commit();
    }
}
