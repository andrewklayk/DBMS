using System;
using DBMS;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebInterface.ViewModels;
using Microsoft.EntityFrameworkCore.Internal;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebInterface.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DatabasesController : ControllerBase
    {
        //DbmsContext dbmsContext = new DbmsContext();
        // GET: api/<DatabasesController>
        [HttpGet]
        public IEnumerable<Database> Get()
        {
            return GlobalContext.Databases;
            //return new string[] { "value1", "value2" };
        }

        // GET api/<DatabasesController>/5
        [HttpGet("{id}")]
        public Database Get(int id)
        {
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
