using DatingSida.Repository;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DatingSida.Controllers.api
{
    [RoutePrefix("api/visitor")]
    public class VisitorController : ApiController
    {
        public UserVisitor UserVisitor = new UserVisitor();

        [Route("add")]
        [HttpPost]
        public IHttpActionResult SaveVisit(List<string> uservisited) {
            try
            {
                UserVisitor.AddVisit(uservisited[0], User.Identity.GetUserId());
                return Ok();
            }
            catch
            {
                return BadRequest();

            }
        }

        [Route("get")]
        [HttpGet]
        public IHttpActionResult GetVisitors()
        {
            try
            {
                var users = UserVisitor.GetVisits(User.Identity.GetUserId());
                return Ok(users);
            }
            catch
            {
                return BadRequest();
            }

        }

    

    }
}
