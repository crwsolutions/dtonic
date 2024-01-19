using Dtonic.Json;
using Dtonic.Json.Extensions;
using TestClasses;

namespace Serialization;

[TestClass]
public class JsonArrayOfObjectsTests
{
    [TestMethod]
    public void Unspecified_should_return_empty_string()
    {
        //Arrange
        var jsonArray = JsonArrayOfObjects<TestDto>.Unspecified;

        //Act
        var s = jsonArray.StringifyWithKey();

        //Assert
        Assert.AreEqual(string.Empty, s);
    }

    [TestMethod]
    public void Null_should_return_null_value()
    {
        //Arrange
        var jsonArray = new JsonArrayOfObjects<TestDto>(null);

        //Act
        var s = jsonArray.StringifyWithKey();

        //Assert
        Assert.AreEqual("\"jsonArray\":null", s);
    }

    [TestMethod]
    public void Empty_should_return_Empty_array()
    {
        //Arrange
        var jsonArray = new JsonArrayOfObjects<TestDto>(Array.Empty<TestDto>());

        //Act
        var s = jsonArray.StringifyWithKey();

        //Assert
        Assert.AreEqual("\"jsonArray\":[]", s);
    }
}
