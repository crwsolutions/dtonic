using Dtonic.Dto;

namespace Deconstruct;

[TestClass]
public class DtoStringTests
{
    [TestMethod]
    public void Unspecified_should_have_no_value()
    {
        //Arrange
        var (isSpecified, isNull, value) = DtoString.Unspecified;

        //Act

        //Assert
        Assert.IsFalse(isSpecified);
    }

    [TestMethod]
    public void Specified_null_should_have_null_value_in_3_tuple()
    {
        //Arrange
        DtoString dtoString = new DtoString(null);

        //Act
        var (isSpecified, isNull, value) = dtoString;

        //Assert
        Assert.IsTrue(isSpecified);
        Assert.IsTrue(isNull);
        Assert.IsNull(value);
    }

    [TestMethod]
    public void Specified_value_should_have_that_value_in_3_tuple()
    {
        DtoString dtoString = "";

        //Act
        var (isSpecified, isNull, value) = dtoString;

        //Assert
        Assert.IsTrue(isSpecified);
        Assert.IsFalse(isNull);
        Assert.AreEqual("", value);
    }

    [TestMethod]
    public void Specified_null_should_have_null_value_in_2_tuple()
    {
        //Arrange
        DtoString dtoString = new DtoString(null);

        //Act
        var (isSpecified, value) = dtoString;

        //Assert
        Assert.IsTrue(isSpecified);
        Assert.IsNull(value);
    }

    [TestMethod]
    public void Specified_value_should_have_that_value_in_2_tuple()
    {
        DtoString dtoString = "";

        //Act
        var (isSpecified, value) = dtoString;

        //Assert
        Assert.IsTrue(isSpecified);
        Assert.AreEqual("", value);
    }
}
