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
            DB3Entities2 entity = new DB3Entities2();
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
            DB3Entities2 entity = new DB3Entities2();
            Stock s = new Stock();
            s.Quantity = q;
            s.Medicine_Id = med_id;
            entity.Stocks.Add(s);
            entity.SaveChanges();
        }
        public void setquantity(int med_id, int q)
        {
            DB3Entities2 entity = new DB3Entities2();
            var s = entity.Stocks.Where(x => x.Medicine_Id == med_id).First();
            s.Quantity = q;
            entity.SaveChanges();
        }
       
    }
}