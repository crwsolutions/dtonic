using Dtonic.Json;
using Dtonic.Json.Extensions;

namespace Serialization;

[TestClass]
public class JsonNumberTests
{
    [TestMethod]
    public void Unspecified_should_return_empty_string()
    {
        //Arrange
        var jsonNumber = JsonNumber.Unspecified;

        //Act
        var s = jsonNumber.StringifyWithKey();

        //Assert
        Assert.AreEqual(string.Empty, s);
    }

    [TestMethod]
    public void Null_should_return_null_value()
    {
        //Arrange
        var jsonNumber = new JsonNumber(null);

        //Act
        var s = jsonNumber.StringifyWithKey();

        //Assert
        Assert.AreEqual("\"jsonNumber\":null", s);
    }

    [TestMethod]
    public void Zero_should_return_Zero()
    {
        //Arrange
        var jsonNumber = new JsonNumber(0);

        //Act
        var s = jsonNumber.StringifyWithKey();

        //Assert
        Assert.AreEqual("\"jsonNumber\":0", s);
    }

    [TestMethod]
    public void One_should_return_One()
    {
        //Arrange
        var jsonNumber = new JsonNumber(1);

        //Act
        var s = jsonNumber.StringifyWithKey();

        //Assert
        Assert.AreEqual("\"jsonNumber\":1", s);
    }

    [TestMethod]
    public void MinusOne_should_return_MinusOne()
    {
        //Arrange
        var jsonNumber = new JsonNumber(-1);

        //Act
        var s = jsonNumber.StringifyWithKey();

        //Assert
        Assert.AreEqual("\"jsonNumber\":-1", s);
    }

    [TestMethod]
    public void Fraction_should_return_fraction()
    {
        //Arrange
        var jsonNumber = new JsonNumber(1.12345m);

        //Act
        var s = jsonNumber.StringifyWithKey();

        //Assert
        Assert.AreEqual("\"jsonNumber\":1.12345", s);
    }
}