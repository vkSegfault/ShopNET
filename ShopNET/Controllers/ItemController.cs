using Microsoft.AspNetCore.Mvc;
using ShopNET.Contracts.Item;
using ShopNET.Models;

namespace ShopNET.Controllers;

[ApiController]
[Route("api/v1/[controller]")]  // [controller] is replaced with below Class name but without "Controller" part, her it's just Item
public class ItemController : ControllerBase
{
    [HttpPost]
    public IActionResult CreateItem(CreateItemRequest request)
    {
        // TODO - move functionallity to service

        // convert Request to Object
        var item = new Item(Guid.NewGuid(), request.Name, request.Description, DateTime.UtcNow, DateTime.UtcNow, request.Tags);

        // Convert Object to Response
        var res = new ItemResponse(item.Id, item.Name, item.Description, item.CreatedDateTime, item.LastModifiedDateTime, item.Tags);

        return Created(nameof(GetItem), res);
    }

    [HttpGet("item/{id:guid}")]   // :guid defines type for id
    public IActionResult GetItem(Guid id)
    {
        return Ok(id);
    }

    [HttpGet, Route("item")]   // :guid defines type for id
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