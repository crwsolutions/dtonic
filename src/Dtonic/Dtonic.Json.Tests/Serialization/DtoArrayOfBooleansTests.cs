using Dtonic.Dto;
using Dtonic.Dto.Extensions;

namespace Serialization;

[TestClass]
public class DtoArrayOfBooleansTests
{
    [TestMethod]
    public void Empty_should_return_Empty_array()
    {
        //Arrange
        var dtoArray = new DtoArrayOfBooleans([]);

        //Act
        var s = dtoArray.StringifyWithKey();

        //Assert
        Assert.AreEqual("\"dtoArray\":[]", s);
    }

    [TestMethod]
    public void Null_should_return_null_value()
    {
        //Arrange
        var dtoArray = new DtoArrayOfBooleans(null);

        //Act
        var s = dtoArray.StringifyWithKey();

        //Assert
        Assert.AreEqual("\"dtoArray\":null", s);
    }

    [TestMethod]
    public void Two_bool_values_should_return_these_values_array()
    {
        //Arrange
        var dtoArray = new DtoArrayOfBooleans([true, false]);

        //Act
        var s = dtoArray.StringifyWithKey();

        //Assert
        Assert.AreEqual("\"dtoArray\":[true,false]", s);
    }

    [TestMethod]
    public void A_null_value_should_be_just_returned_in_this_array()
    {
        //Arrange
        var dtoArray = new DtoArrayOfBooleans([false, null]);

        //Act
        var s = dtoArray.StringifyWithKey();

        //Assert
        Assert.AreEqual("\"dtoArray\":[false,null]", s);
    }
}