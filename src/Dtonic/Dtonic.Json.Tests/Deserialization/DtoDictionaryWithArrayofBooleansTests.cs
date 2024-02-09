using Dtonic.Dto.Extensions;
using TestClasses;

namespace Deserialization;

[TestClass]
public class DtoDictionaryWithArrayOfBooleansTests
{

    [TestMethod]
    public void Unspecified_value_should_give_isset_is_false()
    {
        //Arrange
        var dto = "{}";

        //Act
        var testDto = dto.Parse<TestDto>();

        //Assert
        Assert.IsFalse(testDto!.aDictionaryWithArrayOfBooleans.IsSpecified);
        Assert.IsTrue(testDto.aDictionaryWithArrayOfBooleans.IsNull);
    }

    [TestMethod]
    public void Null_value_should_give_null()
    {
        //Arrange
        var dto = "{\"aDictionaryWithArrayOfBooleans\":null}";

        //Act
        var testDto = dto.Parse<TestDto>();

        //Assert
        Assert.IsTrue(testDto!.aDictionaryWithArrayOfBooleans.IsSpecified);
        Assert.IsTrue(testDto.aDictionaryWithArrayOfBooleans.IsNull);
    }

    [TestMethod]
    public void Empty_dictionary_should_give_the_zero_number_of_items()
    {
        //Arrange
        var dto = "{\"aDictionaryWithArrayOfBooleans\":{}}";

        //Act
        var testDto = dto.Parse<TestDto>();

        //Assert
        Assert.IsTrue(testDto!.aDictionaryWithArrayOfBooleans.IsSpecified);
        Assert.IsFalse(testDto.aDictionaryWithArrayOfBooleans.IsNull);
        Assert.AreEqual(0, testDto.aDictionaryWithArrayOfBooleans.Value!.Count);
    }

    [TestMethod]
    public void Filled_object_dictionary_with_null_value()
    {
        //Arrange
        var dto = "{\"aDictionaryWithArrayOfBooleans\":{\"a\":null}}";

        //Act
        var testDto = dto.Parse<TestDto>();
        var a = testDto!.aDictionaryWithArrayOfBooleans.Value!.ToArray();

        //Assert
        Assert.IsTrue(testDto!.aDictionaryWithArrayOfBooleans.IsSpecified);
        Assert.IsFalse(testDto.aDictionaryWithArrayOfBooleans.IsNull);
        Assert.IsNull(a[0].Value);
        Assert.AreEqual(1, a.Length);
    }

    [TestMethod]
    public void Filled_object_dictionary_with_empty_value()
    {
        //Arrange
        var dto = "{\"aDictionaryWithArrayOfBooleans\":{\"a\":[]}}";

        //Act
        var testDto = dto.Parse<TestDto>();
        var a = testDto!.aDictionaryWithArrayOfBooleans.Value!.ToArray();

        //Assert
        Assert.IsTrue(testDto!.aDictionaryWithArrayOfBooleans.IsSpecified);
        Assert.IsFalse(testDto.aDictionaryWithArrayOfBooleans.IsNull);
        Assert.AreEqual(1, a.Length);
        Assert.AreEqual(0, a[0].Value!.Count());
    }

    [TestMethod]
    public void Filled_dictionary_should_give_back_that_dictionary_value()
    {
        //Arrange
        var dto = "{\"aDictionaryWithArrayOfBooleans\":{\"a\":null,\"b\":[false,true,false,null]}}";

        //Act
        var testDto = dto.Parse<TestDto>();
        var a = testDto!.aDictionaryWithArrayOfBooleans.Value!.ToArray();
        var b = a[1].Value!.ToArray();

        //Assert
        Assert.IsTrue(testDto!.aDictionaryWithArrayOfBooleans.IsSpecified);
        Assert.IsFalse(testDto.aDictionaryWithArrayOfBooleans.IsNull);
        Assert.AreEqual("a", a[0].Key);
        Assert.AreEqual("b", a[1].Key);
        Assert.IsNull(a[0].Value);
        Assert.IsNotNull(a[1].Value);
        Assert.IsFalse(b[0]);
        Assert.IsTrue(b[1]);
        Assert.IsFalse(b[2]);
        Assert.IsNull(b[3]);
        Assert.AreEqual(2, a.Length);
    }
}