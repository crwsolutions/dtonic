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
        Assert.IsFalse(testDto!.isTrue.IsSpecified);
        Assert.IsTrue(testDto.isTrue.IsNull);
    }

    [TestMethod]
    public void Null_value_should_give_null()
    {
        //Arrange
        var dto = "{\"isTrue\":null}";

        //Act
        var testDto = dto.Parse<TestDto>();

        //Assert
        Assert.IsTrue(testDto!.isTrue.IsSpecified);
        Assert.IsTrue(testDto.isTrue.IsNull);
    }

    [TestMethod]
    public void True_value_should_give_the_specified_true_value()
    {
        //Arrange
        var dto = "{\"isTrue\":true}";

        //Act
        var testDto = dto.Parse<TestDto>();

        //Assert
        Assert.IsTrue(testDto!.isTrue.IsSpecified);
        Assert.IsFalse(testDto.isTrue.IsNull);
        Assert.IsTrue(testDto.isTrue.Value);
    }

    [TestMethod]
    public void False_value_should_give_the_specified_false_value()
    {
        //Arrange
        var dto = "{\"isTrue\":false}";

        //Act
        var testDto = dto.Parse<TestDto>();

        //Assert
        Assert.IsTrue(testDto!.isTrue.IsSpecified);
        Assert.IsFalse(testDto.isTrue.IsNull);
        Assert.IsFalse(testDto.isTrue.Value);
    }
}