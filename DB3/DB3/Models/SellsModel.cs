using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DB3.Models
{
    public class SellsModel
    {
        public int id { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime date { get; set; }
        [Required]
        public int quantity { get; set; }
        
        [Required]
        public int total { get; set; }
        

        public int getMedicine(string name, string type, string weight)
        {
            DB3Entities2 entity = new DB3Entities2();
            List<Medicine> l = entity.Medicines.ToList();
            //List<Medicine> l = entity.Medicines.ToList();
            foreach(Medicine m in l)
            {
                int id = m.Medicine_id;
                if((m.Medicine_Name  == name) && ( m.Type == type) && (m.Weight == weight))
                {
                    return m.Medicine_id;
                }
            }
            return id;

        }
        public List<SellsModel> getlist()
        {
            DB3Entities2 entity = new DB3Entities2();
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
            }
            return sl;
        }
        public void addsell(SellsModel obj)
        {
              DB3Entities2 entity = new DB3Entities2();
              Sell s = new Sell();
              s.Quantity = obj.quantity;
              s.Total = obj.total;
              entity.Sells.Add(s);
              entity.SaveChanges();
              
        }
        public bool edited(int id , SellsModel sm)
        {
            DB3Entities2 entity = new DB3Entities2();
            List<Sell> l = entity.Sells.ToList();
            bool result = false;
            foreach (Sell s in l)
            {
                if (s.Sell_Id == id)
                {
                    sm.date = Convert.ToDateTime(s.Date);
                    sm.quantity = Convert.ToInt32(s.Quantity);
                    sm.total = Convert.ToInt32(s.Total);
                    result = true;
                }
            }
            return result;
        }
        public SellsModel getdetail(int id)
        {
            DB3Entities2 entity = new DB3Entities2();
            List<Sell> l = entity.Sells.ToList();
            SellsModel sm = new SellsModel();
            foreach (Sell s in l)
            {
                if (s.Sell_Id == id)
                {
                    sm.date = Convert.ToDateTime(s.Date);
                    sm.quantity = Convert.ToInt32(s.Quantity);
                    sm.total = Convert.ToInt32(s.Total);
                }
            }
            return sm;
        }
    }
}