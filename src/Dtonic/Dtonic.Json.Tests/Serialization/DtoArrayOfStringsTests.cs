using Dtonic.Dto;
using Dtonic.Dto.Extensions;

namespace Serialization;

[TestClass]
public class DtoArrayOfStringsTests
{

    [TestMethod]
    public void Empty_should_return_Empty_array()
    {
        //Arrange
        var dtoArray = new DtoArrayOfStrings([]);

        //Act
        var s = dtoArray.StringifyWithKey();

        //Assert
        Assert.AreEqual("\"dtoArray\":[]", s);
    }

    [TestMethod]
    public void Null_should_return_null_value()
    {
        //Arrange
        var dtoArray = new DtoArrayOfStrings(null);

        //Act
        var s = dtoArray.StringifyWithKey();

        //Assert
        Assert.AreEqual("\"dtoArray\":null", s);
    }

    [TestMethod]
    public void Two_String_values_should_return_String_values_array()
    {
        //Arrange
        var dtoArray = new DtoArrayOfStrings(["a", "b"]);

        //Act
        var s = dtoArray.StringifyWithKey();

        //Assert
        Assert.AreEqual("\"dtoArray\":[\"a\",\"b\"]", s);
    }

    [TestMethod]
    public void A_null_value_should_be_just_returned_in_this_array()
    {
        //Arrange
        var dtoArray = new DtoArrayOfStrings(["a", null]);

        //Act
        var s = dtoArray.StringifyWithKey();

        //Assert
        Assert.AreEqual("\"dtoArray\":[\"a\",null]", s);
    }
}