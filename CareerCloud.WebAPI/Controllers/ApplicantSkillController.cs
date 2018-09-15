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
    public class ApplicantSkillController : ApiController
    {
        private ApplicantSkillLogic _logic;

        public ApplicantSkillController()
        {
            var repo = new EFGenericRepository<ApplicantSkillPoco>(false);
            _logic = new ApplicantSkillLogic(repo);
        }

        [HttpGet]
        [Route("skill/{id}")]
        [ResponseType(typeof(ApplicantSkillPoco))]
        public IHttpActionResult GetApplicantSkill(Guid Id)
        {
            ApplicantSkillPoco poco = _logic.Get(Id);
            if(poco == null)
            {
                return NotFound();
            }

            return Ok(poco);
        }

        [HttpGet]
        [Route("skill/")]
        [ResponseType(typeof(List<ApplicantSkillPoco>))]
        public IHttpActionResult GetApplicantSkill()
        {
            List<ApplicantSkillPoco> poco = _logic.GetAll();
            if (poco == null)
            {
                return NotFound();
            }

            return Ok(poco);
        }

        [HttpPost]
        [Route("skill/")]
        public IHttpActionResult PostApplicantSkill([FromBody] ApplicantSkillPoco[] pocos)
        {
            _logic.Add(pocos);
            return Ok();
        }

        [HttpPut]
        [Route("skill/")]
        public IHttpActionResult PutApplicantSkill([FromBody] ApplicantSkillPoco[] pocos)
        {
            _logic.Update(pocos);
            return Ok();
        }

        [HttpDelete]
        [Route("skill/")]
        public IHttpActionResult DeleteApplicantSkill([FromBody] ApplicantSkillPoco[] pocos)
        {
            _logic.Delete(pocos);
            return Ok();
        }
    }
}
