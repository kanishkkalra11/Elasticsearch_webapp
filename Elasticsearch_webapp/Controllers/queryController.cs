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
                results = _client.Search<Book>(s => s
                   .Query(q => q
                       .MatchAll()
                   )
                   .Aggregations(a => a
                       .Range("pageCounts", r => r
                           .Field(f => f.PageCount)
                           .Ranges(r => r.From(0),
                                   r => r.From(200).To(400),
                                   r => r.From(400).To(600),
                                   r => r.From(600)
                           )
                       )
                       .Terms("categories", t => t
                           .Field("categories.keyword")
                       )
                   )
               );
            }
            return View(results);

        }
    }
}
