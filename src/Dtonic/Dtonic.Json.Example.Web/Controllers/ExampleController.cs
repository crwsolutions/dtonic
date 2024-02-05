using Dtonic.Dto.Example.Web.Dto;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace Dtonic.Dto.Example.Web.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ExampleController : ControllerBase
{
    [HttpGet(Name = "GetExample")]
    [ProducesResponseType<ExampleDto>(StatusCodes.Status200OK)]
    public ActionResult Get()
    {
        var child1 = new ChildDto
        {
            aNumber = 7,
            aString = "Rocketstreet"
        };

        var child2 = new ChildDto
        {
            aNumber = 8.10m,
            aString = "Invoicestreet"
        };

        var aDictionaryOfObjects = new Dictionary<string, ChildDto>()
        {
            { "home", child1 },
            { "invoice", child2 }
        };

        var person = new ExampleDto
        {
            aString = "Robert",
            aNumber = 11,
            aBoolean = true,
            aChild = child1,
            anArrayOfNumbers = (decimal[])[1, 2, 3, 4],
            anArrayOfStrings = (string[])["a", "b", "c"],
            anArrayOfBooleans = (bool[])[true, false, true, false],
            aDictionaryOfObjects = aDictionaryOfObjects
        };
        return Content(person.Stringify(), MediaTypeNames.Application.Json);
    }
}
