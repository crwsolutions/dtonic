using Dtonic.Dto.Extensions;
using TestClasses;

namespace Deserialization;

[TestClass]
public class DtoDictionaryWithArrayofNumbersTests
{

    [TestMethod]
    public void Unspecified_value_should_give_isset_is_false()
    {
        //Arrange
        var dto = "{}";

        //Act
        var testDto = dto.Parse<TestDto>();

        //Assert
        Assert.IsFalse(testDto!.aDictionaryWithArrayofNumbers.IsSpecified);
        Assert.IsTrue(testDto.aDictionaryWithArrayofNumbers.IsNull);
    }

    [TestMethod]
    public void Null_value_should_give_null()
    {
        //Arrange
        var dto = "{\"aDictionaryWithArrayofNumbers\":null}";

        //Act
        var testDto = dto.Parse<TestDto>();

        //Assert
        Assert.IsTrue(testDto!.aDictionaryWithArrayofNumbers.IsSpecified);
        Assert.IsTrue(testDto.aDictionaryWithArrayofNumbers.IsNull);
    }

    [TestMethod]
    public void Empty_dictionary_should_give_the_zero_number_of_items()
    {
        //Arrange
        var dto = "{\"aDictionaryWithArrayofNumbers\":{}}";

        //Act
        var testDto = dto.Parse<TestDto>();

        //Assert
        Assert.IsTrue(testDto!.aDictionaryWithArrayofNumbers.IsSpecified);
        Assert.IsFalse(testDto.aDictionaryWithArrayofNumbers.IsNull);
        Assert.AreEqual(0, testDto.aDictionaryWithArrayofNumbers.Value!.Count());
    }

    [TestMethod]
    public void Filled_object_dictionary_with_null_value()
    {
        //Arrange
        var dto = "{\"aDictionaryWithArrayofNumbers\":[{\"a\":null}]}";

        //Act
        var testDto = dto.Parse<TestDto>();
        var a = testDto!.aDictionaryWithArrayofNumbers.Value!.ToArray();

        //Assert
        Assert.IsTrue(testDto!.aDictionaryWithArrayofNumbers.IsSpecified);
        Assert.IsFalse(testDto.aDictionaryWithArrayofNumbers.IsNull);
        Assert.IsNull(a[0].Value);
        Assert.AreEqual(1, a.Length);
    }

    [TestMethod]
    public void Filled_object_dictionary_with_empty_value()
    {
        //Arrange
        var dto = "{\"aDictionaryWithArrayofNumbers\":[{\"a\":[]}]}";

        //Act
        var testDto = dto.Parse<TestDto>();
        var a = testDto!.aDictionaryWithArrayofNumbers.Value!.ToArray();

        //Assert
        Assert.IsTrue(testDto!.aDictionaryWithArrayofNumbers.IsSpecified);
        Assert.IsFalse(testDto.aDictionaryWithArrayofNumbers.IsNull);
        Assert.AreEqual(1, a.Length);
        Assert.AreEqual(0, a[0].Value!.Count());
    }

    [TestMethod]
    public void Filled_dictionary_should_give_back_that_dictionary_value()
    {
        //Arrange
        var dto = "{\"aDictionaryWithArrayofNumbers\":[{\"a\":null},{\"b\":[1,2,3,null]}]}";

        //Act
        var testDto = dto.Parse<TestDto>();
        var a = testDto!.aDictionaryWithArrayofNumbers.Value!.ToArray();
        var b = a[1].Value!.ToArray();

        //Assert
        Assert.IsTrue(testDto!.aDictionaryWithArrayofNumbers.IsSpecified);
        Assert.IsFalse(testDto.aDictionaryWithArrayofNumbers.IsNull);
        Assert.AreEqual("a", a[0].Key);
        Assert.AreEqual("b", a[1].Key);
        Assert.IsNull(a[0].Value);
        Assert.IsNotNull(a[1].Value);
        Assert.AreEqual(1, b[0]);
        Assert.AreEqual(2, b[1]);
        Assert.AreEqual(3, b[2]);
        Assert.IsNull(b[3]);
        Assert.AreEqual(2, a.Length);
        Assert.AreEqual(4, b.Length);
    }
}