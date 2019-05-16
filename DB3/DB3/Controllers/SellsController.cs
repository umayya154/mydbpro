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
           /* DB3Entities2 entity = new DB3Entities2();
            List<Sell> l = entity.Sells.ToList();
            List<SellsModel> sl = new List<SellsModel>();
            foreach(Sell s in l)
            {
                SellsModel sm = new SellsModel();
                sm.date = Convert.ToDateTime(s.Date);
                sm.quantity = Convert.ToInt32( s.Quantity);
                sm.total = Convert.ToInt32(s.Total);
                sm.id = s.Sell_Id;
                sl.Add(sm);
            }*/
            SellsModel m = new SellsModel();

            return View(m.getlist());
        }

        // GET: Sells/Details/5
        public ActionResult SellDetails(int id)
        {
            SellsModel sm = new SellsModel();
            return View(sm.getdetail(id));
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
        public ActionResult SellEdit(int ID, SellsModel obj)
        {
           
                // TODO: Add update logic here
                SellsModel sm = new SellsModel();
            if (sm.edited(ID, obj) == true)
                return RedirectToAction("SellDetails", new { id = ID} );
            else
                ViewBag.Message = " Data connot be Updated";
                return RedirectToAction("SellList");

        }

        // GET: Sells/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Sells/Delete/5
        [HttpPost]
        public ActionResult SellDelete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                DB3Entities3 entity = new DB3Entities3();
                var s = entity.Sells.Where(x => x.Sell_Id == id).First();
                entity.Sells.Remove(s);
                entity.SaveChanges();
                return RedirectToAction("SellList");
            }
            catch
            {
                return View();
            }
        }
    }
}
