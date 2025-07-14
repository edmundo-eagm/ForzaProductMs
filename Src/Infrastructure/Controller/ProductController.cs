// using MediatR;
// using Microsoft.AspNetCore.Mvc;

// [ApiController]
// [Route("api/[controller]")]
// public class ItemsController : ControllerBase
// {
//     private readonly IMediator _mediator;

//     public ItemsController(IMediator mediator)
//     {
//         _mediator = mediator;
//     }

//     [HttpPost]
//     public async Task<IActionResult> Create([FromBody] CreateItemCommand command)
//     {
//         var id = await _mediator.Send(command);
//         return CreatedAtAction(nameof(GetById), new { id }, null);
//     }

//     [HttpGet("{id}")]
//     public async Task<IActionResult> GetById(int id)
//     {
//         var item = await _mediator.Send(new GetItemByIdQuery(id));
//         if (item == null) return NotFound();
//         return Ok(item);
//     }
// }
