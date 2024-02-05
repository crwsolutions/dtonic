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
        var dto = "{\"aDictionaryWithObjects\":null}";

        //Act
        var testDto = dto.Parse<TestDto>();

        //Assert
        Assert.IsTrue(testDto!.aDictionaryWithObjects.IsSpecified);
        Assert.IsTrue(testDto.aDictionaryWithObjects.IsNull);
    }

    [TestMethod]
    public void Empty_array_should_give_the_zero_number_of_items()
    {
        //Arrange
        var dto = "{\"aDictionaryWithObjects\":{}}";

        //Act
        var testDto = dto.Parse<TestDto>();

        //Assert
        Assert.IsTrue(testDto!.aDictionaryWithObjects.IsSpecified);
        Assert.IsFalse(testDto.aDictionaryWithObjects.IsNull);
        Assert.AreEqual(0, testDto.aDictionaryWithObjects.Value!.Count());
    }

    [TestMethod]
    public void Filled_object_dictionary_with_null_value()
    {
        //Arrange
        var dto = "{\"aDictionaryWithObjects\":[{\"a\":null}]}";

        //Act
        var testDto = dto.Parse<TestDto>();
        var a = testDto!.aDictionaryWithObjects.Value!.ToArray();

        //Assert
        Assert.IsTrue(testDto!.aDictionaryWithObjects.IsSpecified);
        Assert.IsFalse(testDto.aDictionaryWithObjects.IsNull);
        Assert.IsNull(a[0].Value);
        Assert.AreEqual(1, a.Length);
    }

    [TestMethod]
    public void Filled_object_dictionary_with_empty_value()
    {
        //Arrange
        var dto = "{\"aDictionaryWithObjects\":[{\"a\":{}}]}";

        //Act
        var testDto = dto.Parse<TestDto>();
        var a = testDto!.aDictionaryWithObjects.Value!.ToArray();

        //Assert
        Assert.IsTrue(testDto!.aDictionaryWithObjects.IsSpecified);
        Assert.IsFalse(testDto.aDictionaryWithObjects.IsNull);
        Assert.IsNotNull(a[0].Value);
        Assert.AreEqual(1, a.Length);
    }

    [TestMethod]
    public void Filled_string_array_should_give_back_that_array_value()
    {
        //Arrange
        var dto = "{\"aDictionaryWithObjects\":[{\"a\":null},{\"b\":{\"aString\":\"bob\"}}]}";

        //Act
        var testDto = dto.Parse<TestDto>();
        var a = testDto!.aDictionaryWithObjects.Value!.ToArray();

        //Assert
        Assert.IsTrue(testDto!.aDictionaryWithObjects.IsSpecified);
        Assert.IsFalse(testDto.aDictionaryWithObjects.IsNull);
        Assert.AreEqual("a", a[0].Key);
        Assert.AreEqual("b", a[1].Key);
        Assert.IsNull(a[0].Value);
        Assert.IsNotNull(a[1].Value);
        Assert.AreEqual("bob", a[1].Value!.aString.Value);
        Assert.AreEqual(2, a.Length);
    }
}