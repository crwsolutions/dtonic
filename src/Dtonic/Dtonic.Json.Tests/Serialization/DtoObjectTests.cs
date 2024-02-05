using Dtonic.Dto;
using Dtonic.Dto.Extensions;
using TestClasses;

namespace Serialization;

[TestClass]
public class DtoObjectTests
{
    [TestMethod]
    public void Unspecified_should_return_empty_string()
    {
        //Arrange
        var dtoObject = DtoObject<TestDto>.Unspecified;

        //Act
        var s = dtoObject.StringifyWithKey();

        //Assert
        Assert.AreEqual(string.Empty, s);
    }

    [TestMethod]
    public void Null_should_return_null_value()
    {
        //Arrange
        var dtoObject = new DtoObject<TestDto>(null);

        //Act
        var s = dtoObject.StringifyWithKey();

        //Assert
        Assert.AreEqual("\"dtoObject\":null", s);
    }

    [TestMethod]
    public void DtoObject_should_return_object()
    {
        //Arrange
        var dtoObject = new DtoObject<TestDto>(new TestDto { aString = "teststreet" });

        //Act
        var s = dtoObject.StringifyWithKey();

        //Assert
        Assert.AreEqual("\"dtoObject\":{\"aString\":\"teststreet\"}", s);
    }
}