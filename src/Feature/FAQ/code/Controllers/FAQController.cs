using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Sitecore.Data.Items;

namespace Logistico.Feature.FAQ.Controllers
{
    public class FAQController : Controller
    {
        // GET: FAQ
        public ActionResult GetFAQ()
        {
            List<Item> FAQItems = null;
            Item ServiceItem = Sitecore.Context.Item;
            if (ServiceItem != null)
            {
                FAQItems = ServiceItem.GetChildren().ToList().Where(x => x.TemplateID.ToString() == "{DB906AD8-45D9-4C6A-9CBC-9AB75981D647}").SingleOrDefault().GetChildren().ToList();
            }
            return View("/Views/Features/FAQ/FAQsRendering.cshtml", FAQItems);
        }
    }
}