using Dtonic.Dto.Extensions;
using TestClasses;

namespace Deserialization;

[TestClass]
public class DtoDictionaryWithObjectsTests
{

    [TestMethod]
    public void Null_value_should_give_null()
    {
        //Arrange
        var dto = "{\"anArrayOfObjects\":null}";

        //Act
        var testDto = dto.Parse<TestDto>();

        //Assert
        Assert.IsTrue(testDto!.anArrayOfObjects.IsSpecified);
        Assert.IsTrue(testDto.anArrayOfObjects.IsNull);
    }

    [TestMethod]
    public void Empty_array_should_give_the_zero_number_of_items()
    {
        //Arrange
        var dto = "{\"anArrayOfObjects\":[]}";

        //Act
        var testDto = dto.Parse<TestDto>();

        //Assert
        Assert.IsTrue(testDto!.anArrayOfObjects.IsSpecified);
        Assert.IsFalse(testDto.anArrayOfObjects.IsNull);
        Assert.AreEqual(0, testDto.anArrayOfObjects.Value!.Count());
    }

    [TestMethod]
    public void Filled_object_aray_should_give_back_that_array_value()
    {
        //Arrange
        var dto = "{\"anArrayOfObjects\":[{\"aString\":\" wallstreet \"}]}";

        //Act
        var testDto = dto.Parse<TestDto>();
        var a = testDto!.anArrayOfObjects.Value!.ToArray();

        //Assert
        Assert.IsTrue(testDto!.anArrayOfObjects.IsSpecified);
        Assert.IsFalse(testDto.anArrayOfObjects.IsNull);
        Assert.AreEqual(" wallstreet ", a[0].aString.Value);
        Assert.AreEqual(1, a.Length);
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
    public void Filled_number_aray_should_give_back_that_array_value()
    {
        //Arrange
        var dto = "{\"anArrayOfNumbers\":[1,2,3]}";

        //Act
        var testDto = dto.Parse<TestDto>();
        var a = testDto!.anArrayOfNumbers.Value!.ToArray();

        //Assert
        Assert.IsTrue(testDto!.anArrayOfNumbers.IsSpecified);
        Assert.IsFalse(testDto.anArrayOfNumbers.IsNull);
        Assert.AreEqual(1, a[0]);
        Assert.AreEqual(2, a[1]);
        Assert.AreEqual(3, a[2]);
        Assert.AreEqual(3, a.Length);
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