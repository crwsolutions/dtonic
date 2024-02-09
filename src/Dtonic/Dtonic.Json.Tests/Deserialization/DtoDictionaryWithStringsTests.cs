using Dtonic.Dto.Extensions;
using TestClasses;

namespace Deserialization;

[TestClass]
public class DtoDictionaryWithStringsTests
{

    [TestMethod]
    public void Unspecified_value_should_give_isset_is_false()
    {
        //Arrange
        var dto = "{}";

        //Act
        var testDto = dto.Parse<TestDto>();

        //Assert
        Assert.IsFalse(testDto!.aDictionaryWithStrings.IsSpecified);
        Assert.IsTrue(testDto.aDictionaryWithStrings.IsNull);
    }

    [TestMethod]
    public void Null_value_should_give_null()
    {
        //Arrange
        var dto = "{\"aDictionaryWithStrings\":null}";

        //Act
        var testDto = dto.Parse<TestDto>();

        //Assert
        Assert.IsTrue(testDto!.aDictionaryWithStrings.IsSpecified);
        Assert.IsTrue(testDto.aDictionaryWithStrings.IsNull);
    }

    [TestMethod]
    public void Empty_dictionary_should_give_the_zero_number_of_items()
    {
        //Arrange
        var dto = "{\"aDictionaryWithStrings\":{}}";

        //Act
        var testDto = dto.Parse<TestDto>();

        //Assert
        Assert.IsTrue(testDto!.aDictionaryWithStrings.IsSpecified);
        Assert.IsFalse(testDto.aDictionaryWithStrings.IsNull);
        Assert.AreEqual(0, testDto.aDictionaryWithStrings.Value!.Count());
    }

    [TestMethod]
    public void Filled_object_dictionary_with_null_value()
    {
        //Arrange
        var dto = "{\"aDictionaryWithStrings\":{\"a\":null}}";

        //Act
        var testDto = dto.Parse<TestDto>();
        var a = testDto!.aDictionaryWithStrings.Value!.ToArray();

        //Assert
        Assert.IsTrue(testDto!.aDictionaryWithStrings.IsSpecified);
        Assert.IsFalse(testDto.aDictionaryWithStrings.IsNull);
        Assert.IsNull(a[0].Value);
        Assert.AreEqual(1, a.Length);
    }

    [TestMethod]
    public void Filled_dictionary_should_give_back_that_dictionary_value()
    {
        //Arrange
        var dto = "{\"aDictionaryWithStrings\":{\"a\":null,\"b\":\"bob\"}}";

        //Act
        var testDto = dto.Parse<TestDto>();
        var a = testDto!.aDictionaryWithStrings.Value!.ToArray();

        //Assert
        Assert.IsTrue(testDto!.aDictionaryWithStrings.IsSpecified);
        Assert.IsFalse(testDto.aDictionaryWithStrings.IsNull);
        Assert.AreEqual("a", a[0].Key);
        Assert.AreEqual("b", a[1].Key);
        Assert.IsNull(a[0].Value);
        Assert.IsNotNull(a[1].Value);
        Assert.AreEqual("bob",a[1].Value);
        Assert.AreEqual(2, a.Length);
    }
}