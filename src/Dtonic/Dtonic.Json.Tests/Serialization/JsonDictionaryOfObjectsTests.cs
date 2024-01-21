using Dtonic.Json;
using Dtonic.Json.Extensions;
using TestClasses;

namespace Serialization;

[TestClass]
public class JsonDictionaryOfObjectsTests
{
    [TestMethod]
    public void Unspecified_should_return_empty_string()
    {
        //Arrange
        var jsonDictionary = JsonDictionaryOfObjects<TestDto>.Unspecified;

        //Act
        var s = jsonDictionary.StringifyWithKey();

        //Assert
        Assert.AreEqual(string.Empty, s);
    }

    [TestMethod]
    public void Null_should_return_null_value()
    {
        //Arrange
        var jsonDictionary = new JsonDictionaryOfObjects<TestDto>(null);

        //Act
        var s = jsonDictionary.StringifyWithKey();

        //Assert
        Assert.AreEqual("\"jsonDictionary\":null", s);
    }

    [TestMethod]
    public void JsonDictionary_should_return_object()
    {
        //Arrange
        var dict = new Dictionary<string, TestDto?>() { { "one", new TestDto() }, { "two", new TestDto() } };
        var jsonDictionary = new JsonDictionaryOfObjects<TestDto>(dict);

        //Act
        var s = jsonDictionary.StringifyWithKey();

        //Assert
        Assert.AreEqual("\"jsonDictionary\":[{\"one\":{}},{\"two\":{}}]", s);
    }

    [TestMethod]
    public void JsonDictionary_with_null_value_row_should_return_object()
    {
        //Arrange
        var dict = new Dictionary<string, TestDto?>() { { "one", new TestDto() }, { "two", null } };
        var jsonDictionary = new JsonDictionaryOfObjects<TestDto>(dict);

        //Act
        var s = jsonDictionary.StringifyWithKey();

        //Assert
        Assert.AreEqual("\"jsonDictionary\":[{\"one\":{}},{\"two\":null}]", s);
    }
}