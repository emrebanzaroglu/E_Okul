﻿using E_Okul.Dto;
using E_Okul.Entity.Concretes;
using E_Okul.UI.Models;
using E_Okul.Uow;
using Microsoft.AspNetCore.Mvc;

namespace E_Okul.UI.Controllers
{
    public class StudentController : Controller
    {
        IUnitOfWork _uow;
        StudentModel _model;

        public StudentController(StudentModel model, IUnitOfWork uow)
        {
            _model = model;
            _uow = uow;
        }

        public IActionResult List()
        {
            var slist = _uow._studentRep.Set().Select(x => new StudentDTO
            {
                Id= x.Id,
                FullName=x.FullName(),
                Gender=x.Gender,
                Picture=x.Picture,
                TCNo=Convert.ToInt32(x.TCNo),
                SchoolNo=Convert.ToInt32(x.SchoolNo),
            }).ToList();
            return View();
        }
        public IActionResult Detail(int Id)
        {
            var s = _uow._studentRep.FindDetail(Id);
            return View(s);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Gender = new Dictionary<string, string>()
            {
                {"Erkek","Erkek"},
                {"Kadın","Kadın" }
            };
            _model.Students = new Students();
            _model.Head = "Yeni Giriş";
            _model.Text = "Kaydet";
            _model.Cls = "btn btn-primary";
            _model.Branches = _uow._branchRep.List();
            _model.Teachers = _uow._teacherRep.List();
            return View("Crud", _model);
        }

        [HttpPost]
        public IActionResult Add(StudentModel model) 
        {
            _uow._studentRep.Add(model.Students);
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
            _model.Students = _uow._studentRep.Find(Id);
            _model.Head = "Güncelleme";
            _model.Text = "Güncelle";
            _model.Cls = "btn btn-success";
            _model.Branches = _uow._branchRep.List();
            _model.Teachers = _uow._teacherRep.List();
            return View("Crud", _model);
        }

        [HttpPost]
        public IActionResult Update(StudentModel model)
        {
            _uow._studentRep.Update(model.Students);
            _uow.Commit();
            return RedirectToAction("List");
        }

        [HttpGet]
        public IActionResult Delete(int Id)
        {
            _model.Students = _uow._studentRep.Find(Id);
            _model.Head = "Silme";
            _model.Text = "Sil";
            _model.Cls = "btn btn-danger";
            _model.Branches = _uow._branchRep.List();
            _model.Teachers = _uow._teacherRep.List();
            return View("Crud", _model);
        }
        [HttpPost]
        public IActionResult Delete(StudentModel model)
        {
            _uow._studentRep.Delete(model.Students.Id);
            _uow.Commit();
            return RedirectToAction("List");
        }
    }
}
