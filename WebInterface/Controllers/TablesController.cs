using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        [HttpGet]
        public IEnumerable<Table> Get(int dbId)
        {
            return GlobalContext.Databases[dbId].Tables;
        }

        // GET: api/
        [HttpGet("{tableId}")]
        public Table Get(int dbId, int tableId)
        {
            return GlobalContext.Databases[dbId].Tables[tableId];
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
