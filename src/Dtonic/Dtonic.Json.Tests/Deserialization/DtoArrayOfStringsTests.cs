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
        Assert.IsFalse(testDto!.anArrayOfStrings.IsSpecified);
        Assert.IsTrue(testDto.anArrayOfStrings.IsNull);
    }

    [TestMethod]
    public void Null_value_should_give_null()
    {
        //Arrange
        var dto = "{\"anArrayOfStrings\":null}";

        //Act
        var testDto = dto.Parse<TestDto>();

        //Assert
        Assert.IsTrue(testDto!.anArrayOfStrings.IsSpecified);
        Assert.IsTrue(testDto.anArrayOfStrings.IsNull);
    }

    [TestMethod]
    public void Empty_array_should_give_the_zero_number_of_items()
    {
        //Arrange
        var dto = "{\"anArrayOfStrings\":[]}";

        //Act
        var testDto = dto.Parse<TestDto>();

        //Assert
        Assert.IsTrue(testDto!.anArrayOfStrings.IsSpecified);
        Assert.IsFalse(testDto.anArrayOfStrings.IsNull);
        Assert.AreEqual(0, testDto.anArrayOfStrings.Value!.Count());
    }

    [TestMethod]
    public void Filled_string_aray_should_give_back_that_array_value()
    {
        //Arrange
        var dto = "{\"anArrayOfStrings\":[\"a\",\"b\"]}";

        //Act
        var testDto = dto.Parse<TestDto>();
        var a = testDto!.anArrayOfStrings.Value!.ToArray();

        //Assert
        Assert.IsTrue(testDto!.anArrayOfStrings.IsSpecified);
        Assert.IsFalse(testDto.anArrayOfStrings.IsNull);
        Assert.AreEqual("a", a[0]);
        Assert.AreEqual("b", a[1]);
        Assert.AreEqual(2, a.Length);
    }

    [TestMethod]
    public void Null_element_string_aray_should_give_back_that_array_value()
    {
        //Arrange
        var dto = "{\"anArrayOfStrings\":[\"a\",null]}";

        //Act
        var testDto = dto.Parse<TestDto>();
        var a = testDto!.anArrayOfStrings.Value!.ToArray();

        //Assert
        Assert.IsTrue(testDto!.anArrayOfStrings.IsSpecified);
        Assert.IsFalse(testDto.anArrayOfStrings.IsNull);
        Assert.AreEqual("a", a[0]);
        Assert.IsNull(a[1]);
        Assert.AreEqual(2, a.Length);
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