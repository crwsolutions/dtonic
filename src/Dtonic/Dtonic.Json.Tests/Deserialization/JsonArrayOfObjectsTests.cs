using Dtonic.Json.Extensions;
using TestClasses;

namespace Deserialization;

[TestClass]
public class JsonArrayOfObjectsTests
{
    [TestMethod]
    public void Unspecified_value_should_give_isset_is_false()
    {
        //Arrange
        var json = "{}";

        //Act
        var testDto = json.Parse<TestDto>();

        //Assert
        Assert.IsFalse(testDto!.array.IsSpecified);
        Assert.IsTrue(testDto.array.IsNull);
    }

    [TestMethod]
    public void Null_value_should_give_null()
    {
        //Arrange
        var json = "{\"array\":null}";

        //Act
        var testDto = json.Parse<TestDto>();

        //Assert
        Assert.IsTrue(testDto!.array.IsSpecified);
        Assert.IsTrue(testDto.array.IsNull);
    }

    [TestMethod]
    public void Empty_array_should_give_the_zero_number_of_items()
    {
        //Arrange
        var json = "{\"array\":[]}";

        //Act
        var testDto = json.Parse<TestDto>();

        //Assert
        Assert.IsTrue(testDto!.array.IsSpecified);
        Assert.IsFalse(testDto.array.IsNull);
        Assert.AreEqual(0, testDto.array.Value!.Count());
    }

    [TestMethod]
    public void Filled_object_aray_should_give_back_that_array_value()
    {
        //Arrange
        var json = "{\"array\":[{\"street\":\" wallstreet \"}]}";

        //Act
        var testDto = json.Parse<TestDto>();
        var a = testDto!.array.Value!.ToArray();

        //Assert
        Assert.IsTrue(testDto!.array.IsSpecified);
        Assert.IsFalse(testDto.array.IsNull);
        Assert.AreEqual(" wallstreet ", a[0].street.Value);
        Assert.AreEqual(1, a.Length);
    }

    [TestMethod]
    public void Filled_string_aray_should_give_back_that_array_value()
    {
        //Arrange
        var json = "{\"arrayS\":[\"a\",\"b\"]}";

        //Act
        var testDto = json.Parse<TestDto>();
        var a = testDto!.arrayS.Value!.ToArray();

        //Assert
        Assert.IsTrue(testDto!.arrayS.IsSpecified);
        Assert.IsFalse(testDto.arrayS.IsNull);
        Assert.AreEqual("a", a[0]);
        Assert.AreEqual("b", a[1]);
        Assert.AreEqual(2, a.Length);
    }

    [TestMethod]
    public void Filled_number_aray_should_give_back_that_array_value()
    {
        //Arrange
        var json = "{\"arrayI\":[1,2,3]}";

        //Act
        var testDto = json.Parse<TestDto>();
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
    public void Empty_value_should_give_the_empty_value()
    {
        //Arrange
        var json = "{\"street\":\"\"}";

        //Act
        var testDto = json.Parse<TestDto>();

        //Assert
        Assert.IsTrue(testDto!.street.IsSpecified);
        Assert.IsFalse(testDto.street.IsNull);
        Assert.AreEqual(string.Empty, testDto.street.Value);
    }
}