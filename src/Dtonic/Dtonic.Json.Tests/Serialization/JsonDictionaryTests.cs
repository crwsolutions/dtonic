using Dtonic.Json;
using Dtonic.Json.Exceptions;
using Dtonic.Json.Extensions;
using TestClasses;

namespace Serialization;

[TestClass]
public class JsonDictionaryTests
{
    [TestMethod]
    public void Unspecified_should_return_empty_string()
    {
        //Arrange
        var jsonDictionary = JsonDictionary<object>.Unspecified;

        //Act
        var s = jsonDictionary.Stringify();

        //Assert
        Assert.AreEqual(string.Empty, s);
    }

    [TestMethod]
    public void Null_should_return_null_value()
    {
        //Arrange
        var jsonDictionary = new JsonDictionary<object>(null);

        //Act
        var s = jsonDictionary.Stringify();

        //Assert
        Assert.AreEqual("\"jsonDictionary\":null", s);
    }

    [TestMethod]
    public void JsonDictionary_should_return_object()
    {
        //Arrange
        var dict = new Dictionary<string, int>() { { "one", 1 }, { "two", 2} };
        var jsonDictionary = new JsonDictionary<int>(dict);

        //Act
        var s = jsonDictionary.Stringify();

        //Assert
        Assert.AreEqual("\"jsonDictionary\":[{\"one\":1},{\"two\":2}]", s);
    }

    [TestMethod]
    public void JsonDictionary_with_null_value_row_should_return_object()
    {
        //Arrange
        var dict = new Dictionary<string, string?>() { { "one", "1" }, { "two", null } };
        var jsonDictionary = new JsonDictionary<string?>(dict);

        //Act
        var s = jsonDictionary.Stringify();

        //Assert
        Assert.AreEqual("\"jsonDictionary\":[{\"one\":\"1\"},{\"two\":null}]", s);
    }

    [TestMethod]
    [ExpectedException(typeof(DoesNotImplementIJsonSerializableException))]
    public void Unsupported_type_should_throw_exception()
    {
        //Arrange
        var dict = new Dictionary<string, object>() { { "one", new object() } };
        var jsonDictionary = new JsonDictionary<object>(dict);

        //Act
        _ = jsonDictionary.Stringify();

        //Assert
        Assert.Fail();
    }
}