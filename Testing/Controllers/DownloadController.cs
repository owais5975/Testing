using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Testing.Controllers
{
    [Authorize(Roles = "Admin, Viewer")]
    public class DownloadController : Controller
    {
        [Route("Download")]
        // GET: Download
        public ActionResult Download()
        {
            return View();
        }
    }
}