using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;
using DBMS;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebInterface.Controllers
{
    [Route("api/databases/{dbId}/[controller]")]
    [ApiController]
    public class TablesController : ControllerBase
    {
        public IEnumerable<SerVR<TableViewModel>> GetSerializedTables(int dbId)
        {
            var path = Request.Scheme + "://" + Request.Host + Request.Path;
            Link selfLink = new Link("self", path, "get");
            Link postLink = new Link("add", path, "post");
            Link deleteLink = new Link("delete", path, "delete");
            List<Link> links = new List<Link>
            {
                selfLink,
                deleteLink
            };
            var viewModels = GlobalContext.Databases[dbId].Tables.Select(x => new TableViewModel(x));
            return viewModels.Select(x => new SerVR<TableViewModel>
                                                                (x, new List<Link> { new Link("self", selfLink.Href + $"/{x.index}", "get"),
                                                                                     new Link("rows", selfLink.Href + $"/{x.index}" + "/rows", "get"),
                                                                                     new Link("delete", selfLink.Href + $"/{x.index}", "post")}
                                                                .ToList()));
        }
        [HttpGet]
        public SerVR<IEnumerable<SerVR<TableViewModel>>> Get(int dbId)
        {
            var path = Request.Scheme + "://" + Request.Host + Request.Path;
            Link selfLink = new Link("self", path, "get");
            Link postLink = new Link("add", path, "post");
            Link deleteLink = new Link("delete", path, "delete");
            List<Link> links = new List<Link>
            {
                selfLink,
                deleteLink
            };
            return new SerVR<IEnumerable<SerVR<TableViewModel>>>
                (GetSerializedTables(dbId), new List<Link>{ selfLink, postLink });
        }

        // GET: api/
        [HttpGet("{tableId}")]
        public SerVR<Table> Get(int dbId, int tableId)
        {
            var path = Request.Scheme + "://" + Request.Host + Request.Path;
            Link selfLink = new Link("self", path, "get");
            Link postLink = new Link("add", path, "post");
            Link deleteLink = new Link("delete", path, "delete");
            List<Link> links = new List<Link>
            {
                selfLink,
                postLink,
                deleteLink
            };
            return new SerVR<Table>(GlobalContext.Databases[dbId].Tables[tableId],links);
        }



        // GET api/<ValuesController>/5
        /*[HttpGet("{dbId}/{tableId}")]
        public Table Get(int dbId, int tableId)
        {
            return GlobalContext.Databases[dbId].Tables[tableId];
        }*/

        [HttpPost]
        public void Post(int dbId, [FromBody] Table value)
        {
            value.Database = GlobalContext.Databases[dbId];
            GlobalContext.Databases[dbId].AddTable(value);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{tableName}")]
        public void DeleteTable(int dbId, string tableName)
        {
            try
            {
                var db = GlobalContext.Databases[dbId];
                db.DropTable(tableName);
            }
            catch (Exception e)
            {
            }
        }
    }
}
