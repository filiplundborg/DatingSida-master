using DatingSida.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DatingSida.Controllers.api
{
    [RoutePrefix("api/match")]
    public class MatchController : ApiController
    {
        public UserRequest request = new UserRequest();



        [Route("matching")]
        [HttpPost]
        public IHttpActionResult Matching(List<string> matches)
        {
            try
            {
                var result = request.Match(matches[0], matches[1]);

                return Ok(result);
            }
            catch
            {
                return BadRequest();
            }
        }

        [Route("searchmatch")]
        [HttpPost]
        public IHttpActionResult SearchMatch(List<string> matches)
        {
            try
            {
                var result = request.SearchMatch(matches[0], matches[1]);

                return Ok(result);
            }
            catch
            {
                return BadRequest();
            }
        }

    }
}