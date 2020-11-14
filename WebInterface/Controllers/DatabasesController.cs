using System;
using DBMS;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebInterface.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DatabasesController : ControllerBase
    {
        public int GetDbIndex(Database db)
        {
            return GlobalContext.Databases.IndexOf(db);
        }

        public IEnumerable<SerVR<DbVM>> GetSerializedDbs()
        {
            var path = Request.Scheme + "://" + Request.Host + Request.Path;
            Link selfLink = new Link("self", path, "get");
            Link postLink = new Link("add", path, "post");
            Link deleteLink = new Link("delete", path, "post");
            List<Link> links = new List<Link>
            {
                selfLink,
                postLink
            };
            var viewModels = GlobalContext.Databases.Select(x => new DbVM(x));
            var enumerable = (viewModels.Select(
                            x => new SerVR<DbVM>(x, new List<Link> { new Link("self", selfLink.Href + $"/{x.dbIndex}", "get"), new Link("tables", selfLink.Href + $"/{x.dbIndex}" + "/tables", "get"), new Link("delete", selfLink.Href + $"/{x.dbIndex}", "delete") })));
            return enumerable;
        }
        //DbmsContext dbmsContext = new DbmsContext();
        // GET: api/<DatabasesController>
        [HttpGet]
        public SerVR<IEnumerable<SerVR<DbVM>>> Get()
        {
            var path = Request.Scheme + "://" + Request.Host + Request.Path;
            GetSerializedDbs();
            Link selfLink = new Link("self", path, "get");
            Link postLink = new Link("add", path, "post");
            Link deleteLink = new Link("add", path, "post");
            List<Link> links = new List<Link>
            {
                selfLink,
                postLink
            };
            return new SerVR<IEnumerable<SerVR<DbVM>>>(GetSerializedDbs(), links);
            //return new SerVR<IEnumerable<SerVR<DbVM>>>
            //   (GlobalContext.Databases.Select(x => new SerVR<DbVM>(new DbVM(x.DbParams, x.Tables.Select(y=>y.TableName)), new List<Link> {new Link("self", selfLink.Href + $"/{GetDbIndex(x)}", "get"),new Link("tables", selfLink.Href + $"/{GetDbIndex(x)}" + "/tables", "get"),new Link("delete", selfLink.Href + $"/{GetDbIndex(x)}", "delete")})), links);
            //return new SerializationWrapper<IEnumerable<SerializationWrapper<Database>>>(GlobalContext.Databases.Select(x=>new SerializationWrapper<Database>));
            //return new string[] { "value1", "value2" };
        }

        // GET api/<DatabasesController>/5
        [HttpGet("{id}")]
        public Database Get(int id)
        {
            var path = Request.Scheme + "://" + Request.Host + Request.Path;
            Link selfLink = new Link("self", path, "get");
            Link postLink = new Link("add", path, "post");
            Link deleteLink = new Link("add", path, "post");
            List<Link> links = new List<Link>
            {
                selfLink,
                postLink
            };
            return GlobalContext.Databases.ElementAt(id);
        }

        /*[HttpGet("{dbId}/tables")]
        public IEnumerable<Table> GetTables(int dbId)
        {
            return GlobalContext.Databases[dbId].Tables;
        }

        [HttpGet("{dbId}/tables/{tableId}")]
        public Table GetTableAt(int dbId, int tableId)
        {
            return GlobalContext.Databases[dbId].Tables[tableId];
        }*/

        // POST api/<DatabasesController>
        [HttpPost]
        public IActionResult Post([FromBody] Database value)
        {
            try
            {
                GlobalContext.CreateDatabase(value);
                return CreatedAtAction(nameof(value), value);
            }
            catch(Exception e)
            {
                return BadRequest();
            }
        }

        /*[HttpPost("{dbId}/tables")]
        public IActionResult PostTable(int dbId, [FromBody] Table value)
        {
            try
            {
                value.Database = GlobalContext.Databases[dbId];
                GlobalContext.Databases[dbId].AddTable(value);
                return CreatedAtAction(nameof(value), value);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }*/

        // PUT api/<DatabasesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<DatabasesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            try
            {
                GlobalContext.DropDatabase(id);
            }
            catch (Exception e)
            {
            }
        }

        //[HttpDelete("{dbId}/tables/{tableName}")]
        //public void DeleteTable(int dbId, string tableName)
        //{
        //    try
        //    {
        //        var db = GlobalContext.Databases[dbId];
        //        db.DropTable(tableName);
        //    }
        //    catch (Exception e)
        //    {
        //    }
        //}
    }
}
