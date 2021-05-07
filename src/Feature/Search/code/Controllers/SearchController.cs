using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Sitecore.Mvc.Controllers;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.SearchTypes;
using Sitecore.ContentSearch.Linq.Utilities;
using SolrNet;
using SolrNet.Commands.Parameters;
using Sitecore.ContentSearch.SolrProvider.SolrNetIntegration;

namespace Logistico.Feature.Search.Controllers
{
    public class SearchController : SitecoreController
    {
        // GET: Search
        public SolrQueryResults<SitecoreUISearchResultItem> GetSearchResult(string searchTerm)
        {
            //List<SearchResultItem> matches;
            SolrQueryResults<SitecoreUISearchResultItem> results = null;

            using (var context = ContentSearchManager.GetIndex("sitecore_custom_index").CreateSearchContext())
            {
                //var predicate = PredicateBuilder.True<SearchResultItem>();

                // must have this (.and)
                //predicate = predicate.And(p => p.Paths.Contains(bookFolderItem.ID));

                // must have this (.and)
                //predicate = predicate.And(p => p.Name.Contains(searchTerm));

                //matches = context.GetQueryable<SearchResultItem>().Where(predicate).ToList();

                var input = string.IsNullOrEmpty(searchTerm) ? "*" : searchTerm.Replace(" ","+");
                string q = string.Format("(_name:{0} OR " +
                                          "title_t:{0} OR " +
                                        "description_t:{0} OR " +
                                        "promo_title_t:{0} OR " +
                                        "promo_subtitle_t:{0} OR " +
                                        "counter_text_t:{0} OR " +
                                        "counter_number_t:{0} OR " +
                                        "author_name_t:{0} OR " +
                                        "author_description_t:{0} OR " +
                                        "question_t:{0} OR " +
                                        "answer_t:{0} OR " +
                                        "document_title_t:{0} OR " +
                                        "document_summary_t:{0} OR " +
                                        "industry_title_t:{0} OR " +
                                        "industry_summary_t:{0} OR " +
                                        "industry_description_t:{0} OR " +
                                         "service_title_t::{0} OR " +
                                         "service_summary_t:{0} OR " +
                                         "service_description_t:{0})", input);
                var options = new QueryOptions {
                   
                };
                results = context.Query<SitecoreUISearchResultItem>(q, options); 
            }
            return results;
        }

        public ActionResult SearchResult(string searchTerm)
        {
            //List<SearchResultItem> searchResults = GetSearchResult(searchTerm);
            SolrQueryResults<SitecoreUISearchResultItem> searchResults = GetSearchResult(searchTerm);
            return View("/Views/Features/Search/SearchResults.cshtml", searchResults);
        }
    }
}