using Dtonic.Json;
using Dtonic.Json.Exceptions;

namespace Unspecified;

[TestClass]
public class JsonBooleanTests
{
    [TestMethod]
    public void Unspecified_should_have_no_value()
    {
        //Arrange
        var jsonBoolean = JsonBoolean.Unspecified;

        //Act

        //Assert
        Assert.IsFalse(jsonBoolean.IsSpecified);
    }

    [TestMethod]
    [ExpectedException(typeof(ValueIsNotSpecifiedException))]
    public void Checking_the_value_of_an_unspecified_should_throw_exception()
    {
        //Arrange
        var jsonBoolean = JsonBoolean.Unspecified;

        //Act
        var x = jsonBoolean.Value;

        //Assert
        Assert.Fail();
    }
}
