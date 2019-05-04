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
    }
}