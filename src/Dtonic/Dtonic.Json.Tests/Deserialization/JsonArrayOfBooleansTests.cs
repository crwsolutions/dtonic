using Dtonic.Json.Extensions;
using TestClasses;

namespace Deserialization;

[TestClass]
public class JsonArrayOfBooleansTests
{
    [TestMethod]
    public void Unspecified_value_should_give_isset_is_false()
    {
        //Arrange
        var json = "{}";

        //Act
        var testDto = json.Parse<TestDto>();

        //Assert
        Assert.IsFalse(testDto!.arrayB.IsSpecified);
        Assert.IsTrue(testDto.arrayB.IsNull);
    }

    [TestMethod]
    public void Null_value_should_give_null()
    {
        //Arrange
        var json = "{\"arrayB\":null}";

        //Act
        var testDto = json.Parse<TestDto>();

        //Assert
        Assert.IsTrue(testDto!.arrayB.IsSpecified);
        Assert.IsTrue(testDto.arrayB.IsNull);
    }

    [TestMethod]
    public void Empty_array_should_give_the_zero_number_of_items()
    {
        //Arrange
        var json = "{\"arrayB\":[]}";

        //Act
        var testDto = json.Parse<TestDto>();

        //Assert
        Assert.IsTrue(testDto!.arrayB.IsSpecified);
        Assert.IsFalse(testDto.arrayB.IsNull);
        Assert.AreEqual(0, testDto.arrayB.Value!.Count());
    }

    [TestMethod]
    public void Filled_boolean_aray_should_give_back_that_array_value()
    {
        //Arrange
        var json = "{\"arrayB\":[true, false, true]}";

        //Act
        var testDto = json.Parse<TestDto>();
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
        var json = "{\"arrayB\":[true, false, null]}";

        //Act
        var testDto = json.Parse<TestDto>();
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