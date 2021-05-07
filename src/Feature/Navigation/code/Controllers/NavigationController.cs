using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Mvc.Presentation;

namespace Logistico.Feature.Navigation.Controllers
{
    public class NavigationController : Controller
    {
        // GET: Navigation
        public ActionResult GetFooterLinks()
        {
            Database db = Sitecore.Context.Database;
            string datasourcePath = RenderingContext.Current.Rendering.DataSource;
            Item footerLinksItem = db.GetItem(datasourcePath);
            List<Item> footerSubItems = footerLinksItem != null ? footerLinksItem.Children.ToList() : null;
            return View("/Views/Features/Navigation/NavigationLink.cshtml", footerSubItems);

        }

        public ActionResult GetHeaderLinks()
        {
            Database db = Sitecore.Context.Database;
            string datasource = RenderingContext.Current.Rendering.DataSource;
            Item headerlinkitem = db.GetItem(datasource);
            List<Item> headersublink = headerlinkitem != null ? headerlinkitem.Children.ToList() : null;
            return View("/Views/Features/Navigation/HeaderNavigationLink.cshtml", headersublink);
        }
    }
}