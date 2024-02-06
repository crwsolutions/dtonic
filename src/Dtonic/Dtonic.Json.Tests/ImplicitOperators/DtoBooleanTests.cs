using Dtonic.Dto;

namespace ImplicitOperators;

[TestClass]
public class DtoBooleanTests
{
    [TestMethod]
    public void Assign_boolean()
    {
        //Arrange

        //Act
        DtoBoolean dto = true;

        //Assert
        Assert.IsTrue(dto.IsSpecified);
        Assert.IsFalse(dto.IsNull);
        Assert.IsTrue(dto.Value);
        Assert.AreEqual(nameof(DtoBoolean), dto.GetType().Name);
    }

    [TestMethod]
    public void Assign_nullable_null()
    {
        //Arrange
        bool? v = null;

        //Act
        DtoBoolean dto = v;

        //Assert
        Assert.IsTrue(dto.IsSpecified);
        Assert.IsTrue(dto.IsNull);
        Assert.AreEqual(nameof(DtoBoolean), dto.GetType().Name);
    }

    [TestMethod]
    public void Assign_nullable_boolean ()
    {
        //Arrange
        bool? v = true;

        //Act
        DtoBoolean dto = v;

        //Assert
        Assert.IsTrue(dto.IsSpecified);
        Assert.IsFalse(dto.IsNull);
        Assert.IsTrue(dto.Value);
        Assert.AreEqual(nameof(DtoBoolean), dto.GetType().Name);
    }
}
