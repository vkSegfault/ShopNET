using Microsoft.AspNetCore.Mvc;
using ShopNET.Contracts.Item;
using ShopNET.Models;
using ShopNET.Services;
using ShopNET.Mappers;
using ShopNET.DTO;
using ShopNET.Interfaces;

namespace ShopNET.Controllers;

[ApiController]
[Route("api/v1/[controller]")]  // [controller] is replaced with below Class name but without "Controller" part, her it's just "Item"
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody] UserRequestDTO request)
    {
        var user = request.ToUser();

        await _userService.CreateUser(user);

        var res = user.ToUserResponseDTO();

        // it's recommended to return URI for GET of newly created object
        // Uri uri = new Uri($"http://localhost:5032/api/v1/Item/{res.Id}");

        // return Created(uri, res);
        // AtAction will return 201 and generate location link from method and route params
        return CreatedAtAction(actionName: nameof(GetUser), routeValues: new { id = res.Id }, value: res);
        // return Created();
    }

    // HttpGet and HttpRead are equivalents
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetUser([FromRoute] Guid id)
    {
        var user = await _userService.GetUserAsync(id);
        if (user != null)
        {
            var userDTO = user.ToUserResponseDTO();
            return Ok(userDTO);
        }
        else
        {
            return NotFound();
        }

    }

    [HttpGet]   // it's same as [HttpGet, Route("all")]
    public async Task<IActionResult> GetAllUsers()
    {
        var userList = await _userService.GetAllUsersAsync();
        var userDTOList = userList.Select(i => i.ToUserResponseDTO());

        // don't return List<> here (which is lazy-evaluated) cause we will get strange error about missing DbContext - misleading as fcuk
        // just return IEnumerable
        return Ok(userDTOList);
    }

    // QueryStrings
    [HttpPut]
    public async Task<IActionResult> UpdateUser([FromQuery] Guid id, [FromQuery] string? name, [FromQuery] string? surname, [FromQuery] decimal? price, [FromQuery] List<string>? tags)
    {
        if (await _userService.UserExistsAsync(id))
        {
            var user = await _userService.GetUserAsync(id);   // start tracking changes to existing object
            user.Name = name != null ? name : user.Name;
            user.Surname = surname != null ? surname : user.Surname;
            user.LastModifiedDateTime = DateTime.UtcNow;
            await _userService.UpdateUserAsync(user);   // save changes of tracked object
            return Ok(user.ToUserResponseDTO());
        }
        else
        {
            return NotFound($"There is no item: {id}");
        }
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpsertUser([FromRoute] Guid id, [FromBody] UserRequestDTO upsertRequest)
    {
        // if already exists just update it
        if (await _userService.UserExistsAsync(id))
        {
            var user = await _userService.GetUserAsync(id);   // start tracking changes to existing object
            user.Name = upsertRequest.Name;
            user.Surname = upsertRequest.Surname;
            user.LastModifiedDateTime = DateTime.UtcNow;
            await _userService.UpdateUserAsync(user);
            return Ok(user.ToUserResponseDTO());   // NoContent == 204 --> means updated successfully
        }
        // if not exists create new one
        else
        {
            var user = new User(Guid.NewGuid(), upsertRequest.Name, upsertRequest.Surname, null, DateTime.UtcNow, DateTime.UtcNow);
            await _userService.CreateUser(user);
            var res = user.ToUserResponseDTO();
            return CreatedAtAction(actionName: nameof(GetUser), routeValues: new { id = res.Id }, value: res);
        }

    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Deleteuser(Guid id)
    {
        if (await _userService.UserExistsAsync(id))
        {
            await _userService.DeleteUserAsync(id);
            return NoContent();
        }
        else
        {
            return NotFound($"The item: {id} can't be deleted beacuse it deoesn't exist");
        }
    }
}