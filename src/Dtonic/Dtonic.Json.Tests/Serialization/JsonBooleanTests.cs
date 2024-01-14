using Dtonic.Json;
using Dtonic.Json.Extensions;

namespace Serialization;

[TestClass]
public class JsonBooleanTests
{
    [TestMethod]
    public void Unspecified_should_return_empty_string()
    {
        //Arrange
        var jsonBoolean = JsonBoolean.Unspecified;

        //Act
        var s = jsonBoolean.ToJsonString();

        //Assert
        Assert.AreEqual(string.Empty, s);
    }

    [TestMethod]
    public void Null_should_return_null_value()
    {
        //Arrange
        var jsonBoolean = new JsonBoolean(null);

        //Act
        var s = jsonBoolean.ToJsonString();

        //Assert
        Assert.AreEqual("\"jsonBoolean\":null", s);
    }

    [TestMethod]
    public void True_return_True()
    {
        //Arrange
        var jsonBoolean = new JsonBoolean(true);

        //Act
        var s = jsonBoolean.ToJsonString();

        //Assert
        Assert.AreEqual("\"jsonBoolean\":true", s);
    }

    [TestMethod]
    public void False_should_return_False()
    {
        //Arrange
        var jsonBoolean = new JsonBoolean(false);

        //Act
        var s = jsonBoolean.ToJsonString();

        //Assert
        Assert.AreEqual("\"jsonBoolean\":false", s);
    }
}