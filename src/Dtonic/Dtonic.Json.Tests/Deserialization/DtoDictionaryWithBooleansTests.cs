using Dtonic.Dto.Extensions;
using TestClasses;

namespace Deserialization;

[TestClass]
public class DtoDictionaryWithBooleansTests
{

    [TestMethod]
    public void Unspecified_value_should_give_isset_is_false()
    {
        //Arrange
        var dto = "{}";

        //Act
        var testDto = dto.Parse<TestDto>();

        //Assert
        Assert.IsFalse(testDto!.aDictionaryWithBooleans.IsSpecified);
        Assert.IsTrue(testDto.aDictionaryWithBooleans.IsNull);
    }

    [TestMethod]
    public void Null_value_should_give_null()
    {
        //Arrange
        var dto = "{\"aDictionaryWithBooleans\":null}";

        //Act
        var testDto = dto.Parse<TestDto>();

        //Assert
        Assert.IsTrue(testDto!.aDictionaryWithBooleans.IsSpecified);
        Assert.IsTrue(testDto.aDictionaryWithBooleans.IsNull);
    }

    [TestMethod]
    public void Empty_dictionary_should_give_the_zero_number_of_items()
    {
        //Arrange
        var dto = "{\"aDictionaryWithBooleans\":{}}";

        //Act
        var testDto = dto.Parse<TestDto>();

        //Assert
        Assert.IsTrue(testDto!.aDictionaryWithBooleans.IsSpecified);
        Assert.IsFalse(testDto.aDictionaryWithBooleans.IsNull);
        Assert.AreEqual(0, testDto.aDictionaryWithBooleans.Value!.Count());
    }

    [TestMethod]
    public void Filled_object_dictionary_with_null_value()
    {
        //Arrange
        var dto = "{\"aDictionaryWithBooleans\":[{\"a\":null}]}";

        //Act
        var testDto = dto.Parse<TestDto>();
        var a = testDto!.aDictionaryWithBooleans.Value!.ToArray();

        //Assert
        Assert.IsTrue(testDto!.aDictionaryWithBooleans.IsSpecified);
        Assert.IsFalse(testDto.aDictionaryWithBooleans.IsNull);
        Assert.IsNull(a[0].Value);
        Assert.AreEqual(1, a.Length);
    }

    [TestMethod]
    public void Filled_dictionary_should_give_back_that_dictionary_value()
    {
        //Arrange
        var dto = "{\"aDictionaryWithBooleans\":[{\"a\":null},{\"b\":false}]}";

        //Act
        var testDto = dto.Parse<TestDto>();
        var a = testDto!.aDictionaryWithBooleans.Value!.ToArray();

        //Assert
        Assert.IsTrue(testDto!.aDictionaryWithBooleans.IsSpecified);
        Assert.IsFalse(testDto.aDictionaryWithBooleans.IsNull);
        Assert.AreEqual("a", a[0].Key);
        Assert.AreEqual("b", a[1].Key);
        Assert.IsNull(a[0].Value);
        Assert.IsNotNull(a[1].Value);
        Assert.IsFalse(a[1].Value);
        Assert.AreEqual(2, a.Length);
    }
}