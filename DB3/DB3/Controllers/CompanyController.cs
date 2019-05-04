using DB3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DB3.Controllers
{
    public class CompanyController : Controller
    {
        // GET: Company
        public ActionResult CompanyList()
        {
            DB3Entities1 e = new DB3Entities1();
            List<CompanyModel> cml = new List<CompanyModel>();
            List<Company> cl = e.Companies.ToList();
            foreach(Company c in cl)
            {
                CompanyModel cm = new CompanyModel();
                cm.id = c.Company_id;
                cm.Name = c.C_Name;
                cm.Address = c.Address;
                cm.Contact = c.Mobile_Number;
                cml.Add(cm);
            }

            return View(cml);
        }

        // GET: Company/Details/5
        public ActionResult CompanyDetails(int id)
        {
            DB3Entities1 e = new DB3Entities1();
            var company = e.Companies.Where(x => x.Company_id == id).First();
            CompanyModel cm = new CompanyModel();
            cm.Name = company.C_Name;
            cm.Address = company.Address;
            cm.Contact = company.Mobile_Number;

            return View(cm);
        }

        // GET: Company/Create
        public ActionResult CompanyAdd()
        {

            return View();
        }

        // POST: Company/Create
        [HttpPost]
        public ActionResult CompanyAdd(CompanyModel obj)
        {
            try
            {
                // TODO: Add insert logic here
                Company company = new Company();
                company.C_Name = obj.Name;
                company.Address = obj.Address;
                company.Mobile_Number = obj.Contact;

                DB3Entities1 e = new DB3Entities1();
                e.Companies.Add(company);
                e.SaveChanges();

                ViewBag.message = "Data is Successfully added";
                //Session["CompanyId"] = company.Company_id;
                return RedirectToAction("CompanyDetails", new { id = company.Company_id });
            }
            catch(Exception ex)
            {
                //ViewBag.message = "Data is not added ";
                throw ex;
            }
        }

        // GET: Company/Edit/5
        public ActionResult CompanyEdit(int id)
        {
            DB3Entities1 entity = new DB3Entities1();
            var company = entity.Companies.Where(x => x.Company_id == id).First();
            CompanyModel cm = new CompanyModel();
            cm.Name = company.C_Name;
            cm.Address = company.Address;
            cm.Contact = company.Mobile_Number;

            return View(cm);
          
        }

        // POST: Company/Edit/5
        [HttpPost]
        public ActionResult CompanyEdit(int id, CompanyModel obj)
        {
            try
            {
                // TODO: Add update logic here
                DB3Entities1 entity = new DB3Entities1();
                var company = entity.Companies.Where(x => x.Company_id == id).First();
               // Company c = new Company();
                company.C_Name = obj.Name;
                company.Address = obj.Address;
                company.Mobile_Number = obj.Contact;
                //e.Companies.Add(c);
                entity.SaveChanges();

                ViewBag.message = "Data is Successfully edited";
                return RedirectToAction("CompanyDetails", new { id = company.Company_id });
            }
            catch(Exception ex)
            {
               throw ex;
            }
        }

        // GET: Company/Delete/5
        public ActionResult CompanyDelete(int id)
        {
            DB3Entities1 entity = new DB3Entities1();
            var c = entity.Companies.Where(x => x.Company_id == id).First();
            CompanyModel cm = new CompanyModel();
            cm.Name = c.C_Name;
            cm.Address = c.Address;
            cm.Contact = c.Mobile_Number;
            return View(cm);
        }

        // POST: Company/Delete/5
        [HttpPost]
        public ActionResult CompanyDelete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                DB3Entities1 entity = new DB3Entities1();
                var c = entity.Companies.Where(x => x.Company_id == id).First();
                entity.Companies.Remove(c);
                entity.SaveChanges();
                return RedirectToAction("CompanyList");
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
