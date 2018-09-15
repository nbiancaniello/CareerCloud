using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace CareerCloud.WebAPI.Controllers
{
    [RoutePrefix("api/careercloud/applicant/v1")]
    public class ApplicantEducationController : ApiController
    {
        private ApplicantEducationLogic _logic;

        public ApplicantEducationController()
        {
            var repo = new EFGenericRepository<ApplicantEducationPoco>(false);
            _logic = new ApplicantEducationLogic(repo);
        }

        [HttpGet]
        [Route("education/{id}")]
        [ResponseType(typeof(ApplicantEducationPoco))]
        public IHttpActionResult GetApplicantEducation(Guid Id)
        {
            ApplicantEducationPoco poco = _logic.Get(Id);
            if(poco == null)
            {
                return NotFound();
            }

            return Ok(poco);
        }

        [HttpGet]
        [Route("education/")]
        [ResponseType(typeof(List<ApplicantEducationPoco>))]
        public IHttpActionResult GetApplicantEducation()
        {
            List<ApplicantEducationPoco> poco = _logic.GetAll();
            if (poco == null)
            {
                return NotFound();
            }

            return Ok(poco);
        }

        [HttpPost]
        [Route("education/")]
        public IHttpActionResult PostApplicantEducation([FromBody] ApplicantEducationPoco[] pocos)
        {
            _logic.Add(pocos);
            return Ok();
        }

        [HttpPut]
        [Route("education/")]
        public IHttpActionResult PutApplicantEducation([FromBody] ApplicantEducationPoco[] pocos)
        {
            _logic.Update(pocos);
            return Ok();
        }

        [HttpDelete]
        [Route("education/")]
        public IHttpActionResult DeleteApplicantEducation([FromBody] ApplicantEducationPoco[] pocos)
        {
            _logic.Delete(pocos);
            return Ok();
        }
    }
}
