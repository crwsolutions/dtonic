using Dtonic.Dto;
using Dtonic.Dto.Extensions;

namespace Serialization;

[TestClass]
public class DtoNumberTests
{
    [TestMethod]
    public void Unspecified_should_return_empty_string()
    {
        //Arrange
        var dtoNumber = DtoNumber.Unspecified;

        //Act
        var s = dtoNumber.StringifyWithKey();

        //Assert
        Assert.AreEqual(string.Empty, s);
    }

    [TestMethod]
    public void Null_should_return_null_value()
    {
        //Arrange
        var dtoNumber = new DtoNumber(null);

        //Act
        var s = dtoNumber.StringifyWithKey();

        //Assert
        Assert.AreEqual("\"dtoNumber\":null", s);
    }

    [TestMethod]
    public void Zero_should_return_Zero()
    {
        //Arrange
        var dtoNumber = new DtoNumber(0);

        //Act
        var s = dtoNumber.StringifyWithKey();

        //Assert
        Assert.AreEqual("\"dtoNumber\":0", s);
    }

    [TestMethod]
    public void One_should_return_One()
    {
        //Arrange
        var dtoNumber = new DtoNumber(1);

        //Act
        var s = dtoNumber.StringifyWithKey();

        //Assert
        Assert.AreEqual("\"dtoNumber\":1", s);
    }

    [TestMethod]
    public void MinusOne_should_return_MinusOne()
    {
        //Arrange
        var dtoNumber = new DtoNumber(-1);

        //Act
        var s = dtoNumber.StringifyWithKey();

        //Assert
        Assert.AreEqual("\"dtoNumber\":-1", s);
    }

    [TestMethod]
    public void Fraction_should_return_fraction()
    {
        //Arrange
        var dtoNumber = new DtoNumber(1.12345m);

        //Act
        var s = dtoNumber.StringifyWithKey();

        //Assert
        Assert.AreEqual("\"dtoNumber\":1.12345", s);
    }
}