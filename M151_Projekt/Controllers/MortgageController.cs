using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using M151_Projekt.Core;
using M151_Projekt.Models;

namespace M151_Projekt.Controllers
{
    public class MortgageController : Controller
    {
        private readonly IUnitOfWork unitOfWork = new UnitOfWork(new MortgageEntities());
        private MortgageEntities db = new MortgageEntities();

        // GET: Mortgage
        public ActionResult Index()
        {
            var mortgage = unitOfWork.Mortgages.GetAll();
            return View(mortgage);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Mortgage mortgage = unitOfWork.Mortgages.Get(id ?? default(int));
            if (mortgage == null)
            {
                return HttpNotFound();
            }
            return View(mortgage);
        }

        public ActionResult Create()
        {
            ViewBag.fk_risk = new SelectList(unitOfWork.Risks.GetAll(), "id", "riskName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,morgageName,rate,fk_risk")] Mortgage mortgage)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.Mortgages.Add(mortgage);
                unitOfWork.Complete();
                return RedirectToAction("Index");
            }

            ViewBag.fk_risk = new SelectList(unitOfWork.Risks.GetAll(), "id", "riskName", mortgage.fk_risk);
            return View(mortgage);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Mortgage mortgage = unitOfWork.Mortgages.Get(id ?? default(int));
            if (mortgage == null)
            {
                return HttpNotFound();
            }
            ViewBag.fk_risk = new SelectList(unitOfWork.Risks.GetAll(), "id", "riskName", mortgage.fk_risk);
            return View(mortgage);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,morgageName,rate,fk_risk")] Mortgage mortgage)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.Mortgages.Update(mortgage);
                unitOfWork.Complete();
                return RedirectToAction("Index");
            }
            ViewBag.fk_risk = new SelectList(db.Risk, "id", "riskName", mortgage.fk_risk);
            return View(mortgage);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Mortgage mortgage = unitOfWork.Mortgages.Get(id ?? default(int));
            if (mortgage == null)
            {
                return HttpNotFound();
            }
            return View(mortgage);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Mortgage mortgage = unitOfWork.Mortgages.Get(id);
            unitOfWork.Mortgages.Remove(mortgage);
            unitOfWork.Complete();
            return RedirectToAction("Index");
        }
    }
}
