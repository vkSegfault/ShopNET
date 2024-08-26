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

    // [HttpGet]   // it's same as [HttpGet, Route("all")]
    // public async Task<IActionResult> GetAllItems()
    // {
    //     var itemList = await _itemService.GetAllItemsAsync();
    //     var itemDTOList = itemList.Select(i => i.ToItemResponseDTO());

    //     // don't return List<> here (which is lazy-evaluated) cause we will get strange error about missing DbContext - misleading as fcuk
    //     // just return IEnumerable
    //     return Ok(itemDTOList);
    // }

    // [HttpPut]
    // public async Task<IActionResult> UpdateItem([FromQuery] Guid id, [FromQuery] string? name, [FromQuery] string? description, [FromQuery] decimal? price, [FromQuery] List<string>? tags)
    // {
    //     if (await _itemService.ItemExistsAsync(id))
    //     {
    //         var item = await _itemService.GetItemAsync(id);   // start tracking changes to existing object
    //         item.Name = name != null ? name : item.Name;
    //         item.Description = description != null ? description : item.Description;
    //         item.Price = (decimal)(price != null ? price : item.Price);
    //         item.Tags = tags != null ? tags : item.Tags;
    //         await _itemService.UpdateItemAsync(item);   // save changes of tracked object
    //         return Ok(item.ToItemResponseDTO());
    //     }
    //     else
    //     {
    //         return NotFound($"There is no item: {id}");
    //     }
    // }

    // // use query strings instead of location params
    // [HttpPut("{id:guid}")]
    // public async Task<IActionResult> UpsertItem([FromRoute] Guid id, [FromBody] ItemRequestDTO upsertRequest)
    // {
    //     // if already exists just update it
    //     if (await _itemService.ItemExistsAsync(id))
    //     {
    //         var item = await _itemService.GetItemAsync(id);   // start tracking changes to existing object
    //         item.Name = upsertRequest.Name;
    //         item.Description = upsertRequest.Description;
    //         item.Price = upsertRequest.Price;
    //         item.Tags = upsertRequest.Tags;
    //         await _itemService.UpdateItemAsync(item);
    //         return Ok(item.ToItemResponseDTO());   // NoContent == 204 --> means updated successfully
    //     }
    //     // if not exists create new one
    //     else
    //     {
    //         var item = new Item(Guid.NewGuid(), upsertRequest.Name, upsertRequest.Description, upsertRequest.Price, DateTime.UtcNow, DateTime.UtcNow, upsertRequest.Tags);
    //         await _itemService.CreateItem(item);
    //         var res = new ItemResponse("object created", item.Id, item.Name, item.Description, item.CreatedDateTime, item.LastModifiedDateTime, item.Tags);
    //         return CreatedAtAction(actionName: nameof(GetItem), routeValues: new { id = res.Id }, value: res);
    //     }

    // }

    // [HttpDelete("{id:guid}")]
    // public async Task<IActionResult> DeleteItem(Guid id)
    // {
    //     if (await _itemService.ItemExistsAsync(id))
    //     {
    //         await _itemService.DeleteItemAsync(id);
    //         return NoContent();
    //     }
    //     else
    //     {
    //         return NotFound($"The item: {id} can't be deleted beacuse it deoesn't exist");
    //     }
    // }
}