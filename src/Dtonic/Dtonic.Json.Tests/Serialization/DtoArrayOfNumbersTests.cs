using Dtonic.Dto;
using Dtonic.Dto.Extensions;

namespace Serialization;

[TestClass]
public class DtoArrayOfNumbersTests
{
    [TestMethod]
    public void Empty_should_return_Empty_array()
    {
        //Arrange
        var dtoArray = new DtoArrayOfNumbers([]);

        //Act
        var s = dtoArray.StringifyWithKey();

        //Assert
        Assert.AreEqual("\"dtoArray\":[]", s);
    }

    [TestMethod]
    public void Null_should_return_null_value()
    {
        //Arrange
        var dtoArray = new DtoArrayOfNumbers(null);

        //Act
        var s = dtoArray.StringifyWithKey();

        //Assert
        Assert.AreEqual("\"dtoArray\":null", s);
    }

    [TestMethod]
    public void Two_Int_values_should_return_Int_values_array()
    {
        //Arrange
        var dtoArray = new DtoArrayOfNumbers([1, 2]);

        //Act
        var s = dtoArray.StringifyWithKey();

        //Assert
        Assert.AreEqual("\"dtoArray\":[1,2]", s);
    }

    [TestMethod]
    public void Two_decimal_values_should_return_decimal_values_array()
    {
        //Arrange
        var dtoArray = new DtoArrayOfNumbers([1.1m, 2.2m]);

        //Act
        var s = dtoArray.StringifyWithKey();

        //Assert
        Assert.AreEqual("\"dtoArray\":[1.1,2.2]", s);
    }

    [TestMethod]
    public void A_null_value_should_be_just_returned_in_this_array()
    {
        //Arrange
        var dtoArray = new DtoArrayOfNumbers([1, null]);

        //Act
        var s = dtoArray.StringifyWithKey();

        //Assert
        Assert.AreEqual("\"dtoArray\":[1,null]", s);
    }
}
