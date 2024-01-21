using Dtonic.Dto.Extensions;
using TestClasses;

namespace Deserialization;

[TestClass]
public class DtoArrayOfNumbersTests
{
    [TestMethod]
    public void Unspecified_value_should_give_isset_is_false()
    {
        //Arrange
        var dto = "{}";

        //Act
        var testDto = dto.Parse<TestDto>();

        //Assert
        Assert.IsFalse(testDto!.arrayI.IsSpecified);
        Assert.IsTrue(testDto.arrayI.IsNull);
    }

    [TestMethod]
    public void Null_value_should_give_null()
    {
        //Arrange
        var dto = "{\"arrayI\":null}";

        //Act
        var testDto = dto.Parse<TestDto>();

        //Assert
        Assert.IsTrue(testDto!.arrayI.IsSpecified);
        Assert.IsTrue(testDto.arrayI.IsNull);
    }

    [TestMethod]
    public void Empty_array_should_give_the_zero_number_of_items()
    {
        //Arrange
        var dto = "{\"arrayI\":[]}";

        //Act
        var testDto = dto.Parse<TestDto>();

        //Assert
        Assert.IsTrue(testDto!.arrayI.IsSpecified);
        Assert.IsFalse(testDto.arrayI.IsNull);
        Assert.AreEqual(0, testDto.arrayI.Value!.Count());
    }

    [TestMethod]
    public void Filled_number_aray_should_give_back_that_array_value()
    {
        //Arrange
        var dto = "{\"arrayI\":[1,2,3]}";

        //Act
        var testDto = dto.Parse<TestDto>();
        var a = testDto!.arrayI.Value!.ToArray();

        //Assert
        Assert.IsTrue(testDto!.arrayI.IsSpecified);
        Assert.IsFalse(testDto.arrayI.IsNull);
        Assert.AreEqual(1, a[0]);
        Assert.AreEqual(2, a[1]);
        Assert.AreEqual(3, a[2]);
        Assert.AreEqual(3, a.Length);
    }

    [TestMethod]
    public void Null_element_number_aray_should_give_back_that_array_value()
    {
        //Arrange
        var dto = "{\"arrayI\":[1,null,3]}";

        //Act
        var testDto = dto.Parse<TestDto>();
        var a = testDto!.arrayI.Value!.ToArray();

        //Assert
        Assert.IsTrue(testDto!.arrayI.IsSpecified);
        Assert.IsFalse(testDto.arrayI.IsNull);
        Assert.AreEqual(1, a[0]);
        Assert.IsNull(a[1]);
        Assert.AreEqual(3, a[2]);
        Assert.AreEqual(3, a.Length);
    }
}