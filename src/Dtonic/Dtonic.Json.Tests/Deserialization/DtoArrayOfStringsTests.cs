using Dtonic.Dto.Extensions;
using TestClasses;

namespace Deserialization;

[TestClass]
public class DtoArrayOfStringsTests
{
    [TestMethod]
    public void Unspecified_value_should_give_isset_is_false()
    {
        //Arrange
        var dto = "{}";

        //Act
        var testDto = dto.Parse<TestDto>();

        //Assert
        Assert.IsFalse(testDto!.arrayS.IsSpecified);
        Assert.IsTrue(testDto.arrayS.IsNull);
    }

    [TestMethod]
    public void Null_value_should_give_null()
    {
        //Arrange
        var dto = "{\"arrayS\":null}";

        //Act
        var testDto = dto.Parse<TestDto>();

        //Assert
        Assert.IsTrue(testDto!.arrayS.IsSpecified);
        Assert.IsTrue(testDto.arrayS.IsNull);
    }

    [TestMethod]
    public void Empty_array_should_give_the_zero_number_of_items()
    {
        //Arrange
        var dto = "{\"arrayS\":[]}";

        //Act
        var testDto = dto.Parse<TestDto>();

        //Assert
        Assert.IsTrue(testDto!.arrayS.IsSpecified);
        Assert.IsFalse(testDto.arrayS.IsNull);
        Assert.AreEqual(0, testDto.arrayS.Value!.Count());
    }

    [TestMethod]
    public void Filled_string_aray_should_give_back_that_array_value()
    {
        //Arrange
        var dto = "{\"arrayS\":[\"a\",\"b\"]}";

        //Act
        var testDto = dto.Parse<TestDto>();
        var a = testDto!.arrayS.Value!.ToArray();

        //Assert
        Assert.IsTrue(testDto!.arrayS.IsSpecified);
        Assert.IsFalse(testDto.arrayS.IsNull);
        Assert.AreEqual("a", a[0]);
        Assert.AreEqual("b", a[1]);
        Assert.AreEqual(2, a.Length);
    }

    [TestMethod]
    public void Null_element_string_aray_should_give_back_that_array_value()
    {
        //Arrange
        var dto = "{\"arrayS\":[\"a\",null]}";

        //Act
        var testDto = dto.Parse<TestDto>();
        var a = testDto!.arrayS.Value!.ToArray();

        //Assert
        Assert.IsTrue(testDto!.arrayS.IsSpecified);
        Assert.IsFalse(testDto.arrayS.IsNull);
        Assert.AreEqual("a", a[0]);
        Assert.IsNull(a[1]);
        Assert.AreEqual(2, a.Length);
    }

    [TestMethod]
    public void Empty_value_should_give_the_empty_value()
    {
        //Arrange
        var dto = "{\"street\":\"\"}";

        //Act
        var testDto = dto.Parse<TestDto>();

        //Assert
        Assert.IsTrue(testDto!.street.IsSpecified);
        Assert.IsFalse(testDto.street.IsNull);
        Assert.AreEqual(string.Empty, testDto.street.Value);
    }
}