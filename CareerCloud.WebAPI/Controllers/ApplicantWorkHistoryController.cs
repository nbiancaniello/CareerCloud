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
    public class ApplicantWorkHistoryController : ApiController
    {
        private ApplicantWorkHistoryLogic _logic;

        public ApplicantWorkHistoryController()
        {
            var repo = new EFGenericRepository<ApplicantWorkHistoryPoco>(false);
            _logic = new ApplicantWorkHistoryLogic(repo);
        }

        [HttpGet]
        [Route("workhistory/{id}")]
        [ResponseType(typeof(ApplicantWorkHistoryPoco))]
        public IHttpActionResult GetApplicantWorkHistory(Guid Id)
        {
            ApplicantWorkHistoryPoco poco = _logic.Get(Id);
            if(poco == null)
            {
                return NotFound();
            }

            return Ok(poco);
        }

        [HttpGet]
        [Route("workhistory/")]
        [ResponseType(typeof(List<ApplicantWorkHistoryPoco>))]
        public IHttpActionResult GetApplicantWorkHistory()
        {
            List<ApplicantWorkHistoryPoco> poco = _logic.GetAll();
            if (poco == null)
            {
                return NotFound();
            }

            return Ok(poco);
        }

        [HttpPost]
        [Route("workhistory/")]
        public IHttpActionResult PostApplicantWorkHistory([FromBody] ApplicantWorkHistoryPoco[] pocos)
        {
            _logic.Add(pocos);
            return Ok();
        }

        [HttpPut]
        [Route("workhistory/")]
        public IHttpActionResult PutApplicantWorkHistory([FromBody] ApplicantWorkHistoryPoco[] pocos)
        {
            _logic.Update(pocos);
            return Ok();
        }

        [HttpDelete]
        [Route("workhistory/")]
        public IHttpActionResult DeleteApplicantWorkHistory([FromBody] ApplicantWorkHistoryPoco[] pocos)
        {
            _logic.Delete(pocos);
            return Ok();
        }
    }
}
