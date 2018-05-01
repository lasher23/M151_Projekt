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
    public class MortgageCustomerAssignmentController : Controller
    {
        private readonly IUnitOfWork unitOfWork = new UnitOfWork(new MortgageEntities());

        public ActionResult Index()
        {
            return View(unitOfWork.MortgageCustomerAssignments.GetAll());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MortgageCustomerAssignment mortgageCustomerAssignment = unitOfWork.MortgageCustomerAssignments.Get(id ?? default(int));
            if (mortgageCustomerAssignment == null)
            {
                return HttpNotFound();
            }
            return View(mortgageCustomerAssignment);
        }

        public ActionResult Create()
        {
            ViewBag.fk_customer = new SelectList(unitOfWork.Customers.GetAll(), "id", "prename");
            ViewBag.fk_mortgage = new SelectList(unitOfWork.Mortgages.GetAll(), "id", "morgageName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,fk_customer,fk_mortgage,paidState")] MortgageCustomerAssignment mortgageCustomerAssignment)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.MortgageCustomerAssignments.Add(mortgageCustomerAssignment);
                unitOfWork.Complete();
                return RedirectToAction("Index");
            }

            ViewBag.fk_customer = new SelectList(unitOfWork.Customers.GetAll(), "id", "prename", mortgageCustomerAssignment.fk_customer);
            ViewBag.fk_mortgage = new SelectList(unitOfWork.Mortgages.GetAll(), "id", "morgageName", mortgageCustomerAssignment.fk_mortgage);
            return View(mortgageCustomerAssignment);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            MortgageCustomerAssignment mortgageCustomerAssignment = unitOfWork.MortgageCustomerAssignments.Get(id ?? default(int));
            if (mortgageCustomerAssignment == null)
            {
                return HttpNotFound();
            }
            ViewBag.fk_customer = new SelectList(unitOfWork.Customers.GetAll(), "id", "prename", mortgageCustomerAssignment.fk_customer);
            ViewBag.fk_mortgage = new SelectList(unitOfWork.Mortgages.GetAll(), "id", "morgageName", mortgageCustomerAssignment.fk_mortgage);
            return View(mortgageCustomerAssignment);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,fk_customer,fk_mortgage,paidState")] MortgageCustomerAssignment mortgageCustomerAssignment)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.MortgageCustomerAssignments.Update(mortgageCustomerAssignment);
                unitOfWork.Complete();
                return RedirectToAction("Index");
            }
            ViewBag.fk_customer = new SelectList(unitOfWork.Customers.GetAll(), "id", "prename", mortgageCustomerAssignment.fk_customer);
            ViewBag.fk_mortgage = new SelectList(unitOfWork.Mortgages.GetAll(), "id", "morgageName", mortgageCustomerAssignment.fk_mortgage);
            return View(mortgageCustomerAssignment);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            MortgageCustomerAssignment mortgageCustomerAssignment = unitOfWork.MortgageCustomerAssignments.Get(id ?? default(int));
            if (mortgageCustomerAssignment == null)
            {
                return HttpNotFound();
            }
            return View(mortgageCustomerAssignment);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MortgageCustomerAssignment mortgageCustomerAssignment = unitOfWork.MortgageCustomerAssignments.Get(id);
            unitOfWork.MortgageCustomerAssignments.Remove(mortgageCustomerAssignment);
            unitOfWork.Complete();
            return RedirectToAction("Index");
        }
    }
}
