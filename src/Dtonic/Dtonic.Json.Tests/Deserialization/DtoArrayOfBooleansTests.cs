using Dtonic.Dto.Extensions;
using TestClasses;

namespace Deserialization;

[TestClass]
public class DtoArrayOfBooleansTests
{
    [TestMethod]
    public void Unspecified_value_should_give_isset_is_false()
    {
        //Arrange
        var dto = "{}";

        //Act
        var testDto = dto.Parse<TestDto>();

        //Assert
        Assert.IsFalse(testDto!.arrayB.IsSpecified);
        Assert.IsTrue(testDto.arrayB.IsNull);
    }

    [TestMethod]
    public void Null_value_should_give_null()
    {
        //Arrange
        var dto = "{\"arrayB\":null}";

        //Act
        var testDto = dto.Parse<TestDto>();

        //Assert
        Assert.IsTrue(testDto!.arrayB.IsSpecified);
        Assert.IsTrue(testDto.arrayB.IsNull);
    }

    [TestMethod]
    public void Empty_array_should_give_the_zero_number_of_items()
    {
        //Arrange
        var dto = "{\"arrayB\":[]}";

        //Act
        var testDto = dto.Parse<TestDto>();

        //Assert
        Assert.IsTrue(testDto!.arrayB.IsSpecified);
        Assert.IsFalse(testDto.arrayB.IsNull);
        Assert.AreEqual(0, testDto.arrayB.Value!.Count());
    }

    [TestMethod]
    public void Filled_boolean_aray_should_give_back_that_array_value()
    {
        //Arrange
        var dto = "{\"arrayB\":[true, false, true]}";

        //Act
        var testDto = dto.Parse<TestDto>();
        var a = testDto!.arrayB.Value!.ToArray();

        //Assert
        Assert.IsTrue(testDto!.arrayB.IsSpecified);
        Assert.IsFalse(testDto.arrayB.IsNull);
        Assert.IsTrue(a[0]);
        Assert.IsFalse(a[1]);
        Assert.IsTrue(a[2]);
        Assert.AreEqual(3, a.Length);
    }

    [TestMethod]
    public void Null_element_boolean_aray_should_give_back_that_array_value()
    {
        //Arrange
        var dto = "{\"arrayB\":[true, false, null]}";

        //Act
        var testDto = dto.Parse<TestDto>();
        var a = testDto!.arrayB.Value!.ToArray();

        //Assert
        Assert.IsTrue(testDto!.arrayB.IsSpecified);
        Assert.IsFalse(testDto.arrayB.IsNull);
        Assert.IsTrue(a[0]);
        Assert.IsFalse(a[1]);
        Assert.IsNull(a[2]);
        Assert.AreEqual(3, a.Length);
    }
}