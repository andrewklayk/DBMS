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
        public IEnumerable<SerVR<TableRow>> GetSerializedRows(int dbId, int tblId)
        {
            var path = Request.Scheme + "://" + Request.Host + Request.Path;
            Link selfLink = new Link("self", path, "get");
            Link deleteLink = new Link("delete", path, "delete");
            List<Link> links = new List<Link>
            {
                selfLink,
                deleteLink
            };
            return GlobalContext.Databases[dbId].Tables[tblId].Rows.Select(x => new SerVR<TableRow>(x, links.Select(y => new Link(y.Rel, y.Href + $"/{x.RowId}", y.Method)).ToList()));
        }
        // GET: api/<ValuesController>
        [HttpGet]
        public SerVR<IEnumerable<SerVR<TableRow>>> Get(int dbId, int tblId)
        {
            var path = Request.Scheme + "://" + Request.Host + Request.Path;
            Link selfLink = new Link("self", path, "get");
            Link postLink = new Link("add", path, "post");
            List<Link> links = new List<Link>
            {
                selfLink,
                postLink
            };
            return new SerVR<IEnumerable<SerVR<TableRow>>>(GetSerializedRows(dbId, tblId), links);
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public TableRow GetAt(int dbId, int tblId, int rowId)
        {
            var path = Request.Scheme + "://" + Request.Host + Request.Path;
            Link selfLink = new Link("self", path, "get");
            Link deleteLink = new Link("delete", path, "delete");
            List<Link> links = new List<Link>
            {
                selfLink,
                deleteLink
            };
            return new RowSerialize(GlobalContext.Databases[dbId].Tables[tblId].Rows[rowId], links);
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
