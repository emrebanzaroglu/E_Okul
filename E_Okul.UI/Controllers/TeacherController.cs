using E_Okul.Dto;
using E_Okul.Entity.Concretes;
using E_Okul.UI.Models;
using E_Okul.Uow;
using Microsoft.AspNetCore.Mvc;

namespace E_Okul.UI.Controllers
{
    public class TeacherController : Controller
    {
        IUnitOfWork _uow;
        TeacherModel _model;

        public TeacherController(IUnitOfWork uow,TeacherModel model)
        {
            _uow = uow;
            _model = model;
        }

        public IActionResult List()
        {
            var tlist = _uow._teacherRep.Set().Select(x=>new TeacherDTO
            {
                Id= x.Id,
                FullName= x.FullName(),
                BranchName = x.Branches.BranchName
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
            _model.Teachers = new Teachers();
            _model.Head = "Yeni Giriş";
            _model.Text = "Kaydet";
            _model.Cls = "btn btn-primary";
            return View("Crud", _model);
        }

        [HttpPost]
        public IActionResult Add(TeacherModel model)
        {
            _uow._teacherRep.Add(model.Teachers);
            _uow.Commit();
            return RedirectToAction("List");
        }

        public IActionResult Update(int Id)
        {
            _model.Teachers = _uow._teacherRep.Find(Id);
            _model.Head = "Güncelleme";
            _model.Text = "Güncelle";
            _model.Cls = "btn btn-success";
            return View("Crud", _model);
        }

        [HttpPost]
        public IActionResult Edit(TeacherModel model)
        {
            _uow._teacherRep.Update(model.Teachers);
            _uow.Commit();
            return RedirectToAction("List");
        }
        public IActionResult Delete(int Id)
        {
            _model.Teachers = _uow._teacherRep.Find(Id);
            _model.Head = "Silme";
            _model.Text = "Sil";
            _model.Cls = "btn btn-danger";
            return View("Crud", _model);
        }
        [HttpPost]
        public IActionResult Delete(TeacherModel model)
        {
            _uow._teacherRep.Delete(model.Teachers.Id);
            _uow.Commit();
            return RedirectToAction("List");
        }
    }
}
