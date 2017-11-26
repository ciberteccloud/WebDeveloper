using Cibertec.Models;
using Cibertec.UnitOfWork;
using System.Web.Http;
using log4net;

namespace Cibertec.WebApi.Controllers
{
    [RoutePrefix("customer")]
    public class CustomerController : BaseController
    {
        public CustomerController(IUnitOfWork unit, ILog log) : base(unit, log)
        {
            _log.Info($"{typeof(CustomerController)} in Execution");
        }

        [Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            _log.Debug($"Customer Id: {id}");
            if (id <= 0) return BadRequest();
            return Ok(_unit.Customers.GetById(id));
        }

        [Route("")]
        [HttpPost]
        public IHttpActionResult Post(Customer customer)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var id = _unit.Customers.Insert(customer);
            return Ok(new { id = id });
        }

        [Route("")]
        [HttpPut]
        public IHttpActionResult Put(Customer customer)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (!_unit.Customers.Update(customer)) return BadRequest("Incorrect id");
            return Ok(new { status = true });
        }

        [Route("{id}")]
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            if (id <= 0) return BadRequest();
            var result = _unit.Customers.Delete(new Customer { Id = id });
            return Ok(new { delete = true });
        }

        [HttpGet]
        [Route("count")]
        public IHttpActionResult GetCount()
        {
            return Ok(_unit.Customers.Count());
        }

        [HttpGet]
        [Route("list/{page}/{rows}")]
        public IHttpActionResult GetList(int page, int rows)
        {
            var startRecord = ((page - 1) * rows) + 1;
            var endRecord = page * rows;
            return Ok(_unit.Customers.PagedList(startRecord, endRecord));
        }

        [HttpGet]
        [Route("error")]
        public IHttpActionResult CreateError()
        {
            throw new System.Exception("This is an unhandled error.");
        }
    }
}
