using Contracts;
using Microsoft.AspNetCore.Mvc;
using Service.Abstractions;

namespace Presentation.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IServiceManager _serviceManager;

    public UserController(IServiceManager serviceManager) => _serviceManager = serviceManager;

    [HttpGet("{userId:guid}")]
    public async Task<IActionResult> Get(Guid userId)
    {
        var userDto = await _serviceManager.UserService.GetByIdAsync(userId);
        return Ok(userDto);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var usersDto = await _serviceManager.UserService.GetAllAsync();
        return Ok(usersDto);
    }
    
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] UserForCreationDto userForCreationDto)
    {
        var userDto = await _serviceManager.UserService.CreateAsync(userForCreationDto);
        return CreatedAtAction(nameof(Get), new { userId = userDto.Id }, userDto);
    }
    
    [HttpPut("{userId:guid}")]
    public async Task<IActionResult> Update(Guid userId, [FromBody] UserForUpdateDto userForUpdateDto)
    {
        await _serviceManager.UserService.UpdateAsync(userId, userForUpdateDto);
        return NoContent();
    }
    
    [HttpDelete("{userId:guid}")]
    public async Task<IActionResult> Delete(Guid userId)
    {
        await _serviceManager.UserService.DeleteAsync(userId);
        return NoContent();
    }
}