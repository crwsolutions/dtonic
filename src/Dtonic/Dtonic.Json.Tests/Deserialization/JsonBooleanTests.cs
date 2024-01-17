using Dtonic.Json.Extensions;
using TestClasses;

namespace Deserialization;

[TestClass]
public class JsonBooleanTests
{
    [TestMethod]
    public void Unspecified_value_should_give_isset_is_false()
    {
        //Arrange
        var json = "{}";

        //Act
        var testDto = json.Parse<TestDto>();

        //Assert
        Assert.IsFalse(testDto!.isTrue.IsSet);
        Assert.IsTrue(testDto.isTrue.IsNull);
    }

    [TestMethod]
    public void Null_value_should_give_null()
    {
        //Arrange
        var json = "{\"isTrue\":null}";

        //Act
        var testDto = json.Parse<TestDto>();

        //Assert
        Assert.IsTrue(testDto!.isTrue.IsSet);
        Assert.IsTrue(testDto.isTrue.IsNull);
    }

    [TestMethod]
    public void True_value_should_give_the_specified_true_value()
    {
        //Arrange
        var json = "{\"isTrue\":true}";

        //Act
        var testDto = json.Parse<TestDto>();

        //Assert
        Assert.IsTrue(testDto!.isTrue.IsSet);
        Assert.IsFalse(testDto.isTrue.IsNull);
        Assert.IsTrue(testDto.isTrue.Value);
    }

    [TestMethod]
    public void False_value_should_give_the_specified_false_value()
    {
        //Arrange
        var json = "{\"isTrue\":false}";

        //Act
        var testDto = json.Parse<TestDto>();

        //Assert
        Assert.IsTrue(testDto!.isTrue.IsSet);
        Assert.IsFalse(testDto.isTrue.IsNull);
        Assert.IsFalse(testDto.isTrue.Value);
    }
}