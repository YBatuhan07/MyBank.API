using Microsoft.AspNetCore.Mvc;
using MyBank.Services;
using System.Net;

namespace MyBank.App.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomBaseController : ControllerBase
{
    [NonAction]
    public IActionResult CreateActionResult<T>(ServiceResult<T> serviceResult)
    {
        if (serviceResult.HttpStatusCode == HttpStatusCode.NoContent)
            return NoContent();
        
        if(serviceResult.HttpStatusCode == HttpStatusCode.Created)
            return Created(serviceResult.UrlAsCreated, serviceResult);

        return new ObjectResult(serviceResult) { StatusCode = serviceResult.HttpStatusCode.GetHashCode() };
    }

    [NonAction]
    public IActionResult CreateActionResult(ServiceResult serviceResult)
    {
        if (serviceResult.HttpStatusCode == HttpStatusCode.NoContent)
            return new ObjectResult(null) { StatusCode = serviceResult.HttpStatusCode.GetHashCode() };

        return new ObjectResult(serviceResult) { StatusCode = (int)serviceResult.HttpStatusCode };
    }
}