using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DB3.Models
{
    public class StockModel
    {
        public int id { get; set; }
        public int quantity { get; set; }
        public int medicine_id { get; set; }
    }
}