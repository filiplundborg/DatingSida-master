using DatingSida.Models.ViewModel;
using DatingSida.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DatingSida.Controllers.api
{
    [RoutePrefix("api/message")]
    public class MessageController : ApiController
    {
        public UserMessage usermessage = new UserMessage();

        [Route("send")]
        [HttpPost]
        public IHttpActionResult SaveMessage(List<string> message) {
            try
            {
                var model = new UserMessageViewModel
                {
                    DateSent = DateTime.Now,
                    SenderId = message[0],
                    ReceiverId = message[1],
                    Post = message[2]
                };
                usermessage.SaveMessage(model);

                return Ok();
            }
            catch
            {
                return BadRequest();
            }

        }
   
    }
}
