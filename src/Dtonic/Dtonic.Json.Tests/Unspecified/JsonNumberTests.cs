using Dtonic.Json;
using Dtonic.Json.Exceptions;

namespace Unspecified;

[TestClass]
public class JsonNumberTests
{
    [TestMethod]
    public void Unspecified_should_have_no_value()
    {
        //Arrange
        var jsonNumber = JsonNumber.Unspecified;

        //Act

        //Assert
        Assert.IsFalse(jsonNumber.IsSpecified);
    }

    [TestMethod]
    [ExpectedException(typeof(ValueIsNotSpecifiedException))]
    public void Checking_the_value_of_an_unspecified_should_throw_exception()
    {
        //Arrange
        var jsonNumber = JsonNumber.Unspecified;

        //Act
        var x = jsonNumber.Value;

        //Assert
        Assert.Fail();
    }
}
