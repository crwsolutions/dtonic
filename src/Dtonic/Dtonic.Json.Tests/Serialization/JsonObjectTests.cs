using Dtonic.Json;
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
        var jsonObject = JsonObject<TestDto>.Unspecified;

        //Act
        var s = jsonObject.StringifyWithKey();

        //Assert
        Assert.AreEqual(string.Empty, s);
    }

    [TestMethod]
    public void Null_should_return_null_value()
    {
        //Arrange
        var jsonObject = new JsonObject<TestDto>(null);

        //Act
        var s = jsonObject.StringifyWithKey();

        //Assert
        Assert.AreEqual("\"jsonObject\":null", s);
    }

    [TestMethod]
    public void JsonObject_should_return_object()
    {
        //Arrange
        var jsonObject = new JsonObject<TestDto>(new TestDto { street = "teststreet" });

        //Act
        var s = jsonObject.StringifyWithKey();

        //Assert
        Assert.AreEqual("\"jsonObject\":{\"street\":\"teststreet\"}", s);
    }
}