using Dtonic.Dto.Extensions;
using TestClasses;

namespace Deserialization;

[TestClass]
public class DtoStringTests
{
    [TestMethod]
    public void Unspecified_value_should_give_isset_is_false()
    {
        //Arrange
        var dto = "{}";

        //Act
        var testDto = dto.Parse<TestDto>();

        //Assert
        Assert.IsFalse(testDto!.aString.IsSpecified);
        Assert.IsTrue(testDto.aString.IsNull);
    }

    [TestMethod]
    public void Null_value_should_give_null()
    {
        //Arrange
        var dto = "{\"aString\":null}";

        //Act
        var testDto = dto.Parse<TestDto>();

        //Assert
        Assert.IsTrue(testDto!.aString.IsSpecified);
        Assert.IsTrue(testDto.aString.IsNull);
    }

    [TestMethod]
    public void Specified_value_should_give_the_specified_value()
    {
        //Arrange
        var dto = "{\"aString\":\" wallstreet \"}";

        //Act
        var testDto = dto.Parse<TestDto>();

        //Assert
        Assert.IsTrue(testDto!.aString.IsSpecified);
        Assert.IsFalse(testDto.aString.IsNull);
        Assert.AreEqual(" wallstreet ", testDto.aString.Value);
    }

    [TestMethod]
    public void Empty_value_should_give_the_empty_value()
    {
        //Arrange
        var dto = "{\"aString\":\"\"}";

        //Act
        var testDto = dto.Parse<TestDto>();

        //Assert
        Assert.IsTrue(testDto!.aString.IsSpecified);
        Assert.IsFalse(testDto.aString.IsNull);
        Assert.AreEqual(string.Empty, testDto.aString.Value);
    }
}