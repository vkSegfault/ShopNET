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
        var item = new Item(Guid.NewGuid(), request.Name, request.Description, DateTime.UtcNow, DateTime.UtcNow, request.Tags);

        // save Item to DB
        _itemService.CreasteItem(item);

        // Convert Object to Response
        var res = new ItemResponse(item.Id, item.Name, item.Description, item.CreatedDateTime, item.LastModifiedDateTime, item.Tags);

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
        var res = new ItemResponse(item.Id, item.Name, item.Description, item.CreatedDateTime, item.LastModifiedDateTime, item.Tags);

        return Ok(res);
    }

    [HttpGet, Route("all")]   // it's same as HttpGet("all")
    public IActionResult GetAllItems()
    {
        return Ok();
    }

    [HttpPut("item/{id:guid}")]   // :guid defines type for id
    public IActionResult UpsertItem(Guid id, UpsertItemRequest request)
    {
        return Ok(request);
    }

    [HttpDelete("item/{id:guid}")]   // :guid defines type for id
    public IActionResult DeleteItem(Guid id)
    {
        return Ok(id);
    }
}