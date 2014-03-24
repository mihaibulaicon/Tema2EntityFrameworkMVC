using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Tema2.Database.Entitati;
using Tema2.Database;
using Tema2.Models;

namespace Tema2.Controllers
{
    public class OrderController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        public ActionResult Index()
        {
            var orders = db.Orders.Include(o => o.Customer).ToList();
            return View(orders.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Include(o => o.Customer).SingleOrDefault(x => x.OrderId == id);;
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        public ActionResult Create()
        {
            var model = new OrderModel();
            model.Order = new Order();
            model.Order.Date = DateTime.Now;
            model.CustomerList = db.Customers.ToList().Select(c => new SelectListItem() { Value = c.CustomerId.ToString(), Text = c.Name }); 
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(OrderModel model)
        {
            if (ModelState.IsValid)
            {
                model.Order.Customer = db.Customers.Find(model.Order.Customer.CustomerId);
                db.Orders.Add(model.Order);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            model.CustomerList = db.Customers.ToList().Select(c => new SelectListItem() { Value = c.CustomerId.ToString(), Text = c.Name }); 
            return View(model);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderModel model = new OrderModel();
            model.Order=db.Orders.Find(id);
            if (model.Order == null)
            {
                return HttpNotFound();
            }
            model.CustomerList = db.Customers.ToList().Select(c => new SelectListItem() { Value = c.CustomerId.ToString(), Text = c.Name }); 
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(OrderModel model)
        {
            if (ModelState.IsValid)
            {
                var order = db.Orders.Find(model.Order.OrderId);
                order.Date = model.Order.Date;
                order.Customer = db.Customers.Find(model.Order.Customer.CustomerId);
                order.Value = model.Order.Value;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            model.CustomerList = db.Customers.ToList().Select(c => new SelectListItem() { Value = c.CustomerId.ToString(), Text = c.Name }); 
            return View(model);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Order order = db.Orders.Find(id);
            db.Orders.Remove(order);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
