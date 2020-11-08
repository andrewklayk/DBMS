using DBMS;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace DbmsUnitTests
{
    [TestClass]
    public class UnitTest1
    {
        Database db;
        Table t1;
        Table t2;
        TableColumn c1;
        TableColumn c2;
        TableColumn c4;
        TableRow r1t1;
        TableRow r1t2;
        TableRow r2t1;
        TableRow r2t2;
        [TestInitialize]
        public void TestInit()
        {
            GlobalContext.masterParams = new DBParams("localhost", "master", "", "", "", "", "admin", "04112000");
            GlobalContext.PopulateDatabaseList();
            db = new Database(new DBParams());
            t1 = new Table("a", db, new List<TableRow>(), new List<TableColumn>());
            t2 = new Table("a", db, new List<TableRow>(), new List<TableColumn>());
            c1 = new TableColumn(0, typeof(int), "int", "a");
            c2 = new TableColumn(0, typeof(int), "int", "b");
            c4 = new TableColumn(0, typeof(string), "nvarchar", "d");

            var values1 = new object[] { 0, 1, "a" };
            var values2 = new object[] { 0, 1, "b" };
            var values3 = new object[] { 0, 2, "c" };
            var values4 = values3;
            r1t1 = new TableRow(values1, t1);
            r1t2 = new TableRow(values2, t2);
            r2t1 = new TableRow(values3, t1);
            r2t2 = new TableRow(values4, t2);
            t1.Rows.Add(r1t1);
            t2.Rows.Add(r1t2);
            t1.Rows.Add(r2t1);
            t2.Rows.Add(r2t2);
            t1.Cols.AddRange(new[] { c1, c2, c4 });
            t2.Cols.AddRange(new[] { c1, c2, c4 });
        }

        [TestMethod]
        public void TestDifference()
        {
            Table dif = Table.Difference(t1, t2);
            Assert.AreEqual(2, dif.Rows.Count);
            Assert.AreEqual(dif.Rows[0], r1t1);
            Assert.AreEqual(dif.Rows[1], r1t2);
        }
        [TestMethod]
        public void TestAddDb()
        {
            Assert.AreNotEqual(GlobalContext.Databases.Count, 0);
        }
        [TestMethod]
        public void TestAddTable()
        {
            foreach (var db in GlobalContext.Databases)
            {
                db.PopulateTableList();
            }
            Assert.AreNotEqual(GlobalContext.Databases[0].Tables.Count, 0);
        }
    }
}
