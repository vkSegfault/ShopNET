using Microsoft.AspNetCore.Mvc;
using ShopNET.Contracts.Item;
using ShopNET.Models;
using ShopNET.Services;
using ShopNET.Mappers;
using ShopNET.DTO;

namespace ShopNET.Controllers;

[ApiController]
[Route("api/v1/[controller]")]  // [controller] is replaced with below Class name but without "Controller" part, her it's just Item
public class ItemController : ControllerBase
{
    private readonly IItemService _itemService;

    public ItemController(IItemService itemService)
    {
        _itemService = itemService;
    }

    [HttpPost]
    public IActionResult CreateItem([FromBody] ItemRequestDTO request)
    {
        var item = request.ToItem();

        _itemService.CreateItem(item);

        var res = item.ToItemResponseDTO();

        // it's recommended to return URI for GET of newly created object
        // Uri uri = new Uri($"http://localhost:5032/api/v1/Item/{res.Id}");

        // return Created(uri, res);
        // AtAction will return 201 and generate location link from method and route params
        return CreatedAtAction(actionName: nameof(GetItem), routeValues: new { id = res.Id }, value: res);
        // return Created();
    }

    // HttpGet and HttpRead are equivalents
    [HttpGet("{id:guid}")]
    public IActionResult GetItem([FromRoute] Guid id)
    {
        var item = _itemService.GetItem(id);
        if (item != null)
        {
            var itemDTO = item.ToItemResponseDTO();
            return Ok(itemDTO);
        }
        else
        {
            return NotFound();
        }

    }

    [HttpGet]   // it's same as [HttpGet, Route("all")]
    public IActionResult GetAllItems()
    {
        var itemList = _itemService.GetAllItems();
        var itemDTOList = itemList.Select(i => i.ToItemResponseDTO());

        // don't return List<> here (which is lazy-evaluated) cause we will get strange error about missing DbContext - misleading as fcuk
        // just return IEnumerable
        return Ok(itemDTOList);
    }

    [HttpPut("{id:guid}")]
    public IActionResult UpsertItem(Guid id, UpsertItemRequest request)
    {
        if (_itemService.ItemExists(id))
        {
            var item = new Item(id, request.Name, request.Description, request.Price, DateTime.UtcNow, DateTime.UtcNow, request.Tags);
            _itemService.UpdateItem(id, item);
            var res = new ItemResponse("object updated", id, item.Name, item.Description, item.CreatedDateTime, item.LastModifiedDateTime, item.Tags);
            return NoContent();
        }
        else
        {
            var item = new Item(Guid.NewGuid(), request.Name, request.Description, request.Price, DateTime.UtcNow, DateTime.UtcNow, request.Tags);
            _itemService.CreateItem(item);
            var res = new ItemResponse("object created", item.Id, item.Name, item.Description, item.CreatedDateTime, item.LastModifiedDateTime, item.Tags);
            return CreatedAtAction(actionName: nameof(GetItem), routeValues: new { id = res.Id }, value: res);
        }

    }

    [HttpDelete("{id:guid}")]
    public IActionResult DeleteItem(Guid id)
    {
        _itemService.DeleteItem(id);
        return Ok($"removed item: {id}");
    }
}