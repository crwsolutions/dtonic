using Dtonic.Json;
using Dtonic.Json.Exceptions;

namespace Unspecified;

[TestClass]
public class JsonStringTests
{
    [TestMethod]
    public void Unspecified_should_have_no_value()
    {
        //Arrange
        var jsonString = JsonString.Unspecified;

        //Act

        //Assert
        Assert.IsFalse(jsonString.IsSpecified);
    }

    [TestMethod]
    [ExpectedException(typeof(ValueIsNotSpecifiedException))]
    public void Checking_the_value_of_an_unspecified_should_throw_exception()
    {
        //Arrange
        var jsonString = JsonString.Unspecified;

        //Act
        var x = jsonString.Value;

        //Assert
        Assert.Fail();
    }
}
