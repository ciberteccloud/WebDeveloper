using Cibertec.UnitOfWork;
using System.Web.Mvc;

namespace Cibertec.Mvc.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IUnitOfWork _unit;
        public CustomerController(IUnitOfWork unit)
        {
            _unit = unit;
        }
        public ActionResult Index()
        {
            return View(_unit.Customers.GetList());
        }
    }
}