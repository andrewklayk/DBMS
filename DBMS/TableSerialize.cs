using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS
{
    class TableSerialize : Table
    {
        public List<Link> Links { get; set; }
        public TableSerialize(Table t, List<Link> links) : base(t)
        {
            this.Links = links;
        }
        public static TableSerialize FromTable(Table t, List<Link> links)
        {
            return new TableSerialize(t, links);
        }
    }
}
