using Microsoft.AspNetCore.Mvc;
using Src.Application.Service;
using Src.Domain.Dto;


[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly ProductService _service;

    public ProductController(ProductService service)
    {
        _service = service;
    }

    // [HttpGet]
    // public IActionResult GetAll() => Ok(_service.GetAll());

    // [HttpGet("{id}")]
    // public IActionResult GetById(int id)
    // {
    //     var producto = _service.GetById(id);
    //     if (producto == null) return NotFound();
    //     return Ok(producto);
    // }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ProductCreateDto data)
    {
        var response = await _service.Create(data);
        return Ok(response);
    }
}
