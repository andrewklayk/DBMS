using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS
{
    public class RowSerialize : TableRow
    {
        public List<Link> Links { get; set; }
        public RowSerialize(TableRow r, List<Link> links) : base(r)
        {
            this.Links = links;
        }
        public static RowSerialize FromRow(TableRow r, List<Link> links)
        {
            return new RowSerialize(r, links);
        }
    }
}
