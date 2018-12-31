using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MVC_Web_API_orders.Models;

namespace MVC_Web_API_orders.Controllers
{
    public class OrdersAPIController : ApiController
    {
        MyDbContext db = new MyDbContext();
        // GET: api/OrdersAPI
        public IEnumerable<OrderModel> Get()
        {
            return db.Orders.ToList();
        }

        // GET: api/OrdersAPI/5
        public OrderModel Get(int id)
        {
            return db.Orders.FirstOrDefault(o => o.orderid==id);
        }

        // POST: api/OrdersAPI
        public bool Post([FromBody]OrderModel value)
        {
            db.Orders.Add(value);
            db.SaveChanges();
            return true;
        }

        // PUT: api/OrdersAPI/5
        public void Put(int id, [FromBody]OrderModel value)
        {
            var dbmodel = db.Orders.FirstOrDefault(o => o.orderid == id);
            dbmodel.customermobileno = value.customermobileno;
            dbmodel.itemname = value.itemname;
            dbmodel.itemprice = value.itemprice;
            dbmodel.itemquantity = value.itemquantity;
            db.SaveChanges();
        }

        // DELETE: api/OrdersAPI/5
        public void Delete(int id)
        {
            var model = (from o in db.Orders
                         where o.orderid == id
                         select o).FirstOrDefault();
            db.Orders.Remove(model);
            db.SaveChanges();
        }

        [Route("api/OrdersAPI/Search/{key}")]
        [HttpGet]
        public IEnumerable<OrderModel> Search(string key)
        {
            var model = db.Orders.Where(o => o.customermobileno.Contains(key) || o.itemname.Contains(key)).ToList();
            return model;
                                        
        }
    }
}
