using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.OData;
using System.Web.Http.OData.Extensions;
using System.Web.Http.OData.Query;
using ODataWebApiIssue2594Repro.V5x.Data;
using ODataWebApiIssue2594Repro.V5x.SqlServer.Models;
using ODataWebApiIssue2594Repro.V5x.SqlServer.Results;

namespace ODataWebApiIssue2594Repro.V5x.SqlServer.Controllers
{
    public class OrdersController : ODataController
    {
        private readonly V5XDbContext db;

        public OrdersController(V5XDbContext db)
        {
            this.db = db;
        }

        public IHttpActionResult Get(ODataQueryOptions<Order> queryOptions)
        {
            var querySettings = new ODataQuerySettings { PageSize = 2 };
            var result = queryOptions.ApplyTo(db.Orders, querySettings) as IEnumerable<Order>;

            return Ok(new PagedResponse<Order>(result, Request.ODataProperties().NextLink));
        }
    }
}