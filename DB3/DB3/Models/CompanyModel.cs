using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DB3.Models
{
    public class CompanyModel
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Contact { get; set; }
        public string getcompany_name(int com_id)
        {
            DB3Entities2 entity = new DB3Entities2();
            var c = entity.Companies.Where(x => x.Company_id == com_id).First();
            string name = c.C_Name;
            return name;
        }
        public int getcompany_id(string com_name)
        {
            DB3Entities2 entity = new DB3Entities2();
            var c = entity.Companies.Where(x => x.C_Name == com_name).First();
            int id = c.Company_id;
            return id;
        }
        public List<string> nameList()
        {
            DB3Entities2 entity = new DB3Entities2();
            List<Company> cl = entity.Companies.ToList();
            List<string> names = new List<string>();
            foreach(Company c in cl)
            {
                names.Add(c.C_Name);
            }
            return names;
        }
    }
}