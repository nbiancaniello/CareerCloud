using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace CareerCloud.WebAPI.Controllers
{
    [RoutePrefix("api/careercloud/system/v1")]
    public class SystemCountryCodeController : ApiController
    {
        private SystemCountryCodeLogic _logic;

        public SystemCountryCodeController()
        {
            var repo = new EFGenericRepository<SystemCountryCodePoco>(false);
            _logic = new SystemCountryCodeLogic(repo);
        }

        [HttpGet]
        [Route("countrycode/{id}")]
        [ResponseType(typeof(SystemCountryCodePoco))]
        public IHttpActionResult GetSystemCountryCode(string Id)
        {
            SystemCountryCodePoco poco = _logic.Get(Id);
            if(poco == null)
            {
                return NotFound();
            }

            return Ok(poco);
        }

        [HttpGet]
        [Route("countrycode/")]
        [ResponseType(typeof(List<SystemCountryCodePoco>))]
        public IHttpActionResult GetSystemCountryCode()
        {
            List<SystemCountryCodePoco> poco = _logic.GetAll();
            if (poco == null)
            {
                return NotFound();
            }

            return Ok(poco);
        }

        [HttpPost]
        [Route("countrycode/")]
        public IHttpActionResult PostSystemCountryCode([FromBody] SystemCountryCodePoco[] pocos)
        {
            _logic.Add(pocos);
            return Ok();
        }

        [HttpPut]
        [Route("countrycode/")]
        public IHttpActionResult PutSystemCountryCode([FromBody] SystemCountryCodePoco[] pocos)
        {
            _logic.Update(pocos);
            return Ok();
        }

        [HttpDelete]
        [Route("countrycode/")]
        public IHttpActionResult DeleteSystemCountryCode([FromBody] SystemCountryCodePoco[] pocos)
        {
            _logic.Delete(pocos);
            return Ok();
        }
    }
}
