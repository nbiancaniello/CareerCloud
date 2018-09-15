using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace CareerCloud.WebAPI.Controllers
{
    [RoutePrefix("api/careercloud/company/v1")]
    public class CompanyDescriptionController : ApiController
    {
        private CompanyDescriptionLogic _logic;

        public CompanyDescriptionController()
        {
            var repo = new EFGenericRepository<CompanyDescriptionPoco>(false);
            _logic = new CompanyDescriptionLogic(repo);
        }

        [HttpGet]
        [Route("description/{id}")]
        [ResponseType(typeof(CompanyDescriptionPoco))]
        public IHttpActionResult GetCompanyDescription(Guid Id)
        {
            CompanyDescriptionPoco poco = _logic.Get(Id);
            if(poco == null)
            {
                return NotFound();
            }

            return Ok(poco);
        }

        [HttpGet]
        [Route("description/")]
        [ResponseType(typeof(List<CompanyDescriptionPoco>))]
        public IHttpActionResult GetCompanyDescription()
        {
            List<CompanyDescriptionPoco> poco = _logic.GetAll();
            if (poco == null)
            {
                return NotFound();
            }

            return Ok(poco);
        }

        [HttpPost]
        [Route("description/")]
        public IHttpActionResult PostCompanyDescription([FromBody] CompanyDescriptionPoco[] pocos)
        {
            _logic.Add(pocos);
            return Ok();
        }

        [HttpPut]
        [Route("description/")]
        public IHttpActionResult PutCompanyDescription([FromBody] CompanyDescriptionPoco[] pocos)
        {
            _logic.Update(pocos);
            return Ok();
        }

        [HttpDelete]
        [Route("description/")]
        public IHttpActionResult DeleteCompanyDescription([FromBody] CompanyDescriptionPoco[] pocos)
        {
            _logic.Delete(pocos);
            return Ok();
        }
    }
}
