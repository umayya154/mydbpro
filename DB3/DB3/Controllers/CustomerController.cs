using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DB3.Models;
using CrystalDecisions.CrystalReports.Engine;
using System.IO;

namespace DB3.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            DB3Entities2 db = new DB3Entities2();
            List<Customer> cs = db.Customers.ToList();
            List<CustomerViewModel> csv = new List<CustomerViewModel>();
            //CustomerViewModel c = new CustomerViewModel();
            foreach (Customer s in cs)
            {

                CustomerViewModel c = new CustomerViewModel();
                c.Name = s.Name;
                c.Address = s.Address;
                c.Phone = s.Phone;
                c.status = s.status;
                c.user_id = s.user_id;
                //c.status = Convert.ToInt32('Pending');
                c.city = s.city;

                csv.Add(c);
            }
                return View(csv);
        }
        //public ActionResult ExamReport()
        //{
        //    DB49E    ntities1 db = new DB49Entities1();
        //    List<Exam> exam = new List<Exam>();
        //    exam = db.Exams.ToList();


        //    ReportDocument rd = new ReportDocument();
        //    rd.Load(Path.Combine(Server.MapPath("~/Report"), "CrystalReportExam.rpt"));

        //    rd.SetDataSource(exam);

        //    Response.Buffer = false;
        //    Response.ClearContent();
        //    Response.ClearHeaders();


        //    Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
        //    stream.Seek(0, SeekOrigin.Begin);
        //    return File(stream, "application/pdf", "ExamList.pdf");
        //}
        public ActionResult CustomerReport()
        {
            DB3Entities2 db = new DB3Entities2();
            List<Customer> exam = new List<Customer>();
            exam = db.Customers.ToList();


            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/Report"), "CrystalReport1.rpt"));

            rd.SetDataSource(exam);

            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();


            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            stream.Seek(0, SeekOrigin.Begin);
            return File(stream, "application/pdf", "CustomerList.pdf");
        }

        // GET: Customer/Details/5
        public ActionResult Details(int id)
        {
            DB3Entities2 db = new DB3Entities2();
            List<Customer> cs = db.Customers.ToList();
            //userid = id;
            CustomerViewModel c = new CustomerViewModel();
            foreach (Customer s in cs)
            {
                if (s.user_id == id)
                {

                    c.Name = s.Name;
                    c.Address = s.Address;
                    c.Phone = s.Phone;
                    c.status = s.status;
                    //c.status = s.status;
                    c.city = s.city;


                }
            }
            return View(c);
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customer/Create
        [HttpPost]
        public ActionResult Create(CustomerViewModel s)
        {
            try
            {
                DB3Entities2 db = new DB3Entities2();
                Customer c = new Customer();
                c.Name = s.Name;
                c.Address = s.Address;
                c.Phone = s.Phone;
                c.status = s.status;
                c.city = s.city;
                db.Customers.Add(c);
                db.SaveChanges();

                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(int id)
        {
            DB3Entities2 db = new DB3Entities2();
            var s = db.Customers.Where(x => x.user_id == id).First();
            //List<Customer> c = db.Customers.ToList();
            CustomerViewModel cs = new CustomerViewModel();
            
                    cs.Name = s.Name;
                    cs.Address = s.Address;
                    cs.Phone = s.Phone;
                    cs.status = s.status;
                    //cs.status = Convert.ToInt32('Pending');
                    cs.city = s.city;
                
            return View(cs);
        }

        // POST: Customer/Edit/5
        [HttpPost]
        public ActionResult Edit(CustomerViewModel s,int id)
        {
            try
            {
                DB3Entities2 db = new DB3Entities2();
                var cs = db.Customers.Where(x => x.user_id == id).First();
                List<Customer> c = db.Customers.ToList();
               
                        cs.Name = s.Name;
                        cs.Address = s.Address;
                        cs.Phone = s.Phone;
                        cs.status = s.status;
                        //cs.status = Convert.ToInt32('Pending');
                        cs.city = s.city;
                        db.SaveChanges();
                    

                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Delete/5
        public ActionResult Delete(int id)
        {
            DB3Entities2 db = new DB3Entities2();
            var cs = db.Customers.Where(x => x.user_id == id).First();
           
            CustomerViewModel s = new CustomerViewModel();
           
                    s.Name = cs.Name;
                    s.Address = cs.Address;
                    s.Phone = cs.Phone;
                   // c.status = Convert.ToString(s.status);
                    s.status = cs.status;
                    s.city = cs.city;
                
            
                return View(s);
        }

        // POST: Customer/Delete/5
        [HttpPost]
        public ActionResult Delete(CustomerViewModel s,int id)
        {
            try
            {
                // TODO: Add delete logic here
                DB3Entities2 db = new DB3Entities2();
                //List<Customer> c = db.Customers.ToList();
                var del = db.Customers.Where(x => x.user_id == id).First();
                db.Customers.Remove(del);
                db.SaveChanges();
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
