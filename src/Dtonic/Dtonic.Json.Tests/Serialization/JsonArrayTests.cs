using Dtonic.Json;
using Dtonic.Json.Extensions;

namespace Serialization;

[TestClass]
public class JsonArrayTests
{
    [TestMethod]
    public void Unspecified_should_return_empty_string()
    {
        //Arrange
        var jsonArray = JsonArray<int>.Unspecified;

        //Act
        var s = jsonArray.ToJsonString();

        //Assert
        Assert.AreEqual(string.Empty, s);
    }

    [TestMethod]
    public void Null_should_return_null_value()
    {
        //Arrange
        var jsonArray = new JsonArray<object>(null);

        //Act
        var s = jsonArray.ToJsonString();

        //Assert
        Assert.AreEqual("\"jsonArray\":null", s);
    }

    [TestMethod]
    public void Empty_should_return_Empty_array()
    {
        //Arrange
        var jsonArray = new JsonArray<object>(Array.Empty<object>());

        //Act
        var s = jsonArray.ToJsonString();

        //Assert
        Assert.AreEqual("\"jsonArray\":[]", s);
    }

    [TestMethod]
    public void Two_Int_values_should_return_Int_values_array()
    {
        //Arrange
        var jsonArray = new JsonArray<int>([1, 2]);

        //Act
        var s = jsonArray.ToJsonString();

        //Assert
        Assert.AreEqual("\"jsonArray\":[1,2]", s);
    }

    [TestMethod]
    public void Two_decimal_values_should_return_decimal_values_array()
    {
        //Arrange
        var jsonArray = new JsonArray<decimal>([1.1m, 2.2m]);

        //Act
        var s = jsonArray.ToJsonString();

        //Assert
        Assert.AreEqual("\"jsonArray\":[1.1,2.2]", s);
    }

    [TestMethod]
    public void Two_float_values_should_return_float_values_array()
    {
        //Arrange
        var jsonArray = new JsonArray<float>([1.1f, 2.2f]);

        //Act
        var s = jsonArray.ToJsonString();

        //Assert
        Assert.AreEqual("\"jsonArray\":[1.1,2.2]", s);
    }

    [TestMethod]
    public void Two_double_values_should_return_double_values_array()
    {
        //Arrange
        var jsonArray = new JsonArray<double>([1.1, 2.2]);

        //Act
        var s = jsonArray.ToJsonString();

        //Assert
        Assert.AreEqual("\"jsonArray\":[1.1,2.2]", s);
    }

    [TestMethod]
    public void Two_String_values_should_return_String_values_array()
    {
        //Arrange
        var jsonArray = new JsonArray<string>(["a", "b"]);

        //Act
        var s = jsonArray.ToJsonString();

        //Assert
        Assert.AreEqual("\"jsonArray\":[\"a\",\"b\"]", s);
    }
}