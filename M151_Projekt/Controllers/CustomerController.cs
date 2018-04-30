using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using M151_Projekt.Core;
using M151_Projekt.Models;

namespace M151_Projekt.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IUnitOfWork unitOfWork = new UnitOfWork(new MortgageEntities());

        // GET: Risk
        public ActionResult Index()
        {
            return View(unitOfWork.Customers.GetAll());
        }


        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            unitOfWork.Customers.Add(customer);
            unitOfWork.Complete();
            return View("Details", customer);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            ViewBag.Mortgages = unitOfWork.Mortgages.GetByCustomer(id);
            return View(unitOfWork.Customers.Get(id));
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            ViewBag.Mortgages = unitOfWork.Mortgages.GetByCustomer(id);
            return View(unitOfWork.Customers.Get(id));
        }

        [HttpPost]
        public ActionResult Edit(Customer customer)
        {
            ViewBag.Mortgages = unitOfWork.Mortgages.GetByCustomer(customer.id);
            unitOfWork.Customers.Update(customer);
            unitOfWork.Complete();
            return View(customer);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Customer customer = unitOfWork.Customers.Get(id ?? default(int));
            if (customer == null)
            {
                return HttpNotFound();
            }
            ViewBag.Mortgages = unitOfWork.Mortgages.GetByCustomer(customer.id);
            return View(customer);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer customer = unitOfWork.Customers.Get(id);
            unitOfWork.Customers.Remove(customer);
            unitOfWork.Complete();
            return RedirectToAction("Index");
        }

       
        
    }
}