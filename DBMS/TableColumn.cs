using System;
using System.Text.Json.Serialization;

namespace DBMS
{
    public class TableColumn
    {
        public int index;
        private string sqlType;
        private bool isPrimaryKey;

        public TableColumn(int index, Type type, string sqlType, string name, bool isPrimaryKey)
        {
            this.index = index;
            this.DataType = type;
            this.SqlType = sqlType;
            this.Name = name;
            this.isPrimaryKey = isPrimaryKey;
        }

        public TableColumn() { }

        public string Name { get; set; }
        [JsonIgnore]
        public Type DataType { get; set; }
        public string SqlType { get => sqlType; set => sqlType = value; }
        public bool IsPrimaryKey { get => isPrimaryKey; set => isPrimaryKey = value; }
    }
}
