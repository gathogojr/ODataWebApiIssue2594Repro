using System.Collections.Generic;
using ODataWebApiIssue2594Repro.V7x.SqlServer.Data;
using ODataWebApiIssue2594Repro.V7x.SqlServer.Lib;
using ODataWebApiIssue2594Repro.V7x.SqlServer.Models;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNet.OData.Query;
using Microsoft.AspNetCore.Mvc;

namespace ODataWebApiIssue2594Repro.V7x.SqlServer.Controllers
{
    public class OrdersController : ODataController
    {
        private readonly V7xDbContext db;

        public OrdersController(V7xDbContext db)
        {
            this.db = db;
        }

        public ActionResult Get(ODataQueryOptions<Order> queryOptions)
        {
            var querySettings = new ODataQuerySettings { PageSize = 2 };
            var result = queryOptions.ApplyTo(this.db.Orders, querySettings) as IEnumerable<Order>;

            return Ok(new PagedResponse<Order>(result, Request.ODataFeature().NextLink));
        }
    }
}