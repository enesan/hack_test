using Application.Dtos;
using Application.Interfaces;
using HackTest.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Ancient.Controllers;

[ApiController]
[Route("/api/[controller]")]

public class QuestionController : ControllerBase
{
    private readonly IQuestionService _service;

    public QuestionController(IQuestionService service)
    {
        _service = service;
    }
    
    [HttpGet("{id}")]
    
    public async Task<ActionResult<QuestionDto>> Get(int id)
    {
        return new JsonResult(await _service.GetByIdAsync(id));
    }
    
    [HttpGet]
    public async Task<ActionResult<ICollection<QuestionDto>>> GetAll()
    {
        return new JsonResult(await _service.GetAllAsync());
    }
    
    [HttpPost]
    public async Task<ActionResult<QuestionDto>> Add([FromBody] QuestionDto? dto)
    {
        if (dto == null)
            return BadRequest("Dto not found");

        return Ok(await _service.CreateAsync(dto));
    }

    [HttpPatch("{id}")]
    public async Task<ActionResult<QuestionDto>> Update(int id, [FromBody] QuestionDto? dto)
    {
        if (dto == null)
            return BadRequest("Dto not found");

        dto.Id = id;

        return Ok(await _service.UpdateAsync(dto));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.DeleteAsync(id);
        return Ok("Deleted Successfully");
    }
}