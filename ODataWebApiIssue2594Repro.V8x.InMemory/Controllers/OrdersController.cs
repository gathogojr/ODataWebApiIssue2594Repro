using System;
using System.Collections.Generic;
using System.Linq;
using ODataWebApiIssue2594Repro.V8x.InMemory.Models;
using ODataWebApiIssue2594Repro.V8x.InMemory.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Extensions;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace ODataWebApiIssue2594Repro.V8x.InMemory.Controllers
{
    public class OrdersController : ODataController
    {
        private static Random random = new Random();
        private static IList<Order> orders = new List<Order>(
            Enumerable.Range(1, 6).Select(idx => new Order
            {
                Id = idx,
                Amount = random.Next(1, 9) * 10
            }));

        public ActionResult Get(ODataQueryOptions<Order> queryOptions)
        {
            var querySettings = new ODataQuerySettings { PageSize = 2 };
            var result = queryOptions.ApplyTo(orders.AsQueryable(), querySettings) as IEnumerable<Order>;

            return Ok(new PagedResponse<Order>(result, Request.ODataFeature().NextLink));
        }
    }
}
