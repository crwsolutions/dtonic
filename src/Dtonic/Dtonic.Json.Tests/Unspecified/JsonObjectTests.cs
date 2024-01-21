using Dtonic.Json;
using Dtonic.Json.Exceptions;
using TestClasses;

namespace Unspecified;

[TestClass]
public class JsonObjectTests
{
    [TestMethod]
    public void Unspecified_should_have_no_value()
    {
        //Arrange
        var jsonObject = JsonObject<TestDto>.Unspecified;

        //Act

        //Assert
        Assert.IsFalse(jsonObject.IsSpecified);
    }

    [TestMethod]
    [ExpectedException(typeof(ValueIsNotSpecifiedException))]
    public void Checking_the_value_of_an_unspecified_should_throw_exception()
    {
        //Arrange
        var jsonObject = JsonObject<TestDto>.Unspecified;

        //Act
        var x = jsonObject.Value;

        //Assert
        Assert.Fail();
    }
}
