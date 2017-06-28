using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using stark.Web.Models.ViewModels;

namespace stark.Web.Controllers
{
	[RoutePrefix("support-requests")]
	public class SupportRequestsController : BaseController
	{
		[Route("create")]
		public ActionResult Create()
		{
			return View("Create");
		}

		[Route("")]
		public ActionResult Index()
		{
			return View();
		}

		[Route("{id:int}/edit")]
		public ActionResult Edit(int id)
		{
			ItemViewModel<int> viewModel = new ItemViewModel<int>();
			viewModel.Item = id;

			return View("Create", viewModel);
		}
    }
}