using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DB3.Models
{
    public class MedicineModel
    {
        public int  id { get; set; }
        [Display(Name = "Name")]
        [Required]
        public string name { get; set; }
        [Display(Name = "Price")]
        [Required]
        public int price { get; set; }
        [Display(Name = "Mfg Date")]
        [Required]
        [DataType(DataType.Date)]
        public DateTime mfg_date  { get; set; }
        [Display(Name = "Exp Date")]
        [DataType(DataType.Date)]
        public DateTime exp_date { get; set; }
        [Display(Name = "Batch")]
        [Required]
        public string batch { get; set; }
        [Display(Name = "Type")]
        [Required]
        public string type { get; set; }
        [Display(Name = "Weight")]
       
        public string weight { get; set; }
        [Display(Name = "Company Name")]
        [Required]
        public string company_Name { get; set; }
        [Required]
        public int Quantity { set; get; }

        public int getquantity(int med_id)
        {
            DB3Entities3 entity = new DB3Entities3();
            List<Stock> l = entity.Stocks.ToList();
            foreach (Stock s in l)
            {
                if (s.Medicine_Id == med_id)
                {
                    return s.Quantity;
                }
            }
            return 0;
        }
        public void addquantity(int med_id, int q)// q is quantity
        {
            DB3Entities3 entity = new DB3Entities3();
            Stock s = new Stock();
            s.Quantity = q;
            s.Medicine_Id = med_id;
            entity.Stocks.Add(s);
            entity.SaveChanges();
        }
        public void setquantity(int med_id, int q)
        {
            DB3Entities3 entity = new DB3Entities3();
            var s = entity.Stocks.Where(x => x.Medicine_Id == med_id).First();
            s.Quantity = q;
            entity.SaveChanges();
        }
        //public void editquantity(int )
        public void medicineEdit(int id, MedicineModel obj)
        {
            DB3Entities3 entity = new DB3Entities3();
            List<Medicine> ml = entity.Medicines.ToList();
            MedicineModel mm = new MedicineModel();
            foreach (Medicine medicine in ml)
            {
                if (medicine.Medicine_id == id)
                {
                    medicine.Medicine_Name = obj.name;
                    medicine.Mfg_Date = obj.mfg_date;
                    medicine.Exp_Date = obj.exp_date;
                    medicine.Type = obj.type;
                    medicine.Batch = obj.batch;
                    medicine.Price = obj.price;
                    CompanyModel c = new CompanyModel();
                    medicine.CompanyID = c.getcompany_id(obj.company_Name);
                    this.setquantity(id, obj.Quantity);
                   
                }
            }
            entity.SaveChanges();
        }
       public MedicineModel getmedicine(int id)
        {
            DB3Entities3 entity = new DB3Entities3();
            List<Medicine> ml = entity.Medicines.ToList();
            MedicineModel mm = new MedicineModel();
            foreach (Medicine m in ml)
            {
                if (m.Medicine_id == id)
                {
                    mm.name = m.Medicine_Name;
                    mm.mfg_date = m.Mfg_Date;
                    mm.exp_date = Convert.ToDateTime(m.Exp_Date);
                    mm.batch = m.Batch;
                    mm.type = m.Type;
                    mm.price = Convert.ToInt32(m.Price);
                    CompanyModel c = new CompanyModel();
                    mm.company_Name = c.getcompany_name(Convert.ToInt32(m.CompanyID));
                    mm.Quantity = mm.getquantity(id);
                    return mm;
                }
            }
            return mm;
        }
    }
}