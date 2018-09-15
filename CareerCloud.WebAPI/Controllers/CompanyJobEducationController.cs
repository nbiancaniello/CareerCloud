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
    public class CompanyJobEducationController : ApiController
    {
        private CompanyJobEducationLogic _logic;

        public CompanyJobEducationController()
        {
            var repo = new EFGenericRepository<CompanyJobEducationPoco>(false);
            _logic = new CompanyJobEducationLogic(repo);
        }

        [HttpGet]
        [Route("jobeducation/{id}")]
        [ResponseType(typeof(CompanyJobEducationPoco))]
        public IHttpActionResult GetCompanyJobEducation(Guid Id)
        {
            CompanyJobEducationPoco poco = _logic.Get(Id);
            if(poco == null)
            {
                return NotFound();
            }

            return Ok(poco);
        }

        [HttpGet]
        [Route("jobeducation/")]
        [ResponseType(typeof(List<CompanyJobEducationPoco>))]
        public IHttpActionResult GetCompanyJobEducation()
        {
            List<CompanyJobEducationPoco> poco = _logic.GetAll();
            if (poco == null)
            {
                return NotFound();
            }

            return Ok(poco);
        }

        [HttpPost]
        [Route("jobeducation/")]
        public IHttpActionResult PostCompanyJobEducation([FromBody] CompanyJobEducationPoco[] pocos)
        {
            _logic.Add(pocos);
            return Ok();
        }

        [HttpPut]
        [Route("jobeducation/")]
        public IHttpActionResult PutCompanyJobEducation([FromBody] CompanyJobEducationPoco[] pocos)
        {
            _logic.Update(pocos);
            return Ok();
        }

        [HttpDelete]
        [Route("jobeducation/")]
        public IHttpActionResult DeleteCompanyJobEducation([FromBody] CompanyJobEducationPoco[] pocos)
        {
            _logic.Delete(pocos);
            return Ok();
        }
    }
}
