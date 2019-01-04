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
        // GET: api/Search

        [Route("users")]
        [HttpGet]
        public IHttpActionResult Get()
        {
            try
            {
                var users = profile.GetAllUsers(User.Identity.GetUserName());
                return Ok(users);
            }
            catch {
                return BadRequest();
            }
            
        }

        // GET: api/Search/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Search
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Search/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Search/5
        public void Delete(int id)
        {
        }
    }
}
