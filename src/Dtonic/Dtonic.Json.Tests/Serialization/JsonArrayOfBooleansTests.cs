using Dtonic.Json;
using Dtonic.Json.Extensions;

namespace Serialization;

[TestClass]
public class JsonArrayOfBooleansTests
{
    [TestMethod]
    public void Empty_should_return_Empty_array()
    {
        //Arrange
        var jsonArray = new JsonArrayOfBooleans([]);

        //Act
        var s = jsonArray.Stringify();

        //Assert
        Assert.AreEqual("\"jsonArray\":[]", s);
    }

    [TestMethod]
    public void Null_should_return_null_value()
    {
        //Arrange
        var jsonArray = new JsonArrayOfBooleans(null);

        //Act
        var s = jsonArray.Stringify();

        //Assert
        Assert.AreEqual("\"jsonArray\":null", s);
    }

    [TestMethod]
    public void Two_bool_values_should_return_these_values_array()
    {
        //Arrange
        var jsonArray = new JsonArrayOfBooleans([true, false]);

        //Act
        var s = jsonArray.Stringify();

        //Assert
        Assert.AreEqual("\"jsonArray\":[true,false]", s);
    }

    [TestMethod]
    public void A_null_value_should_be_just_returned_in_this_array()
    {
        //Arrange
        var jsonArray = new JsonArrayOfBooleans([false, null]);

        //Act
        var s = jsonArray.Stringify();

        //Assert
        Assert.AreEqual("\"jsonArray\":[false,null]", s);
    }
}