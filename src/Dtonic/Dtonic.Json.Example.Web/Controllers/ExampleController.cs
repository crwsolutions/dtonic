using Dtonic.Dto.Example.Web.Dto;
using Dtonic.Dto.Extensions;
using Dtonic.Json.Utils;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Net.Mime;

namespace Dtonic.Dto.Example.Web.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ExampleController : ControllerBase
{
    [HttpGet(Name = "GetExample")]
    [ProducesResponseType<ExampleDto>(StatusCodes.Status200OK)]
    public IActionResult Get()
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

        var aDictionaryWithObjects = new Dictionary<string, ChildDto?>()
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

        var aDictionaryWithArrayOfBooleans = new Dictionary<string, IEnumerable<bool?>?>()
        {
            { "a", [true, null, false] },
            { "b", [false, false, false, false, false] },
            { "c", [true, true] },
            { "d", null },
        };
        var aDictionaryWithArrayOfNumbers = new Dictionary<string, IEnumerable<decimal?>?>()
        {
            { "a", [1, null, 2] },
            { "c", [1, 3.5m] },
            { "d", null },
        };
        var aDictionaryWithArrayOfStrings = new Dictionary<string, IEnumerable<string?>?>()
        {
            { "a", ["a", null, "b"] },
            { "d", null },
        };
        var aDictionaryWithArrayOfObjects = new Dictionary<string, IEnumerable<ChildDto?>?>()
        {
            { "a", [new ChildDto { aNumber = 12 }, null, new ChildDto { aString = "Hello" }] },
            { "d", null },
        };

        var example = new ExampleDto
        {
            aString = "Robert",
            aNumber = 11,
            aBoolean = true,
            anObject = child1,
            anArrayOfNumbers = (decimal[])[1, 2, 3, 4],
            anArrayOfStrings = (string[])["{a}", "\\b", "c[]\""],
            anArrayOfBooleans = (bool[])[true, false, true, false],
            anArrayOfObjects = (ChildDto?[])[child1, null, child2],
            aDictionaryWithStrings = aDictionaryWithStrings,
            aDictionaryWithNumbers = aDictionaryWithNumbers,
            aDictionaryWithBooleans = aDictionaryWithBooleans,
            aDictionaryWithObjects = aDictionaryWithObjects,
            aDictionaryWithArrayOfBooleans = aDictionaryWithArrayOfBooleans,
            aDictionaryWithArrayOfNumbers = aDictionaryWithArrayOfNumbers,
            aDictionaryWithArrayOfStrings = aDictionaryWithArrayOfStrings,
            aDictionaryWithArrayOfObjects = aDictionaryWithArrayOfObjects
        };
        return Ok(example);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult Post(ExampleDto? example)
    {
        return new OkResult();   
    }
}
