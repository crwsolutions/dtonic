using Dtonic.Json.Extensions;
using TestClasses;

namespace Deserialization;

[TestClass]
public class JsonStringTests
{
    [TestMethod]
    public void Unspecified_value_should_give_isset_is_false()
    {
        //Arrange
        var json = "{}";

        //Act
        var testDto = json.Parse<TestDto>();

        //Assert
        Assert.IsFalse(testDto!.street.IsSet);
        Assert.IsTrue(testDto.street.IsNull);
    }

    [TestMethod]
    public void Null_value_should_give_null()
    {
        //Arrange
        var json = "{\"street\":null}";

        //Act
        var testDto = json.Parse<TestDto>();

        //Assert
        Assert.IsTrue(testDto!.street.IsSet);
        Assert.IsTrue(testDto.street.IsNull);
    }

    [TestMethod]
    public void Specified_value_should_give_the_specified_value()
    {
        //Arrange
        var json = "{\"street\":\" wallstreet \"}";

        //Act
        var testDto = json.Parse<TestDto>();

        //Assert
        Assert.IsTrue(testDto!.street.IsSet);
        Assert.IsFalse(testDto.street.IsNull);
        Assert.AreEqual(" wallstreet ", testDto.street.Value);
    }

    [TestMethod]
    public void Empty_value_should_give_the_empty_value()
    {
        //Arrange
        var json = "{\"street\":\"\"}";

        //Act
        var testDto = json.Parse<TestDto>();

        //Assert
        Assert.IsTrue(testDto!.street.IsSet);
        Assert.IsFalse(testDto.street.IsNull);
        Assert.AreEqual(string.Empty, testDto.street.Value);
    }
}