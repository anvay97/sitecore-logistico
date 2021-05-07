using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sitecore.Mvc;
using Sitecore.Data;
using Sitecore.Mvc.Presentation;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Data.Fields;

namespace Logistico.Feature.Services.Controllers
{
    public class ServicesController : Controller
    {
        // GET: Services
        public ActionResult GetCommonServices()
        {
            List<Item> commonServicesListItems = new List<Item>();
            Database db = Sitecore.Context.Database;
            string datasourcePath = RenderingContext.Current.Rendering.DataSource;
            Item commonServices = db.GetItem(datasourcePath);

            if (commonServices != null)
            {
                commonServicesListItems = commonServices.GetChildren().ToList();
                commonServicesListItems = commonServicesListItems.Where(x => x.Fields["Featured Service"].Value != "1").ToList();
            }
            
            return View("/Views/Features/Services/CommonServices.cshtml", commonServicesListItems);

        }

        public ActionResult GetFeaturedService()
        {
            Database db = Sitecore.Context.Database;
            string datasourcePath = RenderingContext.Current.Rendering.DataSource;
            Item services = db.GetItem(datasourcePath);
            List<Item> featuredServices = services != null ? services.GetChildren().ToList() : null;
            featuredServices = featuredServices.Where(x => x.Fields["Featured Service"].Value == "1").ToList();
            return View("/Views/Features/Services/FeaturedServices.cshtml", featuredServices);
        }

        public ActionResult GetServiceListing()
        {
            Database db = Sitecore.Context.Database;
            string datasourcePath = RenderingContext.Current.Rendering.DataSource;
            Item services = db.GetItem(datasourcePath);
            List<Item> servicesListing = services != null ? services.GetChildren().ToList() : null;
            return View("/Views/Features/Services/ServiceListing.cshtml", servicesListing);
        }
    }
}