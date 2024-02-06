using Dtonic.Dto.Extensions;
using TestClasses;

namespace Deserialization;

[TestClass]
public class DtoDictionaryWithArrayOfNumbersTests
{

    [TestMethod]
    public void Unspecified_value_should_give_isset_is_false()
    {
        //Arrange
        var dto = "{}";

        //Act
        var testDto = dto.Parse<TestDto>();

        //Assert
        Assert.IsFalse(testDto!.aDictionaryWithArrayOfNumbers.IsSpecified);
        Assert.IsTrue(testDto.aDictionaryWithArrayOfNumbers.IsNull);
    }

    [TestMethod]
    public void Null_value_should_give_null()
    {
        //Arrange
        var dto = "{\"aDictionaryWithArrayOfNumbers\":null}";

        //Act
        var testDto = dto.Parse<TestDto>();

        //Assert
        Assert.IsTrue(testDto!.aDictionaryWithArrayOfNumbers.IsSpecified);
        Assert.IsTrue(testDto.aDictionaryWithArrayOfNumbers.IsNull);
    }

    [TestMethod]
    public void Empty_dictionary_should_give_the_zero_number_of_items()
    {
        //Arrange
        var dto = "{\"aDictionaryWithArrayOfNumbers\":{}}";

        //Act
        var testDto = dto.Parse<TestDto>();

        //Assert
        Assert.IsTrue(testDto!.aDictionaryWithArrayOfNumbers.IsSpecified);
        Assert.IsFalse(testDto.aDictionaryWithArrayOfNumbers.IsNull);
        Assert.AreEqual(0, testDto.aDictionaryWithArrayOfNumbers.Value!.Count);
    }

    [TestMethod]
    public void Filled_object_dictionary_with_null_value()
    {
        //Arrange
        var dto = "{\"aDictionaryWithArrayOfNumbers\":[{\"a\":null}]}";

        //Act
        var testDto = dto.Parse<TestDto>();
        var a = testDto!.aDictionaryWithArrayOfNumbers.Value!.ToArray();

        //Assert
        Assert.IsTrue(testDto!.aDictionaryWithArrayOfNumbers.IsSpecified);
        Assert.IsFalse(testDto.aDictionaryWithArrayOfNumbers.IsNull);
        Assert.IsNull(a[0].Value);
        Assert.AreEqual(1, a.Length);
    }

    [TestMethod]
    public void Filled_object_dictionary_with_empty_value()
    {
        //Arrange
        var dto = "{\"aDictionaryWithArrayOfNumbers\":[{\"a\":[]}]}";

        //Act
        var testDto = dto.Parse<TestDto>();
        var a = testDto!.aDictionaryWithArrayOfNumbers.Value!.ToArray();

        //Assert
        Assert.IsTrue(testDto!.aDictionaryWithArrayOfNumbers.IsSpecified);
        Assert.IsFalse(testDto.aDictionaryWithArrayOfNumbers.IsNull);
        Assert.AreEqual(1, a.Length);
        Assert.AreEqual(0, a[0].Value!.Count());
    }

    [TestMethod]
    public void Filled_dictionary_should_give_back_that_dictionary_value()
    {
        //Arrange
        var dto = "{\"aDictionaryWithArrayOfNumbers\":[{\"a\":null},{\"b\":[1,2,3,null]}]}";

        //Act
        var testDto = dto.Parse<TestDto>();
        var a = testDto!.aDictionaryWithArrayOfNumbers.Value!.ToArray();
        var b = a[1].Value!.ToArray();

        //Assert
        Assert.IsTrue(testDto!.aDictionaryWithArrayOfNumbers.IsSpecified);
        Assert.IsFalse(testDto.aDictionaryWithArrayOfNumbers.IsNull);
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