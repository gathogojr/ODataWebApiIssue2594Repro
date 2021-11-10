using System;
using System.Collections.Generic;
using System.Linq;
using ODataWebApiIssue2594Repro.V7x.Models;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;

namespace ODataWebApiIssue2594Repro.V7x.Controllers
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

        [EnableQuery(PageSize = 2)]
        public ActionResult Get()
        {
            return Ok(orders);
        }

        [EnableQuery]
        public ActionResult Get([FromODataUri] int key)
        {
            var item = orders.SingleOrDefault(d => d.Id.Equals(key));

            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }

        public ActionResult Post([FromBody] Order order)
        {
            return Created(new Uri($"{Request.Scheme}://{Request.Host}{Request.Path}/{order.Id}"), order);
        }

        public ActionResult Put([FromODataUri] int key, [FromBody] Order order)
        {
            return Accepted();
        }

        public ActionResult Patch([FromODataUri] int key, [FromBody] Delta<Order> delta)
        {
            return Accepted();
        }

        [AcceptVerbs("POST", "PUT")]
        public ActionResult CreateRef([FromODataUri] int key, [FromODataUri] string navigationProperty, [FromBody] Uri link)
        {
            return Accepted();
        }

        [AcceptVerbs("DELETE")]
        public ActionResult DeleteRef([FromODataUri] int key, [FromODataUri] string navigationProperty, [FromODataUri] int relatedKey)
        {
            return Accepted();
        }

        public ActionResult Delete([FromODataUri] int key)
        {
            return Accepted();
        }
    }
}
