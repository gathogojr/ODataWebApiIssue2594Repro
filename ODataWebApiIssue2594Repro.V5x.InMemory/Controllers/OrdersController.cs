using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.OData;
using System.Web.Http.OData.Extensions;
using System.Web.Http.OData.Query;
using ODataWebApiIssue2594Repro.V5x.InMemory.Models;
using ODataWebApiIssue2594Repro.V5x.InMemory.Results;

namespace ODataWebApiIssue2594Repro.V5x.InMemory.Controllers
{
    public class OrdersController : ODataController
    {
        private static Random random = new Random();
        private static IList<Order> orders = new List<Order>(
            Enumerable.Range(1, 6).Select(idx =>
            {
                var customerId = ((idx - 1) / 2) + 1;

                return new Order
                {
                    Id = idx,
                    Amount = random.Next(1, 9) * 10
                };
            }));

        public IHttpActionResult Get(ODataQueryOptions<Order> queryOptions)
        {
            var querySettings = new ODataQuerySettings { PageSize = 2 };
            var result = queryOptions.ApplyTo(orders.AsQueryable(), querySettings) as IEnumerable<Order>;

            return Ok(new PagedResponse<Order>(result, Request.ODataProperties().NextLink));
        }
    }
}