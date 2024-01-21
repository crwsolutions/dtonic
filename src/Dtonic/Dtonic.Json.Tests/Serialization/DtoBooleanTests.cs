using Dtonic.Dto;
using Dtonic.Dto.Extensions;

namespace Serialization;

[TestClass]
public class DtoBooleanTests
{
    [TestMethod]
    public void Unspecified_should_return_empty_string()
    {
        //Arrange
        var dtoBoolean = DtoBoolean.Unspecified;

        //Act
        var s = dtoBoolean.StringifyWithKey();

        //Assert
        Assert.AreEqual(string.Empty, s);
    }

    [TestMethod]
    public void Null_should_return_null_value()
    {
        //Arrange
        var dtoBoolean = new DtoBoolean(null);

        //Act
        var s = dtoBoolean.StringifyWithKey();

        //Assert
        Assert.AreEqual("\"dtoBoolean\":null", s);
    }

    [TestMethod]
    public void True_return_True()
    {
        //Arrange
        var dtoBoolean = new DtoBoolean(true);

        //Act
        var s = dtoBoolean.StringifyWithKey();

        //Assert
        Assert.AreEqual("\"dtoBoolean\":true", s);
    }

    [TestMethod]
    public void False_should_return_False()
    {
        //Arrange
        var dtoBoolean = new DtoBoolean(false);

        //Act
        var s = dtoBoolean.StringifyWithKey();

        //Assert
        Assert.AreEqual("\"dtoBoolean\":false", s);
    }
}