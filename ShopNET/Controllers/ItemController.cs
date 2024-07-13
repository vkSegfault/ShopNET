using Microsoft.AspNetCore.Mvc;
using ShopNET.Contracts.Item;
using ShopNET.Models;
using ShopNET.Services;

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
    public IActionResult CreateItem(CreateItemRequest request)
    {
        // convert Request to Object
        // TODO - change Guid.NewGuid() to Guid.CreateVersion7() once .NET 9 is released
        var item = new Item(Guid.NewGuid(), request.Name, request.Description, DateTime.UtcNow, DateTime.UtcNow, request.Tags);

        // save Item to DB
        _itemService.CreateItem(item);

        // Convert Object to Response
        var res = new ItemResponse("object created", item.Id, item.Name, item.Description, item.CreatedDateTime, item.LastModifiedDateTime, item.Tags);

        // it's recommended to return URI for GET of newly created object
        // Uri uri = new Uri($"http://localhost:5032/api/v1/Item/{res.Id}");

        // return Created(uri, res);
        // AtAction will return 201 and generate location link from method and route params
        return CreatedAtAction(actionName: nameof(GetItem), routeValues: new { id = res.Id }, value: res);
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetItem(Guid id)
    {
        var item = _itemService.GetItem(id);
        var res = new ItemResponse("item found", item.Id, item.Name, item.Description, item.CreatedDateTime, item.LastModifiedDateTime, item.Tags);

        return Ok(res);
    }

    [HttpGet, Route("all")]   // it's same as HttpGet("all")
    public IActionResult GetAllItems()
    {
        var itemList = _itemService.GetAllItems();

        return Ok(itemList);
    }

    [HttpPut("{id:guid}")]
    public IActionResult UpsertItem(Guid id, UpsertItemRequest request)
    {
        if (_itemService.ItemExists(id))
        {
            var item = new Item(id, request.Name, request.Description, DateTime.UtcNow, DateTime.UtcNow, request.Tags);
            _itemService.UpdateItem(id, item);
            var res = new ItemResponse("object updated", id, item.Name, item.Description, item.CreatedDateTime, item.LastModifiedDateTime, item.Tags);
            return NoContent();
        }
        else
        {
            var item = new Item(Guid.NewGuid(), request.Name, request.Description, DateTime.UtcNow, DateTime.UtcNow, request.Tags);
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