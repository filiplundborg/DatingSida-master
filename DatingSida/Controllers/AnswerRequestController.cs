using DatingSida.Models.ViewModel;
using DatingSida.Repository;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DatingSida.Controllers
{
    [Authorize]
    public class AnswerRequestController : Controller
    {
        // GET: AnswerRequest
        public ActionResult Index()
        {
            var requests = new UserRequest();
            var model = new AnswerRequestViewModel();
            model.requests = requests.FillModel(User.Identity.GetUserName());
            return View(model);
        }
    }
}