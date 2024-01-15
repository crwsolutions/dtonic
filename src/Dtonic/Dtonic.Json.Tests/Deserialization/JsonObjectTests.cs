using Dtonic.Json.Extensions;
using TestClasses;

namespace Deserialization;
[TestClass]
public class JsonObjectTests
{
    [TestMethod]
    public void Filled_json_object_should_give_filled_dto()
    {
        //Arrange
        var json = "{\"street\":\"teststreet\"}";

        //Act
        var testDto = json.Parse<TestDto>();

        //Assert
        Assert.IsTrue(testDto.street.IsSet);
        Assert.IsFalse(testDto.street.IsNull);
        Assert.AreEqual("teststreet", testDto.street.Value);
    }

    [TestMethod]
    public void Empty_json_object_should_give_unspecified_member()
    {
        //Arrange
        var json = "{}";

        //Act
        var testDto = json.Parse<TestDto>();

        //Assert
        Assert.IsFalse(testDto.street.IsSet);
        Assert.IsTrue(testDto.street.IsNull);
    }
}
