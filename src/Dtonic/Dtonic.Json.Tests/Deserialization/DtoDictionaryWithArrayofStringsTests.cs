using Dtonic.Dto.Extensions;
using TestClasses;

namespace Deserialization;

[TestClass]
public class DtoDictionaryWithArrayOfStringsTests
{

    [TestMethod]
    public void Unspecified_value_should_give_isset_is_false()
    {
        //Arrange
        var dto = "{}";

        //Act
        var testDto = dto.Parse<TestDto>();

        //Assert
        Assert.IsFalse(testDto!.aDictionaryWithArrayOfStrings.IsSpecified);
        Assert.IsTrue(testDto.aDictionaryWithArrayOfStrings.IsNull);
    }

    [TestMethod]
    public void Null_value_should_give_null()
    {
        //Arrange
        var dto = "{\"aDictionaryWithArrayOfStrings\":null}";

        //Act
        var testDto = dto.Parse<TestDto>();

        //Assert
        Assert.IsTrue(testDto!.aDictionaryWithArrayOfStrings.IsSpecified);
        Assert.IsTrue(testDto.aDictionaryWithArrayOfStrings.IsNull);
    }

    [TestMethod]
    public void Empty_dictionary_should_give_the_zero_number_of_items()
    {
        //Arrange
        var dto = "{\"aDictionaryWithArrayOfStrings\":{}}";

        //Act
        var testDto = dto.Parse<TestDto>();

        //Assert
        Assert.IsTrue(testDto!.aDictionaryWithArrayOfStrings.IsSpecified);
        Assert.IsFalse(testDto.aDictionaryWithArrayOfStrings.IsNull);
        Assert.AreEqual(0, testDto.aDictionaryWithArrayOfStrings.Value!.Count);
    }

    [TestMethod]
    public void Filled_object_dictionary_with_null_value()
    {
        //Arrange
        var dto = "{\"aDictionaryWithArrayOfStrings\":[{\"a\":null}]}";

        //Act
        var testDto = dto.Parse<TestDto>();
        var a = testDto!.aDictionaryWithArrayOfStrings.Value!.ToArray();

        //Assert
        Assert.IsTrue(testDto!.aDictionaryWithArrayOfStrings.IsSpecified);
        Assert.IsFalse(testDto.aDictionaryWithArrayOfStrings.IsNull);
        Assert.IsNull(a[0].Value);
        Assert.AreEqual(1, a.Length);
    }

    [TestMethod]
    public void Filled_object_dictionary_with_empty_value()
    {
        //Arrange
        var dto = "{\"aDictionaryWithArrayOfStrings\":[{\"a\":[]}]}";

        //Act
        var testDto = dto.Parse<TestDto>();
        var a = testDto!.aDictionaryWithArrayOfStrings.Value!.ToArray();

        //Assert
        Assert.IsTrue(testDto!.aDictionaryWithArrayOfStrings.IsSpecified);
        Assert.IsFalse(testDto.aDictionaryWithArrayOfStrings.IsNull);
        Assert.AreEqual(1, a.Length);
        Assert.AreEqual(0, a[0].Value!.Count());
    }

    [TestMethod]
    public void Filled_dictionary_should_give_back_that_dictionary_value()
    {
        //Arrange
        var dto = "{\"aDictionaryWithArrayOfStrings\":[{\"a\":null},{\"b\":[\"a\",\"b\",\"c\",null]}]}";

        //Act
        var testDto = dto.Parse<TestDto>();
        var a = testDto!.aDictionaryWithArrayOfStrings.Value!.ToArray();
        var b = a[1].Value!.ToArray();

        //Assert
        Assert.IsTrue(testDto!.aDictionaryWithArrayOfStrings.IsSpecified);
        Assert.IsFalse(testDto.aDictionaryWithArrayOfStrings.IsNull);
        Assert.AreEqual("a", a[0].Key);
        Assert.AreEqual("b", a[1].Key);
        Assert.IsNull(a[0].Value);
        Assert.IsNotNull(a[1].Value);
        Assert.AreEqual("a",b[0]);
        Assert.AreEqual("b", b[1]);
        Assert.AreEqual("c", b[2]);
        Assert.IsNull(b[3]);
        Assert.AreEqual(2, a.Length);
    }
}