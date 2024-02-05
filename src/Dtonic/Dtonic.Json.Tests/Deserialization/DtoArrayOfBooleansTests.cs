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
        Assert.IsFalse(testDto!.anArrayOfBooleans.IsSpecified);
        Assert.IsTrue(testDto.anArrayOfBooleans.IsNull);
    }

    [TestMethod]
    public void Null_value_should_give_null()
    {
        //Arrange
        var dto = "{\"anArrayOfBooleans\":null}";

        //Act
        var testDto = dto.Parse<TestDto>();

        //Assert
        Assert.IsTrue(testDto!.anArrayOfBooleans.IsSpecified);
        Assert.IsTrue(testDto.anArrayOfBooleans.IsNull);
    }

    [TestMethod]
    public void Empty_array_should_give_the_zero_number_of_items()
    {
        //Arrange
        var dto = "{\"anArrayOfBooleans\":[]}";

        //Act
        var testDto = dto.Parse<TestDto>();

        //Assert
        Assert.IsTrue(testDto!.anArrayOfBooleans.IsSpecified);
        Assert.IsFalse(testDto.anArrayOfBooleans.IsNull);
        Assert.AreEqual(0, testDto.anArrayOfBooleans.Value!.Count());
    }

    [TestMethod]
    public void Filled_boolean_aray_should_give_back_that_array_value()
    {
        //Arrange
        var dto = "{\"anArrayOfBooleans\":[true, false, true]}";

        //Act
        var testDto = dto.Parse<TestDto>();
        var a = testDto!.anArrayOfBooleans.Value!.ToArray();

        //Assert
        Assert.IsTrue(testDto!.anArrayOfBooleans.IsSpecified);
        Assert.IsFalse(testDto.anArrayOfBooleans.IsNull);
        Assert.IsTrue(a[0]);
        Assert.IsFalse(a[1]);
        Assert.IsTrue(a[2]);
        Assert.AreEqual(3, a.Length);
    }

    [TestMethod]
    public void Null_element_boolean_aray_should_give_back_that_array_value()
    {
        //Arrange
        var dto = "{\"anArrayOfBooleans\":[true, false, null]}";

        //Act
        var testDto = dto.Parse<TestDto>();
        var a = testDto!.anArrayOfBooleans.Value!.ToArray();

        //Assert
        Assert.IsTrue(testDto!.anArrayOfBooleans.IsSpecified);
        Assert.IsFalse(testDto.anArrayOfBooleans.IsNull);
        Assert.IsTrue(a[0]);
        Assert.IsFalse(a[1]);
        Assert.IsNull(a[2]);
        Assert.AreEqual(3, a.Length);
    }
}