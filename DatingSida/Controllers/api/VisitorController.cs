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

    
        //Hämtar senaste besöken
        [Route("getusers")]
        [HttpPost]
        public IHttpActionResult GetVisitorsPost()
        {
            try
            {
                var users = UserVisitor.GetVisits(User.Identity.GetUserId());
                var list = new List<string>();
                foreach (var item in users) {
                    list.Add(item.UserName);
                }
                
                return Ok(list);
            }
            catch
            {
                return BadRequest();
            }

        }



    }
}
