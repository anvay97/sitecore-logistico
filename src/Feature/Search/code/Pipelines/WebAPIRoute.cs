using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Sitecore;
using Sitecore.Mvc;
using Sitecore.Pipelines;


namespace Logistico.Feature.Search.Pipelines
{
    public class WebAPIRoute
    {
        public virtual void Process(PipelineArgs args)
        {
            RouteTable.Routes.MapRoute("search", "api/search/{action}/", new { controller = "search" });
        }

    }
}