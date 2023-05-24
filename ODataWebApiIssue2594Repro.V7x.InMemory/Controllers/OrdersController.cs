using System;
using System.Collections.Generic;
using System.Linq;
using ODataWebApiIssue2594Repro.V7x.InMemory.Lib;
using ODataWebApiIssue2594Repro.V7x.InMemory.Models;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNet.OData.Query;
using Microsoft.AspNetCore.Mvc;

namespace ODataWebApiIssue2594Repro.V7x.InMemory.Controllers
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

        public ActionResult Get(ODataQueryOptions<Order> queryOptions)
        {
            var querySettings = new ODataQuerySettings { PageSize = 2 };
            var result = queryOptions.ApplyTo(orders.AsQueryable(), querySettings) as IEnumerable<Order>;

            return Ok(new PagedResponse<Order>(result, Request.ODataFeature().NextLink));
        }
    }
}