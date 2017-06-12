using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace stark.Web.Controllers
{
    public class FeaturesController : BaseController
    {
        // GET: FeaturesMVC
        //Renamed Action method[ Index() to Create() ]
        [Route("features/create")]
        public ActionResult Create()
        {
            return View();
        }
    }
}