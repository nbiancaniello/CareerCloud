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
    public class CompanyLocationController : ApiController
    {
        private CompanyLocationLogic _logic;

        public CompanyLocationController()
        {
            var repo = new EFGenericRepository<CompanyLocationPoco>(false);
            _logic = new CompanyLocationLogic(repo);
        }

        [HttpGet]
        [Route("location/{id}")]
        [ResponseType(typeof(CompanyLocationPoco))]
        public IHttpActionResult GetCompanyLocation(Guid Id)
        {
            CompanyLocationPoco poco = _logic.Get(Id);
            if(poco == null)
            {
                return NotFound();
            }

            return Ok(poco);
        }

        [HttpGet]
        [Route("location/")]
        [ResponseType(typeof(List<CompanyLocationPoco>))]
        public IHttpActionResult GetCompanyLocation()
        {
            List<CompanyLocationPoco> poco = _logic.GetAll();
            if (poco == null)
            {
                return NotFound();
            }

            return Ok(poco);
        }

        [HttpPost]
        [Route("location/")]
        public IHttpActionResult PostCompanyLocation([FromBody] CompanyLocationPoco[] pocos)
        {
            _logic.Add(pocos);
            return Ok();
        }

        [HttpPut]
        [Route("location/")]
        public IHttpActionResult PutCompanyLocation([FromBody] CompanyLocationPoco[] pocos)
        {
            _logic.Update(pocos);
            return Ok();
        }

        [HttpDelete]
        [Route("location/")]
        public IHttpActionResult DeleteCompanyLocation([FromBody] CompanyLocationPoco[] pocos)
        {
            _logic.Delete(pocos);
            return Ok();
        }
    }
}
