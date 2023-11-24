using Application.Dtos;
using Application.Interfaces;
using HackTest.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Ancient.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class TestController : ControllerBase
{
    private readonly ITestService _service;

    public TestController(ITestService service)
    {
        _service = service;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<TestDto>> Get(int id)
    {
        return new JsonResult(await _service.GetByIdAsync(id));
    }

    [HttpGet]
    public async Task<ActionResult<ICollection<TestDto>>> Get()
    {
        return new JsonResult(await _service.GetAllAsync());
    }

    [HttpPost]
    public async Task<ActionResult<TestDto>> Add([FromBody] TestDto? dto)
    {
        if (dto == null)
            return BadRequest("Dto not found");

        return Ok(await _service.CreateAsync(dto));


    }

    [HttpPatch("{id}")]
    public async Task<ActionResult<TestDto>> Update(int id, [FromBody] TestDto? dto)
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