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

        //Sparar ett meddelande.
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
        //Tar bort ett meddelande
        [Route("delete")]
        [HttpPost]
        public IHttpActionResult DeleteMessage(List<string> id)
        {
            try
            {
                int messageID = int.Parse(id[0]);
                usermessage.DeleteMessage(messageID);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }

        }

    }
}
