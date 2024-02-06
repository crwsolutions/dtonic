using Dtonic.Dto.Extensions;
using TestClasses;

namespace Deserialization;

[TestClass]
public class DtoDictionaryWithArrayofBooleansTests
{

    [TestMethod]
    public void Unspecified_value_should_give_isset_is_false()
    {
        //Arrange
        var dto = "{}";

        //Act
        var testDto = dto.Parse<TestDto>();

        //Assert
        Assert.IsFalse(testDto!.aDictionaryWithArrayofBooleans.IsSpecified);
        Assert.IsTrue(testDto.aDictionaryWithArrayofBooleans.IsNull);
    }

    [TestMethod]
    public void Null_value_should_give_null()
    {
        //Arrange
        var dto = "{\"aDictionaryWithArrayofBooleans\":null}";

        //Act
        var testDto = dto.Parse<TestDto>();

        //Assert
        Assert.IsTrue(testDto!.aDictionaryWithArrayofBooleans.IsSpecified);
        Assert.IsTrue(testDto.aDictionaryWithArrayofBooleans.IsNull);
    }

    [TestMethod]
    public void Empty_dictionary_should_give_the_zero_number_of_items()
    {
        //Arrange
        var dto = "{\"aDictionaryWithArrayofBooleans\":{}}";

        //Act
        var testDto = dto.Parse<TestDto>();

        //Assert
        Assert.IsTrue(testDto!.aDictionaryWithArrayofBooleans.IsSpecified);
        Assert.IsFalse(testDto.aDictionaryWithArrayofBooleans.IsNull);
        Assert.AreEqual(0, testDto.aDictionaryWithArrayofBooleans.Value!.Count());
    }

    [TestMethod]
    public void Filled_object_dictionary_with_null_value()
    {
        //Arrange
        var dto = "{\"aDictionaryWithArrayofBooleans\":[{\"a\":null}]}";

        //Act
        var testDto = dto.Parse<TestDto>();
        var a = testDto!.aDictionaryWithArrayofBooleans.Value!.ToArray();

        //Assert
        Assert.IsTrue(testDto!.aDictionaryWithArrayofBooleans.IsSpecified);
        Assert.IsFalse(testDto.aDictionaryWithArrayofBooleans.IsNull);
        Assert.IsNull(a[0].Value);
        Assert.AreEqual(1, a.Length);
    }

    [TestMethod]
    public void Filled_object_dictionary_with_empty_value()
    {
        //Arrange
        var dto = "{\"aDictionaryWithArrayofBooleans\":[{\"a\":[]}]}";

        //Act
        var testDto = dto.Parse<TestDto>();
        var a = testDto!.aDictionaryWithArrayofBooleans.Value!.ToArray();

        //Assert
        Assert.IsTrue(testDto!.aDictionaryWithArrayofBooleans.IsSpecified);
        Assert.IsFalse(testDto.aDictionaryWithArrayofBooleans.IsNull);
        Assert.AreEqual(1, a.Length);
        Assert.AreEqual(0, a[0].Value!.Count());
    }

    [TestMethod]
    public void Filled_dictionary_should_give_back_that_dictionary_value()
    {
        //Arrange
        var dto = "{\"aDictionaryWithArrayofBooleans\":[{\"a\":null},{\"b\":[false,true,false,null]}]}";

        //Act
        var testDto = dto.Parse<TestDto>();
        var a = testDto!.aDictionaryWithArrayofBooleans.Value!.ToArray();
        var b = a[1].Value!.ToArray();

        //Assert
        Assert.IsTrue(testDto!.aDictionaryWithArrayofBooleans.IsSpecified);
        Assert.IsFalse(testDto.aDictionaryWithArrayofBooleans.IsNull);
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