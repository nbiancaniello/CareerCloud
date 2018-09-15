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
    public class SecurityLoginsRoleController : ApiController
    {
        private SecurityLoginsRoleLogic _logic;

        public SecurityLoginsRoleController()
        {
            var repo = new EFGenericRepository<SecurityLoginsRolePoco>(false);
            _logic = new SecurityLoginsRoleLogic(repo);
        }

        [HttpGet]
        [Route("loginsrole/{id}")]
        [ResponseType(typeof(SecurityLoginsRolePoco))]
        public IHttpActionResult GetSecurityLoginsRole(Guid Id)
        {
            SecurityLoginsRolePoco poco = _logic.Get(Id);
            if(poco == null)
            {
                return NotFound();
            }

            return Ok(poco);
        }

        [HttpGet]
        [Route("loginsrole/")]
        [ResponseType(typeof(List<SecurityLoginsRolePoco>))]
        public IHttpActionResult GetSecurityLoginsRole()
        {
            List<SecurityLoginsRolePoco> poco = _logic.GetAll();
            if (poco == null)
            {
                return NotFound();
            }

            return Ok(poco);
        }

        [HttpPost]
        [Route("loginsrole/")]
        public IHttpActionResult PostSecurityLoginsRole([FromBody] SecurityLoginsRolePoco[] pocos)
        {
            _logic.Add(pocos);
            return Ok();
        }

        [HttpPut]
        [Route("loginsrole/")]
        public IHttpActionResult PutSecurityLoginsRole([FromBody] SecurityLoginsRolePoco[] pocos)
        {
            _logic.Update(pocos);
            return Ok();
        }

        [HttpDelete]
        [Route("loginsrole/")]
        public IHttpActionResult DeleteSecurityLoginsRole([FromBody] SecurityLoginsRolePoco[] pocos)
        {
            _logic.Delete(pocos);
            return Ok();
        }
    }
}
