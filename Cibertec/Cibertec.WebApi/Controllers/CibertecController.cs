using System.Collections.Generic;
using System.Web.Http;

namespace Cibertec.WebApi.Controllers
{
    public class CibertecController : ApiController
    {        
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }        
    }
}