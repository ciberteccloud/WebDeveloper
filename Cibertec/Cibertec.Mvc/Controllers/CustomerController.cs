using Cibertec.Models;
using Cibertec.UnitOfWork;
using System.Web.Mvc;
using log4net;
using Cibertec.Mvc.ActionFilters;
using System.Net;
using System.Collections.Generic;

namespace Cibertec.Mvc.Controllers
{
    [ErrorActionFilter]
    [RoutePrefix("Customer")]
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

        public PartialViewResult Create()
        {
            return PartialView("_Create", new Customer());
        }

        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            if (!ModelState.IsValid) return PartialView("_Create", customer);
            _unit.Customers.Insert(customer);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            return PartialView("_Edit", _unit.Customers.GetById(id));
        }

        [HttpPost]
        public ActionResult Edit(Customer customer)
        {
            if (!ModelState.IsValid) return PartialView("_Edit", customer);
            _unit.Customers.Update(customer);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            return PartialView("_Delete", _unit.Customers.GetById(id));
        }

        [HttpPost]
        public ActionResult Delete(Customer customer)
        {
            if (_unit.Customers.Delete(customer)) return RedirectToAction("Index");
            return PartialView("_Delete", customer);
        }

        [Route("List/{page:int}/{rows:int}")]
        public PartialViewResult List(int page, int rows)
        {
            if (page <= 0 || rows <= 0) return PartialView(new List<Customer>());
            var startRecord = ((page - 1) * rows) + 1;
            var endRecord = page * rows;
            return PartialView("_List",_unit.Customers.PagedList(startRecord, endRecord));
        }

        [HttpGet]  
        [Route("Count/{rows:int}")]
        public int Count(int rows)
        {
            var totalRecords = _unit.Customers.Count();
            return totalRecords % rows != 0 ? (totalRecords / rows) + 1 : totalRecords / rows;
        }
    }
}