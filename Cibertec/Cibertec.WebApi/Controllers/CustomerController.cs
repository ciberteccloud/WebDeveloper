using Cibertec.UnitOfWork;
using System.Web.Http;

namespace Cibertec.WebApi.Controllers
{
    [RoutePrefix("customer")]
    public class CustomerController : BaseController
    {
        public CustomerController(IUnitOfWork unit) : base(unit)
        {
        }
        
        [HttpGet]
        public IHttpActionResult GetList()
        {
            return Ok(_unit.Customers.GetList());
        }
    }
}
