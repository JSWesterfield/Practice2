using stark.Web.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace stark.Web.Controllers
{
    [RoutePrefix("Users")]
    public class UsersController : BaseController
    {
        [Route("Create")]
        public ActionResult Create()
        {
            return View();
        }

        [Route("")]
        public ActionResult Index()
        {
            return View();
        }

        [Route("{id:int}/edit")]
        public ActionResult Edit(int id)
        {
            ItemViewModel<int> ViewById = new ItemViewModel<int>();
            ViewById.Item = id;
            return View("Create", ViewById);
        }

        [Route("~/")]
        public ActionResult Login()
        {
            return View();
        }
    }
}