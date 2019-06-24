using System.Collections.Generic;

namespace Jasarsoft.AmadeusDev.Web.Helper
{
    public class DataTable<T>
    {
        public int Draw { get; set; }
        public int RecordsTotal { get; set; }
        public int RecordsFiltered { get; set; }
        public IEnumerable<T> Data { get; set; }

        public string Error { get; set; }
    }
}
