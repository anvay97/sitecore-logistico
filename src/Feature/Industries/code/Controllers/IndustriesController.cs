using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Sitecore.Data;
using Sitecore.Mvc.Presentation;
using Sitecore.Data.Items;

namespace Logistico.Feature.Industries.Controllers
{
    public class IndustriesController : Controller
    {
        public ActionResult GetIndustriesListing()
        {
            Database db = Sitecore.Context.Database;
            string datasourcePath = RenderingContext.Current.Rendering.DataSource;
            Item industries = db.GetItem(datasourcePath);
            List<Item> industriesListing = industries != null ? industries.GetChildren().ToList() : null;
            return View("/Views/Features/Industries/IndustriesListing.cshtml", industriesListing);
        }
    }
}