using Dtonic.Dto.Extensions;
using TestClasses;

namespace Deserialization;

[TestClass]
public class DtoDictionaryWithArrayofObjectsTests
{

    [TestMethod]
    public void Unspecified_value_should_give_isset_is_false()
    {
        //Arrange
        var dto = "{}";

        //Act
        var testDto = dto.Parse<TestDto>();

        //Assert
        Assert.IsFalse(testDto!.aDictionaryWithArrayofObjects.IsSpecified);
        Assert.IsTrue(testDto.aDictionaryWithArrayofObjects.IsNull);
    }

    [TestMethod]
    public void Null_value_should_give_null()
    {
        //Arrange
        var dto = "{\"aDictionaryWithArrayofObjects\":null}";

        //Act
        var testDto = dto.Parse<TestDto>();

        //Assert
        Assert.IsTrue(testDto!.aDictionaryWithArrayofObjects.IsSpecified);
        Assert.IsTrue(testDto.aDictionaryWithArrayofObjects.IsNull);
    }

    [TestMethod]
    public void Empty_dictionary_should_give_the_zero_number_of_items()
    {
        //Arrange
        var dto = "{\"aDictionaryWithArrayofObjects\":{}}";

        //Act
        var testDto = dto.Parse<TestDto>();

        //Assert
        Assert.IsTrue(testDto!.aDictionaryWithArrayofObjects.IsSpecified);
        Assert.IsFalse(testDto.aDictionaryWithArrayofObjects.IsNull);
        Assert.AreEqual(0, testDto.aDictionaryWithArrayofObjects.Value!.Count);
    }

    [TestMethod]
    public void Filled_object_dictionary_with_null_value()
    {
        //Arrange
        var dto = "{\"aDictionaryWithArrayofObjects\":[{\"a\":null}]}";

        //Act
        var testDto = dto.Parse<TestDto>();
        var a = testDto!.aDictionaryWithArrayofObjects.Value!.ToArray();

        //Assert
        Assert.IsTrue(testDto!.aDictionaryWithArrayofObjects.IsSpecified);
        Assert.IsFalse(testDto.aDictionaryWithArrayofObjects.IsNull);
        Assert.IsNull(a[0].Value);
        Assert.AreEqual(1, a.Length);
    }

    [TestMethod]
    public void Filled_object_dictionary_with_empty_value()
    {
        //Arrange
        var dto = "{\"aDictionaryWithArrayofObjects\":[{\"a\":[]}]}";

        //Act
        var testDto = dto.Parse<TestDto>();
        var a = testDto!.aDictionaryWithArrayofObjects.Value!.ToArray();

        //Assert
        Assert.IsTrue(testDto!.aDictionaryWithArrayofObjects.IsSpecified);
        Assert.IsFalse(testDto.aDictionaryWithArrayofObjects.IsNull);
        Assert.AreEqual(1, a.Length);
        Assert.AreEqual(0, a[0].Value!.Count());
    }

    [TestMethod]
    public void Filled_dictionary_should_give_back_that_dictionary_value()
    {
        //Arrange
        var dto = "{\"aDictionaryWithArrayofObjects\":[{\"a\":null},{\"b\":[{\"aBoolean\":false},{\"aBoolean\":true},{\"aBoolean\":false},null]}]}";

        //Act
        var testDto = dto.Parse<TestDto>();
        var a = testDto!.aDictionaryWithArrayofObjects.Value!.ToArray();
        var b = a[1].Value!.ToArray();

        //Assert
        Assert.IsTrue(testDto!.aDictionaryWithArrayofObjects.IsSpecified);
        Assert.IsFalse(testDto.aDictionaryWithArrayofObjects.IsNull);
        Assert.AreEqual("a", a[0].Key);
        Assert.AreEqual("b", a[1].Key);
        Assert.IsNull(a[0].Value);
        Assert.IsNotNull(a[1].Value);
        Assert.IsFalse(b[0]!.aBoolean.Value);
        Assert.IsTrue(b[1]!.aBoolean.Value);
        Assert.IsFalse(b[2]!.aBoolean.Value);
        Assert.IsNull(b[3]);
        Assert.AreEqual(2, a.Length);
        Assert.AreEqual(4, b.Length);
    }
}