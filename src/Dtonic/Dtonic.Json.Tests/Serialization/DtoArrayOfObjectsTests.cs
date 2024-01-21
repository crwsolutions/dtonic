using Dtonic.Dto;
using Dtonic.Dto.Extensions;
using TestClasses;

namespace Serialization;

[TestClass]
public class DtoArrayOfObjectsTests
{
    [TestMethod]
    public void Unspecified_should_return_empty_string()
    {
        //Arrange
        var dtoArray = DtoArrayOfObjects<TestDto>.Unspecified;

        //Act
        var s = dtoArray.StringifyWithKey();

        //Assert
        Assert.AreEqual(string.Empty, s);
    }

    [TestMethod]
    public void Null_should_return_null_value()
    {
        //Arrange
        var dtoArray = new DtoArrayOfObjects<TestDto>(null);

        //Act
        var s = dtoArray.StringifyWithKey();

        //Assert
        Assert.AreEqual("\"dtoArray\":null", s);
    }

    [TestMethod]
    public void Empty_should_return_Empty_array()
    {
        //Arrange
        var dtoArray = new DtoArrayOfObjects<TestDto>(Array.Empty<TestDto>());

        //Act
        var s = dtoArray.StringifyWithKey();

        //Assert
        Assert.AreEqual("\"dtoArray\":[]", s);
    }
}
