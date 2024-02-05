using Dtonic.Dto.Extensions;
using TestClasses;

namespace Deserialization;

[TestClass]
public class DtoBooleanTests
{
    [TestMethod]
    public void Unspecified_value_should_give_isset_is_false()
    {
        //Arrange
        var dto = "{}";

        //Act
        var testDto = dto.Parse<TestDto>();

        //Assert
        Assert.IsFalse(testDto!.aBoolean.IsSpecified);
        Assert.IsTrue(testDto.aBoolean.IsNull);
    }

    [TestMethod]
    public void Null_value_should_give_null()
    {
        //Arrange
        var dto = "{\"aBoolean\":null}";

        //Act
        var testDto = dto.Parse<TestDto>();

        //Assert
        Assert.IsTrue(testDto!.aBoolean.IsSpecified);
        Assert.IsTrue(testDto.aBoolean.IsNull);
    }

    [TestMethod]
    public void True_value_should_give_the_specified_true_value()
    {
        //Arrange
        var dto = "{\"aBoolean\":true}";

        //Act
        var testDto = dto.Parse<TestDto>();

        //Assert
        Assert.IsTrue(testDto!.aBoolean.IsSpecified);
        Assert.IsFalse(testDto.aBoolean.IsNull);
        Assert.IsTrue(testDto.aBoolean.Value);
    }

    [TestMethod]
    public void False_value_should_give_the_specified_false_value()
    {
        //Arrange
        var dto = "{\"aBoolean\":false}";

        //Act
        var testDto = dto.Parse<TestDto>();

        //Assert
        Assert.IsTrue(testDto!.aBoolean.IsSpecified);
        Assert.IsFalse(testDto.aBoolean.IsNull);
        Assert.IsFalse(testDto.aBoolean.Value);
    }
}