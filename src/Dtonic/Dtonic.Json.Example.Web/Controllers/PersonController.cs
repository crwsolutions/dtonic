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

        var addressList = new Dictionary<string, AddressDto>()
        {
            { "home", homeAddress },
            { "invoice", invoiceAddress }
        };

        var person = new PersonDto
        {
            name = "Robert",
            age = 11,
            isGoldMember = true,
            favoriteNumbers = (decimal[]) [ 1, 2, 3, 4 ],
            homeAddress = homeAddress,
            invoiceAddress = invoiceAddress,
            addressList = addressList
        };
        return Content(person.Stringify(), MediaTypeNames.Application.Json);
    }
}
