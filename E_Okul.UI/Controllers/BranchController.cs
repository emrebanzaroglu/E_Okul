using E_Okul.Entity.Concretes;
using E_Okul.UI.Models;
using E_Okul.Uow;
using Microsoft.AspNetCore.Mvc;

namespace E_Okul.UI.Controllers
{
    public class BranchController : Controller
    {
        IUnitOfWork _uow;
        BranchModel _model;

        public BranchController(IUnitOfWork uow, BranchModel model)
        {
            _uow = uow;
            _model = model;
        }

        public IActionResult List()
        {
            return View(_uow._branchRep.List());
        }
        public IActionResult Detail(int Id)
        {
            var p = _uow._branchRep.FindDetail(Id);
            return View(p);
        }
        public IActionResult Add()
        {
            _model.Branches = new Branches();
            _model.Head = "Yeni Giriş";
            _model.Text = "Kaydet";
            _model.Cls = "btn btn-primary";
            return View("Crud", _model);
        }

        [HttpPost]
        public IActionResult Add(BranchModel model)
        {
            _uow._branchRep.Add(model.Branches);
            _uow.Commit();
            return RedirectToAction("List");
        }

        public IActionResult Update(int Id)
        {
            _model.Branches = _uow._branchRep.Find(Id);
            _model.Head = "Güncelleme";
            _model.Text = "Güncelle";
            _model.Cls = "btn btn-success";
            return View("Crud", _model);
        }

        [HttpPost]
        public IActionResult Update(BranchModel model)
        {
            _uow._branchRep.Update(model.Branches);
            _uow.Commit();
            return RedirectToAction("List");
        }
        public IActionResult Delete(int Id)
        {
            _model.Branches = _uow._branchRep.Find(Id);
            _model.Head = "Silme";
            _model.Text = "Sil";
            _model.Cls = "btn btn-danger";
            return View("Crud", _model);
        }
        [HttpPost]
        public IActionResult Delete(BranchModel model)
        {
            _uow._branchRep.Delete(model.Branches.Id);
            _uow.Commit();
            return RedirectToAction("List");
        }
    }
}
