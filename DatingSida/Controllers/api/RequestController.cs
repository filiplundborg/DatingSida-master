﻿using DatingSida.Repository;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DatingSida.Controllers.api
{
    [RoutePrefix("api/request")]
    public class RequestController : ApiController
    {
        public UserRequest request = new UserRequest();

        [Route("send")]
        [HttpPost]
        public IHttpActionResult SaveRequest(List<string> requested)
        {
            try
            {
                request.SaveRequest(requested[0], requested[1]);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }

        }

        [Route("get")]
        [HttpGet]
        public IHttpActionResult GetFriendRequest()
        {
            try {
                var requests = request.GetFriendRequests(User.Identity.GetUserId());
                return Ok(requests);
            }
            catch {
                return BadRequest();
            }
            
        }

        [Route("postanswer")]
        [HttpPost]
        public IHttpActionResult AnswerFriendRequest(List<string> value)
        {
            try
            {
                request.AnswerRequest(int.Parse(value[0]), true);
                return Ok();
            }
            catch (Exception exc)
            {
                return BadRequest();
            }

        }
        [Route("postanswernegative")]
        [HttpPost]
        public IHttpActionResult AnswerFriendRequestNegative(List<string> value)
        {
            try
            {
                request.AnswerRequest(int.Parse(value[0]), false);
                return Ok();
            }
            catch (Exception exc)
            {
                return BadRequest();
            }

        }
    }
}
