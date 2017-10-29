using Cibertec.Repositories.Dapper.Northwind;
using Cibertec.UnitOfWork;
using System.Configuration;
using System.Web.Mvc;

namespace Cibertec.Mvc.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IUnitOfWork _unit;
        public CustomerController()
        {
            _unit = new NorthwindUnitOfWork(ConfigurationManager.ConnectionStrings["NorthwindConnection"].ToString());
        }
        public ActionResult Index()
        {
            return View(_unit.Customers.GetList());
        }
    }
}