using Elasticsearch_webapp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Elasticsearch.Net;
using Nest;

namespace Elasticsearch_webapp.Controllers
{
    public class queryController : Controller
    {
        private readonly ElasticClient _client;

        public queryController(ElasticClient client)
        {
            _client = client;
        }



        [HttpPost]
        public IActionResult display(query m)
        {

            string sim = m.content;
            ISearchResponse<Book> results;

            if (!string.IsNullOrWhiteSpace(sim))
            {
                results = _client.Search<Book>(s => s
                    .Query(q => q
                        .Match(t => t
                            .Field(f => f.Title)
                            .Query(sim)
                        )
                    )
                );
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
            return View(results);

        }
    }
}
