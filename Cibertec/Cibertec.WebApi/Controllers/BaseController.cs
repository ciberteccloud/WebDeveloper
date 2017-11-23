using System.Web.Http;
using Cibertec.UnitOfWork;
using log4net;

namespace Cibertec.WebApi.Controllers
{    
    [Authorize]
    public class BaseController : ApiController
    {
        protected readonly IUnitOfWork _unit;
        protected readonly ILog _log;
        
        public BaseController(IUnitOfWork unit, ILog log)
        {
            _unit = unit;
            _log = log;
        }
    }
}
