using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using DBMS;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Internal;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebInterface.Controllers
{
    [Route("api/databases/{dbId}/tables/{tblId}/[controller]")]
    [ApiController]
    public class RowsController : ControllerBase
    {
        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<TableRow> Get(int dbId, int tblId)
        {
            return GlobalContext.Databases[dbId].Tables[tblId].Rows;
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public TableRow GetAt(int dbId, int tblId, int rowId)
        {
            return GlobalContext.Databases[dbId].Tables[tblId].Rows[rowId];
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post(int dbId, int tblId, [FromBody] TableRow value)
        {
            var tbl = GlobalContext.Databases[dbId].Tables[tblId];
            var primaryKeyIndex = tbl.Cols.IndexOf(tbl.Cols.Where(x => x.IsPrimaryKey).FirstOrDefault());
            var a = tbl.Rows.IndexOf(tbl.Rows.Where(r => r.Values[primaryKeyIndex].ToString() == value.Values[primaryKeyIndex].ToString()).FirstOrDefault());
            if(a != -1)
            {
                GlobalContext.Databases[dbId].Tables[tblId].Rows[a] = value;
            }
            else
            {
                GlobalContext.Databases[dbId].Tables[tblId].Rows.Add(value);
            }
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int dbId, int tblId, object primaryKey)
        {
            SqlConnection c = new SqlConnection(Database.BuildConnectionString(GlobalContext.Databases[dbId].DbParams));
            GlobalContext.Databases[dbId].Tables[tblId].TryDropRow(primaryKey, c);
            //var tbl = GlobalContext.Databases[dbId].Tables[tblId];
            //var primaryKeyIndex = tbl.Cols.IndexOf(tbl.Cols.Where(x => x.Name == tbl.PrimaryKeyName).FirstOrDefault());
            //GlobalContext.Databases[dbId].Tables[tblId].Rows.RemoveAll(r=>r.Values[primaryKeyIndex] == rowId)
        }
    }
}
