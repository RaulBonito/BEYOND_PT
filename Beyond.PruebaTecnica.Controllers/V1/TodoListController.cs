using Microsoft.AspNetCore.Mvc;
using Beyond.PruebaTecnica.Abstractions.Services;
using Beyond.PruebaTecnica.Abstractions.Repositories;
using Beyond.PruebaTecnica.Dtos.V1;

namespace Beyond.PruebaTecnica.Controllers.V1
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoListController : ControllerBase
    {
        private readonly ITodoList _service;
        private readonly ITodoListRepository _repository;

        public TodoListController(ITodoList service, ITodoListRepository repository)
        {
            _repository = repository;
            _service = service;
        }

        [HttpPost("add")]
        public IActionResult Add([FromBody] AddTodoItemDto dto)
        {
            try
            {
                // NOTA: Una vez mas, como en la ConsoleApp, nos vemos obligados a obtener el Next Id a través del repository.
                var id = _repository.GetNextId();

                _service.AddItem(id, dto.Title, dto.Description, dto.Category);
                return Ok(new { Message = "Item added", Id = id });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("update/{id}")]
        public IActionResult Update(int id, [FromBody] UpdateTodoItemDto dto)
        {
            try
            {
                _service.UpdateItem(id, dto.Description);
                return Ok("Description updated.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Remove(int id)
        {
            try
            {
                _service.RemoveItem(id);
                return Ok("Item removed.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("register")]
        public IActionResult RegisterProgression([FromBody] RegisterProgressionDto dto)
        {
            try
            {
                _service.RegisterProgression(dto.Id, dto.DateTime, dto.Percent);
                return Ok("Progress registered.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("list")]
        public IActionResult List()
        {
            try
            {
                var items = _repository.GetAllItems();
                return Ok(items);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }

}
