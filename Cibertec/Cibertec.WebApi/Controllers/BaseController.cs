using System.Web.Http;
using Cibertec.UnitOfWork;

namespace Cibertec.WebApi.Controllers
{    
    [Authorize]
    public class BaseController : ApiController
    {
        protected readonly IUnitOfWork _unit;
        public BaseController(IUnitOfWork unit)
        {
            _unit = unit;
        }
    }
}
