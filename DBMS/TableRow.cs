﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text.Json.Serialization;

namespace DBMS
{
    public class TableRow : IEquatable<TableRow>
    {
        public int RowId { get; set; }
        public List<object> Values { get; set; }
        [JsonIgnore]
        public Table OwnerTable { get; set; }

        public TableRow() { }
        public TableRow(TableRow r)
        {
            RowId = r.RowId;
            Values = r.Values;
            OwnerTable = r.OwnerTable;
        }

        public TableRow(List<object> values, Table ownerTable)
        {
            this.Values = values;
            this.OwnerTable = ownerTable;
            //this.Links.Add(new Dictionary<string, string> { { "rel", "self" }, {"link",$"http://localhost:5000/{OwnerTable.TableName/}" } })
        }
        public TableRow(List<object> values, Table ownerTable, int rowId)
        {
            this.RowId = rowId;
            this.Values = values;
            this.OwnerTable = ownerTable;
            //this.Links.Add(new Dictionary<string, string> { { "rel", "self" }, {"link",$"http://localhost:5000/{OwnerTable.TableName/}" } })
        }
        public TableRow(object[] values, Table ownerTable)
        {
            this.Values = values.ToList();
            this.OwnerTable = ownerTable;
        }
        public TableRow(object[] values, Table ownerTable, int id)
        {
            RowId = id;
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
