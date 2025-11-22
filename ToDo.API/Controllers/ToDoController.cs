using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDo.Core.DTOs;
using ToDo.Core.Interfaces;

namespace ToDo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        private readonly IToDoServices _toDoServices;

        public ToDoController(IToDoServices toDoServices)
        {
            _toDoServices = toDoServices;
        }
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ToDodto>>> GetAll()
        {
            var Task = await _toDoServices.GetAllAsync();
            if (Task.Count == 0) return NotFound();
            return Ok(Task);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ToDodto>> GetById(string id)
        {
            var Task =  await _toDoServices.GetByIdAsync(id);
            if (Task is null) return NotFound();
            return Ok(Task);
        }
        [HttpPost]
        public async Task<ActionResult<ToDodto>> Create([FromBody] CreateToDodto item)
        {
            var CreatedTask = await _toDoServices.CreateAsync(item);
            if (CreatedTask is null) return BadRequest();
            return Ok(CreatedTask);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ToDodto>> Update(string id,[FromBody]UpdateToDodto item)
        {
            var UpdatedTask = await _toDoServices.UpdateAsync(id,item);
            if (UpdatedTask is null) return BadRequest();
            return Ok(UpdatedTask);
        }
        [HttpPut("{id}/status")]
        public async Task<ActionResult<bool>> ChangeStatus(string id, bool IsCompleted)
        {
            var Result = await _toDoServices.ChangeStatusAsync(id, IsCompleted);
            if (!Result) return BadRequest();
            return Ok(Result);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(string id)
        {
            var Result = await _toDoServices.DeleteAsync(id);
            if (!Result) return BadRequest();
            return Ok(Result);
        }

    }
}
