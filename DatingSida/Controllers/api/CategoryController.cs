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
    [RoutePrefix("api/category")]
    public class CategoryController : ApiController
    {
        public UserCategory userCategory = new UserCategory();

        //Skapar en kategori
        [Route("add")]
        [HttpPost]
        public IHttpActionResult SaveCategory(List<string> values)
        {
            try
            {
                userCategory.SaveCategory(values[0], User.Identity.GetUserId());
                return Ok();
            }
            catch(Exception exc)
            {
                return BadRequest();
            }

        }

        //Lägger till en vän i en kategori.
        [Route("addfriend")]
        [HttpPost]
        public IHttpActionResult AddFriend(List<string> values)
        {
            try
            {
                userCategory.SaveFriend(values[0], User.Identity.GetUserId(), values[1]);
                return Ok();
            }
            catch (Exception exc)
            {
                return BadRequest();
            }

        }
    }
}
