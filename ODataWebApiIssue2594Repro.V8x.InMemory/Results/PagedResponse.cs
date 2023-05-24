using System.Collections.Generic;
using System;
using System.Collections;

namespace ODataWebApiIssue2594Repro.V8x.InMemory.Results
{
    public class PagedResponse<TModel> : IEnumerable<TModel>, IEnumerable
    {
        public IEnumerable<TModel> Items { get; set; }

        public string NextPageLink { get; set; }

        public PagedResponse(IEnumerable<TModel> results, Uri nextPageLink)
        {
            Items = results;
            NextPageLink = nextPageLink?.AbsoluteUri;
        }

        public IEnumerator<TModel> GetEnumerator()
        {
            return Items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Items.GetEnumerator();
        }
    }
}
