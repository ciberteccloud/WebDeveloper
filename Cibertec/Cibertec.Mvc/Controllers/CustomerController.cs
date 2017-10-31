using Cibertec.Models;
using Cibertec.UnitOfWork;
using System.Web.Mvc;
using log4net;
using Cibertec.Mvc.ActionFilters;

namespace Cibertec.Mvc.Controllers
{
    [ErrorActionFilter]
    public class CustomerController : BaseController
    {
        public CustomerController(ILog log, IUnitOfWork unit) : base(log, unit)
        {            
        }
        public ActionResult Error()
        {
            throw new System.Exception("Test error to validate Action Filter");
        }

        public ActionResult Index()
        {
            _log.Info("Execution of Customer Controller OK");
            return View(_unit.Customers.GetList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                _unit.Customers.Insert(customer);
                RedirectToAction("Index");
            }
            return View(customer);
        }

        public ActionResult Edit(int id)
        {
            return View(_unit.Customers.GetById(id));
        }

        [HttpPost]
        public ActionResult Edit(Customer customer)
        {
            if (ModelState.IsValid)
            {
                _unit.Customers.Update(customer);
                RedirectToAction("Index");
            }
            return View(customer);
        }

        public ActionResult Delete(int id)
        {
            return View(_unit.Customers.GetById(id));
        }

        [HttpPost]
        public ActionResult Delete(Customer customer)
        {
            if (_unit.Customers.Delete(customer)) return RedirectToAction("Index");
            return View(customer);
        }
    }
}