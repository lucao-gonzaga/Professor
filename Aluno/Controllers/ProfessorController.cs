using Professor.Context;
using Professor.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Professor.Controllers
{
    public class ProfessorController : Controller
    {
        private readonly Contexto db = new Contexto();

        #region Index
        public ActionResult Index()
        {
            return View(db.Professor.ToList());
        }
        #endregion

        #region Create - GET
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        #endregion

        #region Create - POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProfessorModel Professor)
        {
            if (ModelState.IsValid)
            {
                db.Professor.Add(Professor);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(Professor);
        }
        #endregion

        #region Details
        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ProfessorModel professor = db.Professor.Where(a => a.Id == id).FirstOrDefault();

            if (professor == null)
            {
                return HttpNotFound();
            }
            
            return View(professor);
        }
        #endregion

        #region Edit - GET
        [HttpGet]
        public ActionResult Edit (int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ProfessorModel professor = db.Professor.Where(a => a.Id == id).FirstOrDefault();

            if (professor == null)
            {
                return HttpNotFound();
            }

            return View(professor);
        }
        #endregion

        #region Edit - POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProfessorModel professor)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Entry(professor).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View(professor);
                }
            }
            return View(professor);
        }
        #endregion

        #region Delete - GET
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ProfessorModel professor = db.Professor.Where(a => a.Id == id).FirstOrDefault();

            if (professor == null)
            {
                return HttpNotFound();
            }

            return View(professor);
        }
        #endregion
    }
}

