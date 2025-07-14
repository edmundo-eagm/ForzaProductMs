using Microsoft.AspNetCore.Mvc;
using Src.Application.Service;
using Src.Domain.Dto;

[ApiController]
[Route("api/[controller]")]
public class TodoController : ControllerBase
{
    private readonly TodoService _todoService;

    public TodoController(TodoService todoService)
    {
        _todoService = todoService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var todos = await _todoService.GetAll();
        return Ok(todos);
    }
}
