using Dtonic.Dto;
using Dtonic.Dto.Extensions;

namespace Serialization;

[TestClass]
public class DtoStringTests
{
    [TestMethod]
    public void Unspecified_should_return_empty_string()
    {
        //Arrange
        var dtoString = DtoString.Unspecified;

        //Act
        var s = dtoString.StringifyWithKey();

        //Assert
        Assert.AreEqual(string.Empty, s);
    }

    [TestMethod]
    public void Null_should_return_null_value()
    {
        //Arrange
        var dtoString = new DtoString(null);

        //Act
        var s = dtoString.StringifyWithKey();

        //Assert
        Assert.AreEqual("\"dtoString\":null", s);
    }

    [TestMethod]
    public void Empty_return_Empty()
    {
        //Arrange
        var dtoString = new DtoString("");

        //Act
        var s = dtoString.StringifyWithKey();

        //Assert
        Assert.AreEqual("\"dtoString\":\"\"", s);
    }

    [TestMethod]
    public void Spaces_return_Spaces()
    {
        //Arrange
        var dtoString = new DtoString("  ");

        //Act
        var s = dtoString.StringifyWithKey();

        //Assert
        Assert.AreEqual("\"dtoString\":\"  \"", s);
    }

    [TestMethod]
    public void Test_string_return_test_string()
    {
        //Arrange
        var dtoString = new DtoString("  test  ");

        //Act
        var s = dtoString.StringifyWithKey();

        //Assert
        Assert.AreEqual("\"dtoString\":\"  test  \"", s);
    }
}