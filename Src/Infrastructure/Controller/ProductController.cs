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

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ProductCreateDto data)
    {
        var response = await _service.Create(data);
        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var product = await _service.GetOne(id);
        if (product == null) return NotFound();

        return Ok(product);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var products = await _service.GetAll();
        return Ok(products);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var delete = await _service.Delete(id);
        if (!delete) return NotFound();
        return Ok(delete);
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] ProductUpdateDto data)
    {
        var response = await _service.Update(id, data);
        return Ok(response);
    }
}
