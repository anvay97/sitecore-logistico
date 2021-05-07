using System;
using System.Collections.Generic;
using System.Linq;
using Sitecore.Data.Items;
using System.Web.Mvc;

namespace Logistico.Feature.Document.Controllers
{
    public class DocumentController : Controller
    {
        // GET: Document
        public ActionResult GetDocuments()
        {
            List<Item> documentListItems = null;
            Item documentItem = Sitecore.Context.Item;
            
            if (documentItem != null)
            {
                documentListItems = documentItem.GetChildren().ToList().Where(x => x.TemplateID.ToString() == "{9FCAD58F-A563-44FA-A4E9-CE0E1D1C5493}").SingleOrDefault().GetChildren().ToList();
            }

            return View("/Views/Features/Document/Document.cshtml", documentListItems);

        }
    }
}