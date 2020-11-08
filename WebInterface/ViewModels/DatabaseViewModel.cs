using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DBMS;

namespace WebInterface.ViewModels
{
    public class DatabaseViewModel
    {
        private DBParams dbParams;
        public List<TableViewModel> Tables { get; set; }
        public DBParams DbParams { get => dbParams; set => dbParams = value; }

        public DatabaseViewModel(Database db)
        {
            DbParams = db.DbParams;
            Tables = db.Tables.Select(x => new TableViewModel(x)).ToList();
        }

        public Database GetDatabase()
        {
            Database db = new Database(DbParams);
            db.Tables = Tables.Select(x => x.GetTable(db)).ToList();
            return db;
        }
    }
}
