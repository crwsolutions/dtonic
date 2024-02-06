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

        var aDictionaryWithObjects = new Dictionary<string, ChildDto>()
        {
            { "a", child1 },
            { "b", child2 },
            { "c", null }
        };

        var aDictionaryWithNumbers = new Dictionary<string, decimal?>()
        {
            { "a", 1 },
            { "b", null },
            { "c", 22.20m }
        };

        var aDictionaryWithBooleans = new Dictionary<string, bool?>()
        {
            { "a", true },
            { "b", null },
            { "c", false },
        };

        var aDictionaryWithStrings = new Dictionary<string, string?>()
        {
            { "a", "Hello" },
            { "b", null },
            { "c", "World" }
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
            anArrayOfObjects = (ChildDto[])[child1, null, child2],
            aDictionaryWithStrings = aDictionaryWithStrings,
            aDictionaryWithNumbers = aDictionaryWithNumbers,
            aDictionaryWithBooleans = aDictionaryWithBooleans,
            aDictionaryWithObjects = aDictionaryWithObjects,
        };
        return Content(person.Stringify(), MediaTypeNames.Application.Json);
    }
}
