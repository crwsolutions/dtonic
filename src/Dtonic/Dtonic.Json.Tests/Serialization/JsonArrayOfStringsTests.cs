using Dtonic.Json;
using Dtonic.Json.Extensions;
using TestClasses;

namespace Serialization;

[TestClass]
public class JsonArrayOfStringsTests
{

    [TestMethod]
    public void Empty_should_return_Empty_array()
    {
        //Arrange
        var jsonArray = new JsonArrayOfStrings([]);

        //Act
        var s = jsonArray.Stringify();

        //Assert
        Assert.AreEqual("\"jsonArray\":[]", s);
    }

    [TestMethod]
    public void Null_should_return_null_value()
    {
        //Arrange
        var jsonArray = new JsonArrayOfStrings(null);

        //Act
        var s = jsonArray.Stringify();

        //Assert
        Assert.AreEqual("\"jsonArray\":null", s);
    }

    [TestMethod]
    public void Two_String_values_should_return_String_values_array()
    {
        //Arrange
        var jsonArray = new JsonArrayOfStrings(["a", "b"]);

        //Act
        var s = jsonArray.Stringify();

        //Assert
        Assert.AreEqual("\"jsonArray\":[\"a\",\"b\"]", s);
    }

    [TestMethod]
    public void A_null_value_should_be_just_returned_in_this_array()
    {
        //Arrange
        var jsonArray = new JsonArrayOfStrings(["a", null]);

        //Act
        var s = jsonArray.Stringify();

        //Assert
        Assert.AreEqual("\"jsonArray\":[\"a\",null]", s);
    }
}