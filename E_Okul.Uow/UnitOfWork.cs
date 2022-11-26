using E_Okul.Dal;
using E_Okul.Repository.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Okul.Uow
{
    public class UnitOfWork : IUnitOfWork
    {
        EOkulContext _db;
        public IStudentRep _studentRep { get; private set; }

        public ITeacherRep _teacherRep { get; private set; }

        public IBranchRep _branchRep { get; private set; }

        public void Commit()
        {
            _db.SaveChanges();
        }
        public UnitOfWork(EOkulContext db, IStudentRep studentRep, ITeacherRep teacherRep, IBranchRep branchRep)
        {
            _db = db;
            _studentRep = studentRep;
            _teacherRep = teacherRep;
            _branchRep = branchRep;
        }
    }
}
