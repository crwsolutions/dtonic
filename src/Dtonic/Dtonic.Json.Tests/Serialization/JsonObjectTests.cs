using Dtonic.Json;
using Dtonic.Json.Exceptions;
using Dtonic.Json.Extensions;
using TestClasses;

namespace Serialization;

[TestClass]
public class JsonObjectTests
{
    [TestMethod]
    public void Unspecified_should_return_empty_string()
    {
        //Arrange
        var jsonObject = JsonObject<object>.Unspecified;

        //Act
        var s = jsonObject.ToJsonString();

        //Assert
        Assert.AreEqual(string.Empty, s);
    }

    [TestMethod]
    public void Null_should_return_null_value()
    {
        //Arrange
        var jsonObject = new JsonObject<object>(null);

        //Act
        var s = jsonObject.ToJsonString();

        //Assert
        Assert.AreEqual("\"jsonObject\":null", s);
    }

    [TestMethod]
    public void JsonObject_should_return_object()
    {
        //Arrange
        var jsonObject = new JsonObject<TestDto>(new TestDto { street = "teststreet" });

        //Act
        var s = jsonObject.ToJsonString();

        //Assert
        Assert.AreEqual("\"jsonObject\":{\"street\":\"teststreet\"}", s);
    }

    [TestMethod]
    [ExpectedException(typeof(DoesNotImplementIJsonSerializableException))]
    public void Unsupported_type_should_throw_exception()
    {
        //Arrange
        var jsonObject = new JsonObject<object>(new object());

        //Act
        _ = jsonObject.ToJsonString();

        //Assert
        Assert.Fail();
    }
}