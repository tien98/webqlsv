using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebStudent.Models;
using WebStudent.Repository;

namespace WebStudent.Controllers
{
    public class SinhVienController : Controller
    {
        public ActionResult GetAllSVDetails()
        {
            SinhVienRepository SVRepo = new SinhVienRepository();
            ModelState.Clear();
            return View(SVRepo.GetAllSV());
        }
        // GET: NhanVien
        public ActionResult Index()
        {
            return View();
        }

        // GET: NhanVien/Details/5
        public ActionResult Details(int maSV)
        {
            SinhVienRepository SVRepo = new SinhVienRepository();
            return View(SVRepo.GetAllSV().Find(sv => sv.MaSV == maSV));
        }

        // POST: NhanVien/Details/5
        [HttpPost]

        public ActionResult EditDetails(int id, SinhVienModel obj)
        {
            try
            {
                SinhVienRepository svRepo = new SinhVienRepository();

                svRepo.UpdateSV(obj);
                return RedirectToAction("GetAllEmpDetails");
            }
            catch
            {
                return View();
            }
        }

        // GET: NhanVien/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NhanVien/Create
        [HttpPost]
        public ActionResult Create(SinhVienModel sv)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    SinhVienRepository SvRepo = new SinhVienRepository();

                    if (SvRepo.AddSV(sv))
                    {
                        ViewBag.Message = "Employee details added successfully";
                    }
                }

                return View();
            }
            catch(Exception ex)
            {
                return View();
            }
        }

        // GET: NhanVien/Edit/5
        public ActionResult Edit(int maSV)
        {
            SinhVienRepository SVRepo = new SinhVienRepository();
            return View(SVRepo.GetAllSV().Find(sv => sv.MaSV == maSV));
        }

        // POST: NhanVien/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, SinhVienModel obj)
        {
            try
            {
                SinhVienRepository svRepo = new SinhVienRepository();

                svRepo.UpdateSV(obj);
                return RedirectToAction("GetAllEmpDetails");
            }
            catch
            {
                return View();
            }
        }

        // GET: NhanVien/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                SinhVienRepository svRepo = new SinhVienRepository();
                if (svRepo.DeleteSV(id))
                {
                    ViewBag.AlertMsg = "Employee details deleted successfully";

                }
                return RedirectToAction("GetAllEmpDetails");

            }
            catch
            {
                return View();
            }
        }

        // POST: NhanVien/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
