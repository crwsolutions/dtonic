using Dtonic.Json.Extensions;
using TestClasses;

namespace Deserialization;
[TestClass]
public class JsonObjectTests
{
    [TestMethod]
    public void Filled_root_json_object_should_give_filled_dto()
    {
        //Arrange
        var json = "{\"street\":\"teststreet\"}";

        //Act
        var testDto = json.Parse<TestDto>();

        //Assert
        Assert.IsTrue(testDto!.street.IsSet);
        Assert.IsFalse(testDto.street.IsNull);
        Assert.AreEqual("teststreet", testDto.street.Value);
    }

    [TestMethod]
    public void Empty_root_json_object_should_give_unspecified_member()
    {
        //Arrange
        var json = "{}";

        //Act
        var testDto = json.Parse<TestDto>();

        //Assert
        Assert.IsFalse(testDto!.street.IsSet);
        Assert.IsTrue(testDto.street.IsNull);
    }

    [TestMethod]
    public void Null_root_should_give_null()
    {
        //Arrange
        var json = "null";

        //Act
        var testDto = json.Parse<TestDto>();

        //Assert
        Assert.IsNull(testDto);
    }

    [TestMethod]
    public void Filled_child_json_object_should_give_filled_dto()
    {
        //Arrange
        var json = "{\"childTestDto\":{\"street\":\"teststreet\"}}";

        //Act
        var testDto = json.Parse<TestDto>();

        //Assert
        Assert.IsTrue(testDto!.childTestDto.IsSet);
        Assert.IsFalse(testDto.childTestDto.IsNull);
        Assert.IsTrue(testDto.childTestDto.Value!.street.IsSet);
        Assert.IsFalse(testDto.childTestDto.Value.street.IsNull);
        Assert.AreEqual("teststreet", testDto.childTestDto.Value.street.Value);
    }

    [TestMethod]
    public void Empty_child_json_object_should_give_unspecified_member_on_that_child_object()
    {
        //Arrange
        var json = "{\"childTestDto\":{}}";

        //Act
        var testDto = json.Parse<TestDto>();

        //Assert
        Assert.IsTrue(testDto!.childTestDto.IsSet);
        Assert.IsFalse(testDto.childTestDto.IsNull);
        Assert.IsFalse(testDto.childTestDto.Value!.street.IsSet);
        Assert.IsTrue(testDto.childTestDto.Value.street.IsNull);
    }

    [TestMethod]
    public void Null_child_should_give_null()
    {
        //Arrange
        var json = "{\"childTestDto\":null}";

        //Act
        var testDto = json.Parse<TestDto>();

        //Assert
        Assert.IsTrue(testDto!.childTestDto.IsSet);
        Assert.IsTrue(testDto.childTestDto.IsNull);
    }
}
