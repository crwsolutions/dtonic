using Dtonic.Dto;

namespace ImplicitOperators;

[TestClass]
public class DtoStringTests
{
    [TestMethod]
    public void Assign_string()
    {
        //Arrange
        var s = "Hello";

        //Act
        DtoString dto = s;

        //Assert
        Assert.IsTrue(dto.IsSpecified);
        Assert.IsFalse(dto.IsNull);
        Assert.AreEqual("Hello",dto.Value);
        Assert.AreEqual(nameof(DtoString), dto.GetType().Name);
    }

    [TestMethod]
    public void Assign_nullable_null()
    {
        //Arrange
        string? s = null;

        //Act
        DtoString dto = s;

        //Assert
        Assert.IsTrue(dto.IsSpecified);
        Assert.IsTrue(dto.IsNull);
        Assert.AreEqual(nameof(DtoString), dto.GetType().Name);
    }

    [TestMethod]
    public void Assign_nullable_string ()
    {
        //Arrange
        string? v = "Hello";

        //Act
        DtoString dto = v;

        //Assert
        Assert.IsTrue(dto.IsSpecified);
        Assert.IsFalse(dto.IsNull);
        Assert.AreEqual("Hello", dto.Value);
        Assert.AreEqual(nameof(DtoString), dto.GetType().Name);
    }
}
