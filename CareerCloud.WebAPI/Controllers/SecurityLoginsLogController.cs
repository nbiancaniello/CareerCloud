using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace CareerCloud.WebAPI.Controllers
{
    [RoutePrefix("api/careercloud/security/v1")]
    public class SecurityLoginsLogController : ApiController
    {
        private SecurityLoginsLogLogic _logic;

        public SecurityLoginsLogController()
        {
            var repo = new EFGenericRepository<SecurityLoginsLogPoco>(false);
            _logic = new SecurityLoginsLogLogic(repo);
        }

        [HttpGet]
        [Route("loginslog/{id}")]
        [ResponseType(typeof(SecurityLoginsLogPoco))]
        public IHttpActionResult GetSecurityLoginsLog(Guid Id)
        {
            SecurityLoginsLogPoco poco = _logic.Get(Id);
            if(poco == null)
            {
                return NotFound();
            }

            return Ok(poco);
        }

        [HttpGet]
        [Route("loginslog/")]
        [ResponseType(typeof(List<SecurityLoginsLogPoco>))]
        public IHttpActionResult GetSecurityLoginsLog()
        {
            List<SecurityLoginsLogPoco> poco = _logic.GetAll();
            if (poco == null)
            {
                return NotFound();
            }

            return Ok(poco);
        }

        [HttpPost]
        [Route("loginslog/")]
        public IHttpActionResult PostSecurityLoginsLog([FromBody] SecurityLoginsLogPoco[] pocos)
        {
            _logic.Add(pocos);
            return Ok();
        }

        [HttpPut]
        [Route("loginslog/")]
        public IHttpActionResult PutSecurityLoginsLog([FromBody] SecurityLoginsLogPoco[] pocos)
        {
            _logic.Update(pocos);
            return Ok();
        }

        [HttpDelete]
        [Route("loginslog/")]
        public IHttpActionResult DeleteSecurityLoginsLog([FromBody] SecurityLoginsLogPoco[] pocos)
        {
            _logic.Delete(pocos);
            return Ok();
        }
    }
}
