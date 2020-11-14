using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS
{
    public class DbVM
    {
        public int dbIndex;
        private string name;
        //public DBParams DBParams { get => DBParams; set => DBParams = value; }
        public IEnumerable<string> TableNames { get; set; }
        public string Name { get => name; set => name = value; }

        public DbVM(int i, DBParams p, IEnumerable<string> t)
        {
            dbIndex = i;
            Name = p.DBName;
            //DBParams = p;
            TableNames = t;
        }
        public DbVM(Database d)
        {
            Name = d.DbParams.DBName ;
            TableNames = d.Tables.Select(x => x.TableName);
            dbIndex = GlobalContext.Databases.IndexOf(d);
        }
    }
}
