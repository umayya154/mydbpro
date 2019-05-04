using DB3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DB3.Controllers
{
    public class MedicineController : Controller
    {
        // GET: Medicine
        public ActionResult MedicineList()
        {
            DB3Entities1 entity = new DB3Entities1();
            List<MedicineModel> mml = new List<MedicineModel>();
            List<Medicine> ml = entity.Medicines.ToList();
            foreach(Medicine m in ml)
            {
                MedicineModel mm = new MedicineModel();
                mm.name = m.Medicine_Name;
                mm.mfg_date = m.Mfg_Date;
                mm.exp_date = Convert.ToDateTime( m.Exp_Date);
                mm.batch = m.Batch;
                mm.type = m.Type;
               // mm.weight = m.Weight;
                mm.price = Convert.ToInt32( m.Price);
                Company  c = entity.Companies.Where(x => x.Company_id == m.CompanyID).First();
                mm.company_Name = c.C_Name;
                mml.Add(mm);
            }
            return View(mml);
        }

        // GET: Medicine/Details/5
        public ActionResult MedicineDetails(int id)
        {

            DB3Entities1 entity = new DB3Entities1();
           //  var m = entity.Medicines.Where(x => x.Medicine_id == id).First();
            var m = entity.sp_docstatus(true).
            MedicineModel mm = new MedicineModel();
            mm.name = m.Medicine_Name;
            mm.mfg_date = m.Mfg_Date;
            mm.exp_date = Convert.ToDateTime(m.Exp_Date);
            mm.batch = m.Batch;
            mm.type = m.Type;
            mm.price = Convert.ToInt32(m.Price);
            var c = entity.Companies.Where(x => x.Company_id == m.CompanyID).First();
            mm.company_Name = c.C_Name;

            return View(mm);
        }

        // GET: Medicine/Create
        public ActionResult Medicineadd()
        {
           // DB3Entities1 e = new DB3Entities1();
           //e.prCompaniesName
            return View();
        }

        // POST: Medicine/Create
        [HttpPost]
        public ActionResult MedicineAdd(MedicineModel obj)
        {
            try
            {
                // TODO: Add insert logic here
                DB3Entities1 entity = new DB3Entities1();
                var medicine = new Medicine();
                medicine.Medicine_Name = obj.name;
                medicine.Mfg_Date = obj.mfg_date;
                medicine.Exp_Date = obj.exp_date;
                medicine.Type = obj.type;
                medicine.Batch = obj.batch;
                medicine.Price = obj.price;
                var c = entity.Companies.Where(x => x.C_Name == obj.company_Name).First();
                medicine.CompanyID = c.Company_id;
                
                entity.Medicines.Add(medicine);
                entity.SaveChanges();

                


                return RedirectToAction("MedicineDetails", new { id = medicine.Medicine_id });
            }
            catch
            {
                return View();
            }
        }

        // GET: Medicine/Edit/5
        public ActionResult MedicineEdit(int id)
        {
            DB3Entities1 entity = new DB3Entities1();
            var m = entity.Medicines.Where(x => x.Medicine_id == id).First();
            MedicineModel mm = new MedicineModel();
            mm.name = m.Medicine_Name;
            mm.mfg_date = m.Mfg_Date;
            mm.exp_date = Convert.ToDateTime(m.Exp_Date);
            mm.batch = m.Batch;
            mm.type = m.Type;
            mm.price = Convert.ToInt32(m.Price);
            var c = entity.Companies.Where(x => x.Company_id == m.CompanyID).First();
            mm.company_Name = c.C_Name;
            return View(mm);
        }

        // POST: Medicine/Edit/5
        [HttpPost]
        public ActionResult MedicineEdit(int id, MedicineModel obj)
        {
            try
            {
                // TODO: Add update logic here
                DB3Entities1 entity = new DB3Entities1();
                var m = entity.Medicines.Where(x => x.Medicine_id == id).First();
                
                obj.name = m.Medicine_Name;
                obj.mfg_date = m.Mfg_Date;
                obj.exp_date = Convert.ToDateTime(m.Exp_Date);
                obj.batch = m.Batch;
                obj.type = m.Type;
                obj.price = Convert.ToInt32(m.Price);
                var c = entity.Companies.Where(x => x.Company_id == m.CompanyID).First();
                obj.company_Name = c.C_Name;

                return RedirectToAction("MedicineEdit", new { id = m.Medicine_id });
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        // GET: Medicine/Delete/5
        public ActionResult MedicineDelete(int id)
        {
            DB3Entities1 entity = new DB3Entities1();
            var m = entity.Medicines.Where(x => x.Medicine_id == id).First();
            MedicineModel mm = new MedicineModel();
            mm.name = m.Medicine_Name;
            mm.mfg_date = m.Mfg_Date;
            mm.exp_date = Convert.ToDateTime(m.Exp_Date);
            mm.batch = m.Batch;
            mm.type = m.Type;
            mm.price = Convert.ToInt32(m.Price);
            var c = entity.Companies.Where(x => x.Company_id == m.CompanyID).First();
            mm.company_Name = c.C_Name;
            return View(mm);
        }

        // POST: Medicine/Delete/5
        [HttpPost]
        public ActionResult MedicineDelete(int id, MedicineModel m)
        {
            try
            {
                // TODO: Add delete logic here
                DB3Entities1 entity = new DB3Entities1();
               // Medicine m = entity.Medicines.Where(x => x.Medicine_id == id).First();
                entity.prDelMedicine(id);
                entity.SaveChanges();
                return RedirectToAction("MedicineList");
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
