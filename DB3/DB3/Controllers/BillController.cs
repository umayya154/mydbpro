using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DB3.Models;

namespace DB3.Controllers
{
    public class BillController : Controller
    {
        // GET: Bill
        public ActionResult Index()
        {

            DB3Entities2 db = new DB3Entities2();
            List<Bill> b = new List<Bill>();
            List<BillViewModel> bl = new List<BillViewModel>();
            BillViewModel bi = new BillViewModel();
            foreach(Bill o in b)
            {
                bi.Date = o.Date;
               
                //bi.CustomerID = o.CustomerID;
               // Medicine c = db.Medicines.Where(x => x.Medicine_id == s.medicine_id).First();
                Order c = db.Orders.Where(x => x.order_id == o.OrderID).First();
                bi.OrderID = c.order_id;
               // bi.Price = c.Price;
               // bi.Quantity = c.Quantity;
                bl.Add(bi);
                
            }
            return View(bl);
        }

            
        

        // GET: Bill/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Bill/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Bill/Create
        [HttpPost]
        public ActionResult Create(BillViewModel s)
        {
            try
            {
                DB3Entities2 db = new DB3Entities2();
                Bill b = new Bill();
                b.Date = s.Date;
                b.Price = s.Price;
                b.Quantity = s.Quantity;
                b.CustomerID = s.CustomerID;
                b.OrderID = s.OrderID;
                db.Bills.Add(b);
                db.SaveChanges();
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Bill/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Bill/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Bill/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Bill/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
