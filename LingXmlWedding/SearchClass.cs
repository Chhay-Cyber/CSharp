using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqXmlWedding
{
    public class SearchClass
    {
        public string ID { get; set; }
        public string Hname { get; set; }
        public string Wname { get; set; }
        public string Address { get; set; }
        public string KhmerCurrency { get; set; }
        public string USACurrency { get; set; }
        public string Description { get; set; }

        public SearchClass() { }
        public SearchClass(string ID, string Hname, string Wname, string Address, string KhmerCurrency, string USACurrency, string Description)
        {
            this.ID = ID;
            this.Hname = Hname;
            this.Wname = Wname;
            this.Address = Address;
            this.KhmerCurrency = KhmerCurrency;
            this.USACurrency = USACurrency;
            this.Description = Description;
        }
    }
}
