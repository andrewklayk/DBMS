using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS
{
    public abstract class Column
    {
        public string name;
        public int index;
        public string type;

        protected Column(string name, int index, string type)
        {
            this.name = name;
            this.index = index;
            this.type = type;
        }
    }
    public class Column<T> : Column
    {
        public List<T> values;

        public Column(string name, int index, string type) : base(name, index, type)
        {
            values = new List<T>();
        }
    }
}
