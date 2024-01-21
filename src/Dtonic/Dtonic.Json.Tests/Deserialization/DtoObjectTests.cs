using Dtonic.Dto.Extensions;
using TestClasses;

namespace Deserialization;
[TestClass]
public class DtoObjectTests
{
    [TestMethod]
    public void Filled_root_dto_object_should_give_filled_dto()
    {
        //Arrange
        var dto = "{\"street\":\"teststreet\"}";

        //Act
        var testDto = dto.Parse<TestDto>();

        //Assert
        Assert.IsTrue(testDto!.street.IsSpecified);
        Assert.IsFalse(testDto.street.IsNull);
        Assert.AreEqual("teststreet", testDto.street.Value);
    }

    [TestMethod]
    public void Empty_root_dto_object_should_give_unspecified_member()
    {
        //Arrange
        var dto = "{}";

        //Act
        var testDto = dto.Parse<TestDto>();

        //Assert
        Assert.IsFalse(testDto!.street.IsSpecified);
        Assert.IsTrue(testDto.street.IsNull);
    }

    [TestMethod]
    public void Null_root_should_give_null()
    {
        //Arrange
        var dto = "null";

        //Act
        var testDto = dto.Parse<TestDto>();

        //Assert
        Assert.IsNull(testDto);
    }

    [TestMethod]
    public void Filled_child_dto_object_should_give_filled_dto()
    {
        //Arrange
        var dto = "{\"childTestDto\":{\"street\":\"teststreet\"}}";

        //Act
        var testDto = dto.Parse<TestDto>();

        //Assert
        Assert.IsTrue(testDto!.childTestDto.IsSpecified);
        Assert.IsFalse(testDto.childTestDto.IsNull);
        Assert.IsTrue(testDto.childTestDto.Value!.street.IsSpecified);
        Assert.IsFalse(testDto.childTestDto.Value.street.IsNull);
        Assert.AreEqual("teststreet", testDto.childTestDto.Value.street.Value);
    }

    [TestMethod]
    public void Empty_child_dto_object_should_give_unspecified_member_on_that_child_object()
    {
        //Arrange
        var dto = "{\"childTestDto\":{}}";

        //Act
        var testDto = dto.Parse<TestDto>();

        //Assert
        Assert.IsTrue(testDto!.childTestDto.IsSpecified);
        Assert.IsFalse(testDto.childTestDto.IsNull);
        Assert.IsFalse(testDto.childTestDto.Value!.street.IsSpecified);
        Assert.IsTrue(testDto.childTestDto.Value.street.IsNull);
    }

    [TestMethod]
    public void Null_child_should_give_null()
    {
        //Arrange
        var dto = "{\"childTestDto\":null}";

        //Act
        var testDto = dto.Parse<TestDto>();

        //Assert
        Assert.IsTrue(testDto!.childTestDto.IsSpecified);
        Assert.IsTrue(testDto.childTestDto.IsNull);
    }
}
