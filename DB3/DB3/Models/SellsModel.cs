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
        public int price { get; set; }
        [Required]
        public int total { get; set; }
        

        public int getMedicine(string name, string type, string weight)
        {
            DB3Entities1 entity = new DB3Entities1();
            List<Medicine> l = entity.prMedicines().ToList();
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
    }
}