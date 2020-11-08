using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text.Json.Serialization;

namespace DBMS
{
    public class TableRow : IEquatable<TableRow>
    {
        public List<object> Values { get; set; }
        [JsonIgnore]
        public Table OwnerTable { get; set; }

        public TableRow() { }

        public TableRow(List<object> values, Table ownerTable)
        {
            this.Values = values;
            this.OwnerTable = ownerTable;
        }
        public TableRow(object[] values, Table ownerTable)
        {
            this.Values = values.ToList();
            this.OwnerTable = ownerTable;
        }

        public bool Equals(TableRow r)
        {
            if (r.Values.Count != Values.Count)
                return false;
            for (int i = 0; i < Values.Count; i++)
            {
                if (Values[i] != r.Values[i])
                    return false;
            }
            return true;
        }
    }
}
