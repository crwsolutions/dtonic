using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System.Net;

namespace Dtonic.Json.Example.Web.Controllers;
[Route("api/[controller]")]
[ApiController]
public class PersonController : ControllerBase
{
    //[HttpGet(Name = "GetPerson")]
    //public PersonDto Get()
    //{
    //    var person = new PersonDto();
    //    person.age = new JsonNumber(11);
    //    return person;
    //}

    [HttpGet(Name = "GetPerson2")]
    public ActionResult Get()
    {
        var homeAddress = new AddressDto
        {
            city = new JsonString("Amsterdam"),
            street = new JsonString("Rocketstreet")
        };

        var invoiceAddress = new AddressDto
        {
            city = new JsonString("Rotterdam"),
            street = new JsonString("Invoicestreet")
        };

        var person = new PersonDto
        {
            name = new JsonString("Robert"),
            age = new JsonNumber(11),
            isGoldMember = new JsonBoolean(true),
            favoriteNumbers = new JsonArray<int>([1, 2, 3]),
            homeAddress = new JsonObject<AddressDto>(homeAddress),
            invoiceAddress = new JsonObject<AddressDto>(invoiceAddress),
        };
        return Content(person.ToJsonString());
    }
}
