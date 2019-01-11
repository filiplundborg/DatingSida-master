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
    [RoutePrefix("api/search")]
    public class SearchApiController : ApiController
    {
        public UserProfile profile = new UserProfile();
        // GET: api/Search/

        [Route("users")]
        [HttpGet]
        public IHttpActionResult Get()
        {
            try
            {
                var users = profile.GetSearchUsers(User.Identity.GetUserName());
                return Ok(users);
            }
            catch {
                return BadRequest();
            }
            
        }

        
    }
}
