using Dtonic.Json;
using Dtonic.Json.Extensions;

namespace Serialization;

[TestClass]
public class JsonStringTests
{
    [TestMethod]
    public void Unspecified_should_return_empty_string()
    {
        //Arrange
        var jsonString = JsonString.Unspecified;

        //Act
        var s = jsonString.StringifyWithKey();

        //Assert
        Assert.AreEqual(string.Empty, s);
    }

    [TestMethod]
    public void Null_should_return_null_value()
    {
        //Arrange
        var jsonString = new JsonString(null);

        //Act
        var s = jsonString.StringifyWithKey();

        //Assert
        Assert.AreEqual("\"jsonString\":null", s);
    }

    [TestMethod]
    public void Empty_return_Empty()
    {
        //Arrange
        var jsonString = new JsonString("");

        //Act
        var s = jsonString.StringifyWithKey();

        //Assert
        Assert.AreEqual("\"jsonString\":\"\"", s);
    }

    [TestMethod]
    public void Spaces_return_Spaces()
    {
        //Arrange
        var jsonString = new JsonString("  ");

        //Act
        var s = jsonString.StringifyWithKey();

        //Assert
        Assert.AreEqual("\"jsonString\":\"  \"", s);
    }

    [TestMethod]
    public void Test_string_return_test_string()
    {
        //Arrange
        var jsonString = new JsonString("  test  ");

        //Act
        var s = jsonString.StringifyWithKey();

        //Assert
        Assert.AreEqual("\"jsonString\":\"  test  \"", s);
    }
}