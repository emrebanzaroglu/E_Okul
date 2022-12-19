using E_Okul.Dal;
using E_Okul.Dto;
using E_Okul.Entity.Concretes;
using E_Okul.UI.Models;
using E_Okul.Uow;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_Okul.UI.Controllers
{
    public class TeacherController : Controller
    {
        EOkulContext _db;
        IUnitOfWork _uow;
        TeacherModel _model;

        public TeacherController(EOkulContext db,IUnitOfWork uow,TeacherModel model)
        {
            _db = db;
            _uow = uow;
            _model = model;
        }

        public IActionResult List()
        {
            var tlist = _uow._teacherRep.Set().Select(x=>new TeacherDTO
            {
                Id= x.Id,
                FullName= x.FullName(),
                BranchName = x.Branches.BranchName,
                Gender = x.Gender,
                Mail = x.Mail,
                Picture = x.Picture
            }).ToList();
            return View(tlist);
        }
        public IActionResult Detail(int Id)
        {
            var t = _uow._teacherRep.FindDetail(Id);
            return View(t);
        }

        public IActionResult Add()
        {
            ViewBag.Gender = new Dictionary<string, string>()
            {
                {"Erkek","Erkek"},
                {"Kadın","Kadın" }
            };
            _model.Teachers = new Teachers();
            _model.Head = "Yeni Giriş";
            _model.Text = "Kaydet";
            _model.Cls = "btn btn-primary";
            _model.Branches = _uow._branchRep.List();
            return View("Crud", _model);
        }

        [HttpPost]
        public IActionResult Add(TeacherModel model)
        {
            _uow._teacherRep.Add(model.Teachers);
            _uow.Commit();
            return RedirectToAction("List");
        }

        [HttpGet]

        public IActionResult Update(int Id)
        {
            ViewBag.Gender = new Dictionary<string, string>()
            {
                {"Erkek","Erkek"},
                {"Kadın","Kadın" }
            };
            _model.Teachers = _uow._teacherRep.Find(Id);
            _model.Head = "Güncelleme";
            _model.Text = "Güncelle";
            _model.Cls = "btn btn-success";
            _model.Branches = _uow._branchRep.List();
            return View("Crud", _model);
        }

        [HttpPost]
        public IActionResult Update(TeacherModel model)
        {
            _uow._teacherRep.Update(model.Teachers);
            _uow.Commit();
            return RedirectToAction("List");
        }

        public IActionResult Delete(int id, TeacherModel model)
        {
            var teacher = _db.Teachers.Find(id);
            _db.Teachers.Remove(teacher);
            _model.Branches = _uow._branchRep.List();
            _uow.Commit();
            return RedirectToAction("List");
        }
    }
}
