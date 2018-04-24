using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using M151_Projekt.Core;
using M151_Projekt.Models;

namespace M151_Projekt.Controllers
{
    public class RiskController : Controller
    {
        private readonly IUnitOfWork unitOfWork = new UnitOfWork(new MortgageEntities());

        // GET: Risk
        public ActionResult Index()
        {
            return View(unitOfWork.Risks.GetAll());
        }
        

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Risk risk)
        {
            unitOfWork.Risks.Add(risk);
            unitOfWork.Complete();
            return View("Details", risk);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            return View(unitOfWork.Risks.Get(id));
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(unitOfWork.Risks.Get(id));
        }

        [HttpPost]
        public ActionResult Edit(Risk risk)
        {
            unitOfWork.Risks.Update(risk);
            unitOfWork.Complete();
            return View(risk);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            unitOfWork.Risks.Remove(unitOfWork.Risks.Get(id));
            return View("Index");
        }
    }
}