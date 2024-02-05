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
        var dto = "{\"aString\":\"teststreet\"}";

        //Act
        var testDto = dto.Parse<TestDto>();

        //Assert
        Assert.IsTrue(testDto!.aString.IsSpecified);
        Assert.IsFalse(testDto.aString.IsNull);
        Assert.AreEqual("teststreet", testDto.aString.Value);
    }

    [TestMethod]
    public void Empty_root_dto_object_should_give_unspecified_member()
    {
        //Arrange
        var dto = "{}";

        //Act
        var testDto = dto.Parse<TestDto>();

        //Assert
        Assert.IsFalse(testDto!.aString.IsSpecified);
        Assert.IsTrue(testDto.aString.IsNull);
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
        var dto = "{\"anObject\":{\"aString\":\"teststreet\"}}";

        //Act
        var testDto = dto.Parse<TestDto>();

        //Assert
        Assert.IsTrue(testDto!.anObject.IsSpecified);
        Assert.IsFalse(testDto.anObject.IsNull);
        Assert.IsTrue(testDto.anObject.Value!.aString.IsSpecified);
        Assert.IsFalse(testDto.anObject.Value.aString.IsNull);
        Assert.AreEqual("teststreet", testDto.anObject.Value.aString.Value);
    }

    [TestMethod]
    public void Empty_child_dto_object_should_give_unspecified_member_on_that_child_object()
    {
        //Arrange
        var dto = "{\"anObject\":{}}";

        //Act
        var testDto = dto.Parse<TestDto>();

        //Assert
        Assert.IsTrue(testDto!.anObject.IsSpecified);
        Assert.IsFalse(testDto.anObject.IsNull);
        Assert.IsFalse(testDto.anObject.Value!.aString.IsSpecified);
        Assert.IsTrue(testDto.anObject.Value.aString.IsNull);
    }

    [TestMethod]
    public void Null_child_should_give_null()
    {
        //Arrange
        var dto = "{\"anObject\":null}";

        //Act
        var testDto = dto.Parse<TestDto>();

        //Assert
        Assert.IsTrue(testDto!.anObject.IsSpecified);
        Assert.IsTrue(testDto.anObject.IsNull);
    }
}
