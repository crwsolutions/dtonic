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
        Assert.IsFalse(testDto!.aNumber.IsSpecified);
        Assert.IsTrue(testDto.aNumber.IsNull);
    }

    [TestMethod]
    public void Null_value_should_give_null()
    {
        //Arrange
        var dto = "{\"aNumber\":null}";

        //Act
        var testDto = dto.Parse<TestDto>();

        //Assert
        Assert.IsTrue(testDto!.aNumber.IsSpecified);
        Assert.IsTrue(testDto.aNumber.IsNull);
    }

    [TestMethod]
    public void Specified_value_should_give_the_specified_value()
    {
        //Arrange
        var dto = "{\"aNumber\":1.1}";

        //Act
        var testDto = dto.Parse<TestDto>();

        //Assert
        Assert.IsTrue(testDto!.aNumber.IsSpecified);
        Assert.IsFalse(testDto.aNumber.IsNull);
        Assert.AreEqual(1.1m, testDto.aNumber.Value);
    }
}