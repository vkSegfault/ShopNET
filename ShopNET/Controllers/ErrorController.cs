using Microsoft.AspNetCore.Mvc;

namespace ShopNET.Controllers;

public class ErrorController : ControllerBase
{
    // small quirk here - Swagger will throw if there is public method without any HTTP method marked, [Route()] defines only.. well,, route but not HTTP verb so we must mark it protected
    [Route("/error")]
    protected IActionResult Error()
    {
        return Problem();
    }
}