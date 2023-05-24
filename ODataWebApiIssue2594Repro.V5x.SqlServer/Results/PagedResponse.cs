using System;
using System.Collections;
using System.Collections.Generic;

namespace ODataWebApiIssue2594Repro.V5x.SqlServer.Results
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