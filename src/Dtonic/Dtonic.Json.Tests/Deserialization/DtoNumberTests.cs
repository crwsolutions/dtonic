using Dtonic.Dto.Extensions;
using TestClasses;

namespace Deserialization;

[TestClass]
public class DtoNumberTests
{
    [TestMethod]
    public void Unspecified_value_should_give_isset_is_false()
    {
        //Arrange
        var dto = "{}";

        //Act
        var testDto = dto.Parse<TestDto>();

        //Assert
        Assert.IsFalse(testDto!.number.IsSpecified);
        Assert.IsTrue(testDto.number.IsNull);
    }

    [TestMethod]
    public void Null_value_should_give_null()
    {
        //Arrange
        var dto = "{\"number\":null}";

        //Act
        var testDto = dto.Parse<TestDto>();

        //Assert
        Assert.IsTrue(testDto!.number.IsSpecified);
        Assert.IsTrue(testDto.number.IsNull);
    }

    [TestMethod]
    public void Specified_value_should_give_the_specified_value()
    {
        //Arrange
        var dto = "{\"number\":1.1}";

        //Act
        var testDto = dto.Parse<TestDto>();

        //Assert
        Assert.IsTrue(testDto!.number.IsSpecified);
        Assert.IsFalse(testDto.number.IsNull);
        Assert.AreEqual(1.1m, testDto.number.Value);
    }
}