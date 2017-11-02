using System.Web.Mvc;

namespace Cibertec.Mvc.Controllers
{
    
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }        
    }
}