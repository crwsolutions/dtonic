using Dtonic.Dto.Extensions;
using TestClasses;

namespace Deserialization;

[TestClass]
public class DtoDictionaryWithArrayOfObjectsTests
{

    [TestMethod]
    public void Unspecified_value_should_give_isset_is_false()
    {
        //Arrange
        var dto = "{}";

        //Act
        var testDto = dto.Parse<TestDto>();

        //Assert
        Assert.IsFalse(testDto!.aDictionaryWithArrayOfObjects.IsSpecified);
        Assert.IsTrue(testDto.aDictionaryWithArrayOfObjects.IsNull);
    }

    [TestMethod]
    public void Null_value_should_give_null()
    {
        //Arrange
        var dto = "{\"aDictionaryWithArrayOfObjects\":null}";

        //Act
        var testDto = dto.Parse<TestDto>();

        //Assert
        Assert.IsTrue(testDto!.aDictionaryWithArrayOfObjects.IsSpecified);
        Assert.IsTrue(testDto.aDictionaryWithArrayOfObjects.IsNull);
    }

    [TestMethod]
    public void Empty_dictionary_should_give_the_zero_number_of_items()
    {
        //Arrange
        var dto = "{\"aDictionaryWithArrayOfObjects\":{}}";

        //Act
        var testDto = dto.Parse<TestDto>();

        //Assert
        Assert.IsTrue(testDto!.aDictionaryWithArrayOfObjects.IsSpecified);
        Assert.IsFalse(testDto.aDictionaryWithArrayOfObjects.IsNull);
        Assert.AreEqual(0, testDto.aDictionaryWithArrayOfObjects.Value!.Count);
    }

    [TestMethod]
    public void Filled_object_dictionary_with_null_value()
    {
        //Arrange
        var dto = "{\"aDictionaryWithArrayOfObjects\":[{\"a\":null}]}";

        //Act
        var testDto = dto.Parse<TestDto>();
        var a = testDto!.aDictionaryWithArrayOfObjects.Value!.ToArray();

        //Assert
        Assert.IsTrue(testDto!.aDictionaryWithArrayOfObjects.IsSpecified);
        Assert.IsFalse(testDto.aDictionaryWithArrayOfObjects.IsNull);
        Assert.IsNull(a[0].Value);
        Assert.AreEqual(1, a.Length);
    }

    [TestMethod]
    public void Filled_object_dictionary_with_empty_value()
    {
        //Arrange
        var dto = "{\"aDictionaryWithArrayOfObjects\":[{\"a\":[]}]}";

        //Act
        var testDto = dto.Parse<TestDto>();
        var a = testDto!.aDictionaryWithArrayOfObjects.Value!.ToArray();

        //Assert
        Assert.IsTrue(testDto!.aDictionaryWithArrayOfObjects.IsSpecified);
        Assert.IsFalse(testDto.aDictionaryWithArrayOfObjects.IsNull);
        Assert.AreEqual(1, a.Length);
        Assert.AreEqual(0, a[0].Value!.Count());
    }

    [TestMethod]
    public void Filled_dictionary_should_give_back_that_dictionary_value()
    {
        //Arrange
        var dto = "{\"aDictionaryWithArrayOfObjects\":[{\"a\":null},{\"b\":[{\"aBoolean\":false},{\"aBoolean\":true},{\"aBoolean\":false},null]}]}";

        //Act
        var testDto = dto.Parse<TestDto>();
        var a = testDto!.aDictionaryWithArrayOfObjects.Value!.ToArray();
        var b = a[1].Value!.ToArray();

        //Assert
        Assert.IsTrue(testDto!.aDictionaryWithArrayOfObjects.IsSpecified);
        Assert.IsFalse(testDto.aDictionaryWithArrayOfObjects.IsNull);
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