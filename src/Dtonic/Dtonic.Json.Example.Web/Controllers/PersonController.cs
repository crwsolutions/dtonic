using Dtonic.Json.Example.Web.Dto;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using Dtonic.Json.Extensions;

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
    [ProducesResponseType<PersonDto>(StatusCodes.Status200OK)]
    public ActionResult Get()
    {
        var homeAddress = new AddressDto
        {
            city = "Amsterdam",
            street = "Rocketstreet"
        };

        var invoiceAddress = new AddressDto
        {
            city = "Rotterdam",
            street = "Invoicestreet"
        };

        var person = new PersonDto
        {
            name = "Robert",
            age = 11,
            isGoldMember = true,
            favoriteNumbers = new JsonArray<int>([1,2,3]),
            homeAddress = homeAddress,
            invoiceAddress = invoiceAddress,
        };
        return Content(person.ToJsonString(), MediaTypeNames.Application.Json);
    }
}
