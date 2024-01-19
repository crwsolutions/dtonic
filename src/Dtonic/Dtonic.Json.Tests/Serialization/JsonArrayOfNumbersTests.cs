using Dtonic.Json;
using Dtonic.Json.Extensions;

namespace Serialization;

[TestClass]
public class JsonArrayOfNumbersTests
{
    [TestMethod]
    public void Empty_should_return_Empty_array()
    {
        //Arrange
        var jsonArray = new JsonArrayOfNumbers([]);

        //Act
        var s = jsonArray.StringifyWithKey();

        //Assert
        Assert.AreEqual("\"jsonArray\":[]", s);
    }

    [TestMethod]
    public void Null_should_return_null_value()
    {
        //Arrange
        var jsonArray = new JsonArrayOfNumbers(null);

        //Act
        var s = jsonArray.StringifyWithKey();

        //Assert
        Assert.AreEqual("\"jsonArray\":null", s);
    }

    [TestMethod]
    public void Two_Int_values_should_return_Int_values_array()
    {
        //Arrange
        var jsonArray = new JsonArrayOfNumbers([1, 2]);

        //Act
        var s = jsonArray.StringifyWithKey();

        //Assert
        Assert.AreEqual("\"jsonArray\":[1,2]", s);
    }

    [TestMethod]
    public void Two_decimal_values_should_return_decimal_values_array()
    {
        //Arrange
        var jsonArray = new JsonArrayOfNumbers([1.1m, 2.2m]);

        //Act
        var s = jsonArray.StringifyWithKey();

        //Assert
        Assert.AreEqual("\"jsonArray\":[1.1,2.2]", s);
    }

    [TestMethod]
    public void A_null_value_should_be_just_returned_in_this_array()
    {
        //Arrange
        var jsonArray = new JsonArrayOfNumbers([1, null]);

        //Act
        var s = jsonArray.StringifyWithKey();

        //Assert
        Assert.AreEqual("\"jsonArray\":[1,null]", s);
    }
}
