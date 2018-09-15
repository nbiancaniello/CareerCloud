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
    public class SecurityRoleController : ApiController
    {
        private SecurityRoleLogic _logic;

        public SecurityRoleController()
        {
            var repo = new EFGenericRepository<SecurityRolePoco>(false);
            _logic = new SecurityRoleLogic(repo);
        }

        [HttpGet]
        [Route("role/{id}")]
        [ResponseType(typeof(SecurityRolePoco))]
        public IHttpActionResult GetSecurityRole(Guid Id)
        {
            SecurityRolePoco poco = _logic.Get(Id);
            if(poco == null)
            {
                return NotFound();
            }

            return Ok(poco);
        }

        [HttpGet]
        [Route("role/")]
        [ResponseType(typeof(List<SecurityRolePoco>))]
        public IHttpActionResult GetSecurityRole()
        {
            List<SecurityRolePoco> poco = _logic.GetAll();
            if (poco == null)
            {
                return NotFound();
            }

            return Ok(poco);
        }

        [HttpPost]
        [Route("role/")]
        public IHttpActionResult PostSecurityRole([FromBody] SecurityRolePoco[] pocos)
        {
            _logic.Add(pocos);
            return Ok();
        }

        [HttpPut]
        [Route("role/")]
        public IHttpActionResult PutSecurityRole([FromBody] SecurityRolePoco[] pocos)
        {
            _logic.Update(pocos);
            return Ok();
        }

        [HttpDelete]
        [Route("role/")]
        public IHttpActionResult DeleteSecurityRole([FromBody] SecurityRolePoco[] pocos)
        {
            _logic.Delete(pocos);
            return Ok();
        }
    }
}
