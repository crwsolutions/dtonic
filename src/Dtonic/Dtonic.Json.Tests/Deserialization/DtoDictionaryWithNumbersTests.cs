using Dtonic.Dto.Extensions;
using TestClasses;

namespace Deserialization;

[TestClass]
public class DtoDictionaryWithNumbersTests
{

    [TestMethod]
    public void Unspecified_value_should_give_isset_is_false()
    {
        //Arrange
        var dto = "{}";

        //Act
        var testDto = dto.Parse<TestDto>();

        //Assert
        Assert.IsFalse(testDto!.aDictionaryWithNumbers.IsSpecified);
        Assert.IsTrue(testDto.aDictionaryWithNumbers.IsNull);
    }

    [TestMethod]
    public void Null_value_should_give_null()
    {
        //Arrange
        var dto = "{\"aDictionaryWithNumbers\":null}";

        //Act
        var testDto = dto.Parse<TestDto>();

        //Assert
        Assert.IsTrue(testDto!.aDictionaryWithNumbers.IsSpecified);
        Assert.IsTrue(testDto.aDictionaryWithNumbers.IsNull);
    }

    [TestMethod]
    public void Empty_dictionary_should_give_the_zero_number_of_items()
    {
        //Arrange
        var dto = "{\"aDictionaryWithNumbers\":{}}";

        //Act
        var testDto = dto.Parse<TestDto>();

        //Assert
        Assert.IsTrue(testDto!.aDictionaryWithNumbers.IsSpecified);
        Assert.IsFalse(testDto.aDictionaryWithNumbers.IsNull);
        Assert.AreEqual(0, testDto.aDictionaryWithNumbers.Value!.Count());
    }

    [TestMethod]
    public void Filled_object_dictionary_with_null_value()
    {
        //Arrange
        var dto = "{\"aDictionaryWithNumbers\":{\"a\":null}}";

        //Act
        var testDto = dto.Parse<TestDto>();
        var a = testDto!.aDictionaryWithNumbers.Value!.ToArray();

        //Assert
        Assert.IsTrue(testDto!.aDictionaryWithNumbers.IsSpecified);
        Assert.IsFalse(testDto.aDictionaryWithNumbers.IsNull);
        Assert.IsNull(a[0].Value);
        Assert.AreEqual(1, a.Length);
    }

    [TestMethod]
    public void Filled_dictionary_should_give_back_that_dictionary_value()
    {
        //Arrange
        var dto = "{\"aDictionaryWithNumbers\":{\"a\":null,\"b\":1.1}}";

        //Act
        var testDto = dto.Parse<TestDto>();
        var a = testDto!.aDictionaryWithNumbers.Value!.ToArray();

        //Assert
        Assert.IsTrue(testDto!.aDictionaryWithNumbers.IsSpecified);
        Assert.IsFalse(testDto.aDictionaryWithNumbers.IsNull);
        Assert.AreEqual("a", a[0].Key);
        Assert.AreEqual("b", a[1].Key);
        Assert.IsNull(a[0].Value);
        Assert.IsNotNull(a[1].Value);
        Assert.AreEqual(1.1m, a[1].Value);
        Assert.AreEqual(2, a.Length);
    }
}