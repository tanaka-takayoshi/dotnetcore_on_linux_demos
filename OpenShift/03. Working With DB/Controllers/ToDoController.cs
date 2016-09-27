using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HelloReact.Models;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace HelloReact.Controllers
{
    [Route("api/[controller]")]
    public class ToDoController : Controller
    {
        private readonly ToDoContext _context;

        public ToDoController(ToDoContext context)
        {
            this._context = context;
        }

        // GET: api/values
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(this._context.ToDo);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var toDo = this._context.ToDo.SingleOrDefault(item => item.Id == id);
            if (toDo == null)
            {
                return NotFound();
            }
            return Ok(toDo);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]ToDo toDo)
        {
            if (toDo == null)
            {
                return BadRequest();
            }
            this._context.ToDo.Add(toDo);
            this._context.SaveChanges();
            return Ok(toDo);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]ToDo toDo)
        {
            var existingItem = this._context.ToDo.SingleOrDefault(item => item.Id == id);
            if (existingItem == null)
            {
                return NotFound();
            }
            if (toDo.Description != null)
            {
                existingItem.Description = toDo.Description;
            }
            existingItem.Complete = toDo.Complete;
            this._context.ToDo.Update(existingItem);
            this._context.SaveChanges();
            return NoContent();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var toDo = this._context.ToDo.SingleOrDefault(item => item.Id == id);
            if (toDo == null)
            {
                return NotFound();
            }
            this._context.ToDo.Remove(toDo);
            this._context.SaveChanges();
            return NoContent();
        }
    }
}
