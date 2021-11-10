using System;
using System.Collections.Generic;
using System.Linq;
using ODataWebApiIssue2594Repro.V8x.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace ODataWebApiIssue2594Repro.V8x.Controllers
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
        public ActionResult Get([FromRoute] int key)
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

        public ActionResult Put([FromRoute] int key, [FromBody] Order order)
        {
            return Accepted();
        }

        public ActionResult Patch([FromRoute] int key, [FromBody] Delta<Order> delta)
        {
            return Accepted();
        }

        [AcceptVerbs("POST", "PUT")]
        public ActionResult CreateRef([FromRoute] int key, [FromRoute] string navigationProperty, [FromBody] Uri link)
        {
            return Accepted();
        }

        [AcceptVerbs("DELETE")]
        public ActionResult DeleteRef([FromRoute] int key, [FromRoute] string navigationProperty, [FromRoute] int relatedKey)
        {
            return Accepted();
        }

        public ActionResult Delete([FromRoute] int key)
        {
            return Accepted();
        }
    }
}
