using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCProduct;

namespace MVCProduct.Controllers
{
    public class Customer_TableController : Controller
    {
        private AssignmentsEntities db = new AssignmentsEntities();

        // GET: Customer_Table
        public ActionResult Index()
        {
            var customer_Table = db.Customer_Table.Include(c => c.ProductTable);
            return View(customer_Table.ToList());
        }

        // GET: Customer_Table/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer_Table customer_Table = db.Customer_Table.Find(id);
            if (customer_Table == null)
            {
                return HttpNotFound();
            }
            return View(customer_Table);
        }

        // GET: Customer_Table/Create
        public ActionResult Create()
        {
            ViewBag.ProductId = new SelectList(db.ProductTables, "ProductId", "ProductName");
            return View();
        }

        // POST: Customer_Table/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CustomerId,CustomerName,ProductId")] Customer_Table customer_Table)
        {
            if (ModelState.IsValid)
            {
                db.Customer_Table.Add(customer_Table);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProductId = new SelectList(db.ProductTables, "ProductId", "ProductName", customer_Table.ProductId);
            return View(customer_Table);
        }

        // GET: Customer_Table/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer_Table customer_Table = db.Customer_Table.Find(id);
            if (customer_Table == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductId = new SelectList(db.ProductTables, "ProductId", "ProductName", customer_Table.ProductId);
            return View(customer_Table);
        }

        // POST: Customer_Table/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CustomerId,CustomerName,ProductId")] Customer_Table customer_Table)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer_Table).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductId = new SelectList(db.ProductTables, "ProductId", "ProductName", customer_Table.ProductId);
            return View(customer_Table);
        }

        // GET: Customer_Table/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer_Table customer_Table = db.Customer_Table.Find(id);
            if (customer_Table == null)
            {
                return HttpNotFound();
            }
            return View(customer_Table);
        }

        // POST: Customer_Table/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer_Table customer_Table = db.Customer_Table.Find(id);
            db.Customer_Table.Remove(customer_Table);
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
