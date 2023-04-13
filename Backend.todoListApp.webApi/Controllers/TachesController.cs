using Backend.todoListApp.DataAccess.Model;
using Backend.todoListApp.Logic.Models;
using Backend.todoListApp.Logic.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Backend.todoListApp.webApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TachesController : ControllerBase
    {

        private readonly ITachesService _itachesService;

        public TachesController(ITachesService itachesService)
        {
            _itachesService = itachesService;
        }


        // GET: api/<TachesController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Taches>>> GetTasks(int pageNumber = 1, int pageSize = 10)
        {
            var tasks = await _itachesService.GetAllTasks();
            var pagedTasks = tasks.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
            return Ok(pagedTasks);
        }


        // GET api/<TachesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Taches>> GetTask(int id)
        {
            var task = await _itachesService.GetTaskByIdAsync(id);

            if (task == null)
            {
                return NotFound();
            }

            return Ok(task);
        }

        // POST api/<TachesController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TachesImg Xtaches)
        {
            var TaskAdd = await _itachesService.CreateTaskAsync(Xtaches);

            return Ok(TaskAdd);

        }



        // PUT api/<TachesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] TachesImg Xtaches)
        {
            var TaskUpdated = await _itachesService.UpdateTaskAsync(id, Xtaches);

            return Ok(TaskUpdated);
        }

    // DELETE api/<TachesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)

        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid id.");
            }
            else
            {
                var del = await _itachesService.DeleteTaskAsync(id);
                return Ok(del);

            }

        }
    }
}
