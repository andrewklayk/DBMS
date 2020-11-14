using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS
{
    public class SerVR<T>
    {
        public SerVR(T val, List<Link> links)
        {
            Value = val;
            Links = links;
        }

        public T Value { get; set; }
        public List<Link> Links { get; set; }
    }
}
