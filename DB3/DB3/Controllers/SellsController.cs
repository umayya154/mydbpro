using DB3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DB3.Controllers
{
    public class SellsController : Controller
    {
        // GET: Sells
        public ActionResult SellList()
        {
            List<SellsModel> l = new List<SellsModel>();

            return View(l);
        }

        // GET: Sells/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Sells/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sells/Create
        [HttpPost]
        public ActionResult SellAdd(SellsModel obj)
        {
            try
            {
                // TODO: Add insert logic here
                /*DB3Entities1 entity = new DB3Entities1();
                Sell s = new Sell();
                s.Quantity = obj.quantity;
                s.Price = obj.price;
                s.Total = obj.total;
                s.Medicine_id = obj.getMedicine(obj.medicine_Name, obj.type, obj.weight);
                entity.Sells.Add(s);
                entity.SaveChanges();
                */
                return RedirectToAction("SellList");
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        // GET: Sells/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Sells/Edit/5
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

        // GET: Sells/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Sells/Delete/5
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
