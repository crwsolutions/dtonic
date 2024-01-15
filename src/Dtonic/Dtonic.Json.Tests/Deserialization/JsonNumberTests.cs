using Dtonic.Json.Extensions;
using TestClasses;

namespace Deserialization;

[TestClass]
public class JsonNumberTests
{
    [TestMethod]
    public void Unspecified_value_should_give_isset_is_false()
    {
        //Arrange
        var json = "{}";

        //Act
        var testDto = json.Parse<TestDto>();

        //Assert
        Assert.IsFalse(testDto.number.IsSet);
        Assert.IsTrue(testDto.number.IsNull);
    }

    [TestMethod]
    public void Null_value_should_give_null()
    {
        //Arrange
        var json = "{\"number\":null}";

        //Act
        var testDto = json.Parse<TestDto>();

        //Assert
        Assert.IsTrue(testDto.number.IsSet);
        Assert.IsTrue(testDto.number.IsNull);
    }

    [TestMethod]
    public void Specified_value_should_give_the_specified_value()
    {
        //Arrange
        var json = "{\"number\":1.1}";

        //Act
        var testDto = json.Parse<TestDto>();

        //Assert
        Assert.IsTrue(testDto.number.IsSet);
        Assert.IsFalse(testDto.number.IsNull);
        Assert.AreEqual(1.1m, testDto.number.Value);
    }
}