using Dtonic.Json;
using Dtonic.Json.Exceptions;

namespace Unspecified;

[TestClass]
public class JsonArrayOfNumbersTests
{
    [TestMethod]
    public void Unspecified_should_have_no_value()
    {
        //Arrange
        var jsonArray = JsonArrayOfNumbers.Unspecified;

        //Act

        //Assert
        Assert.IsFalse(jsonArray.IsSpecified);
    }

    [TestMethod]
    [ExpectedException(typeof(ValueIsNotSpecifiedException))]
    public void Checking_the_value_of_an_unspecified_should_throw_exception()
    {
        //Arrange
        var jsonArray = JsonArrayOfNumbers.Unspecified;

        //Act
        var x = jsonArray.Value;

        //Assert
        Assert.Fail();
    }
}
