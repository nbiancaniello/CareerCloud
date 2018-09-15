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
    public class ApplicantJobApplicationController : ApiController
    {
        private ApplicantJobApplicationLogic _logic;

        public ApplicantJobApplicationController()
        {
            var repo = new EFGenericRepository<ApplicantJobApplicationPoco>(false);
            _logic = new ApplicantJobApplicationLogic(repo);
        }

        [HttpGet]
        [Route("jobapplication/{id}")]
        [ResponseType(typeof(ApplicantJobApplicationPoco))]
        public IHttpActionResult GetApplicantJobApplication(Guid Id)
        {
            ApplicantJobApplicationPoco poco = _logic.Get(Id);
            if(poco == null)
            {
                return NotFound();
            }

            return Ok(poco);
        }

        [HttpGet]
        [Route("jobapplication/")]
        [ResponseType(typeof(List<ApplicantJobApplicationPoco>))]
        public IHttpActionResult GetApplicantJobApplication()
        {
            List<ApplicantJobApplicationPoco> poco = _logic.GetAll();
            if (poco == null)
            {
                return NotFound();
            }

            return Ok(poco);
        }

        [HttpPost]
        [Route("jobapplication/")]
        public IHttpActionResult PostApplicantJobApplication([FromBody] ApplicantJobApplicationPoco[] pocos)
        {
            _logic.Add(pocos);
            return Ok();
        }

        [HttpPut]
        [Route("jobapplication/")]
        public IHttpActionResult PutApplicantJobApplication([FromBody] ApplicantJobApplicationPoco[] pocos)
        {
            _logic.Update(pocos);
            return Ok();
        }

        [HttpDelete]
        [Route("jobapplication/")]
        public IHttpActionResult DeleteApplicantJobApplication([FromBody] ApplicantJobApplicationPoco[] pocos)
        {
            _logic.Delete(pocos);
            return Ok();
        }
    }
}
