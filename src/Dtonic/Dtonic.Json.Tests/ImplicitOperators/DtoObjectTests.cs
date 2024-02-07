using Dtonic.Dto;
using TestClasses;

namespace ImplicitOperators;

[TestClass]
public class DtoObjectTests
{
    [TestMethod]
    public void Assign_object()
    {
        //Arrange
        var obj = new TestDto();

        //Act
        DtoObject<TestDto> dto = obj;

        //Assert
        Assert.IsTrue(dto.IsSpecified);
        Assert.IsFalse(dto.IsNull);
        Assert.IsFalse(dto.Value.aString.IsSpecified);
    }

    [TestMethod]
    public void Assign_nullable_null()
    {
        //Arrange
        TestDto? s = null;

        //Act
        DtoObject<TestDto> dto = s;

        //Assert
        Assert.IsTrue(dto.IsSpecified);
        Assert.IsTrue(dto.IsNull);
    }

    [TestMethod]
    public void Assign_nullable_object ()
    {
        //Arrange
        TestDto? v = new TestDto();

        //Act
        DtoObject<TestDto> dto = v;

        //Assert
        Assert.IsTrue(dto.IsSpecified);
        Assert.IsFalse(dto.IsNull);
        Assert.IsFalse(dto.Value.aString.IsSpecified);
    }
}
