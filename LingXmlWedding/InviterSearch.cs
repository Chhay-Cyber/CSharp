using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqXmlWedding
{
    public class InviterSearch
    {
        public string ID { get; set; }
        public string MInviter { get; set; }
        public string FInviter { get; set; }
        public string UsaCurrency { get; set; }
        public string KhmerCurrency { get; set; }
        public string Date { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public InviterSearch() { }
        public InviterSearch(string id, string min, string fin, string us, string kh, string date, string typ, string des)
        {
            ID = id; MInviter = min; FInviter = fin; UsaCurrency = us; KhmerCurrency = kh; Date = date; Type = typ; Description = des;
        }
    }
}
