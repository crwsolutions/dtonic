using Dtonic.Dto;

namespace ImplicitOperators;

[TestClass]
public class DtoNumberTests
{
    [TestMethod]
    public void Assign_decimal()
    {
        //Arrange
        var v = 1.1m;

        //Act
        DtoNumber dto = v;

        //Assert
        Assert.IsTrue(dto.IsSpecified);
        Assert.IsFalse(dto.IsNull);
        Assert.AreEqual(v, dto.Value);
        Assert.AreEqual(nameof(DtoNumber), dto.GetType().Name);
    }

    [TestMethod]
    public void Assign_nullable_decimal_null()
    {
        //Arrange
        decimal? v = null;

        //Act
        DtoNumber dto = v;

        //Assert
        Assert.IsTrue(dto.IsSpecified);
        Assert.IsTrue(dto.IsNull);
        Assert.AreEqual(nameof(DtoNumber), dto.GetType().Name);
    }

    [TestMethod]
    public void Assign_nullable_decimal()
    {
        //Arrange
        decimal? v = 1.2m;

        //Act
        DtoNumber dto = v;

        //Assert
        Assert.IsTrue(dto.IsSpecified);
        Assert.IsFalse(dto.IsNull);
        Assert.AreEqual(v.Value, dto.Value);
        Assert.AreEqual(nameof(DtoNumber), dto.GetType().Name);
    }
    [TestMethod]
    public void Assign_sbyte()
    {
        //Arrange
        sbyte v = 1;

        //Act
        DtoNumber dto = v;

        //Assert
        Assert.IsTrue(dto.IsSpecified);
        Assert.IsFalse(dto.IsNull);
        Assert.AreEqual(v, dto.Value);
        Assert.AreEqual(nameof(DtoNumber), dto.GetType().Name);
    }

    [TestMethod]
    public void Assign_nullable_sbyte_null()
    {
        //Arrange
        sbyte? v = null;

        //Act
        DtoNumber dto = v;

        //Assert
        Assert.IsTrue(dto.IsSpecified);
        Assert.IsTrue(dto.IsNull);
        Assert.AreEqual(nameof(DtoNumber), dto.GetType().Name);
    }

    [TestMethod]
    public void Assign_nullable_sbyte()
    {
        //Arrange
        sbyte? v = 1;

        //Act
        DtoNumber dto = v;

        //Assert
        Assert.IsTrue(dto.IsSpecified);
        Assert.IsFalse(dto.IsNull);
        Assert.AreEqual(v.Value, dto.Value);
        Assert.AreEqual(nameof(DtoNumber), dto.GetType().Name);
    }

    [TestMethod]
    public void Assign_byte()
    {
        //Arrange
        byte v = 1;

        //Act
        DtoNumber dto = v;

        //Assert
        Assert.IsTrue(dto.IsSpecified);
        Assert.IsFalse(dto.IsNull);
        Assert.AreEqual(v, dto.Value);
        Assert.AreEqual(nameof(DtoNumber), dto.GetType().Name);
    }

    [TestMethod]
    public void Assign_nullable_byte_null()
    {
        //Arrange
        byte? v = null;

        //Act
        DtoNumber dto = v;

        //Assert
        Assert.IsTrue(dto.IsSpecified);
        Assert.IsTrue(dto.IsNull);
        Assert.AreEqual(nameof(DtoNumber), dto.GetType().Name);
    }

    [TestMethod]
    public void Assign_nullable_byte()
    {
        //Arrange
        byte? v = 1;

        //Act
        DtoNumber dto = v;

        //Assert
        Assert.IsTrue(dto.IsSpecified);
        Assert.IsFalse(dto.IsNull);
        Assert.AreEqual(v.Value, dto.Value);
        Assert.AreEqual(nameof(DtoNumber), dto.GetType().Name);
    }

    [TestMethod]
    public void Assign_short()
    {
        //Arrange
        short v = 1;

        //Act
        DtoNumber dto = v;

        //Assert
        Assert.IsTrue(dto.IsSpecified);
        Assert.IsFalse(dto.IsNull);
        Assert.AreEqual(v, dto.Value);
        Assert.AreEqual(nameof(DtoNumber), dto.GetType().Name);
    }

    [TestMethod]
    public void Assign_nullable_short_null()
    {
        //Arrange
        short? v = null;

        //Act
        DtoNumber dto = v;

        //Assert
        Assert.IsTrue(dto.IsSpecified);
        Assert.IsTrue(dto.IsNull);
        Assert.AreEqual(nameof(DtoNumber), dto.GetType().Name);
    }

    [TestMethod]
    public void Assign_nullable_short()
    {
        //Arrange
        short? v = 1;

        //Act
        DtoNumber dto = v;

        //Assert
        Assert.IsTrue(dto.IsSpecified);
        Assert.IsFalse(dto.IsNull);
        Assert.AreEqual(v.Value, dto.Value);
        Assert.AreEqual(nameof(DtoNumber), dto.GetType().Name);
    }

    [TestMethod]
    public void Assign_ushort()
    {
        //Arrange
        ushort v = 1;

        //Act
        DtoNumber dto = v;

        //Assert
        Assert.IsTrue(dto.IsSpecified);
        Assert.IsFalse(dto.IsNull);
        Assert.AreEqual(v, dto.Value);
        Assert.AreEqual(nameof(DtoNumber), dto.GetType().Name);
    }

    [TestMethod]
    public void Assign_nullable_ushort_null()
    {
        //Arrange
        ushort? v = null;

        //Act
        DtoNumber dto = v;

        //Assert
        Assert.IsTrue(dto.IsSpecified);
        Assert.IsTrue(dto.IsNull);
        Assert.AreEqual(nameof(DtoNumber), dto.GetType().Name);
    }

    [TestMethod]
    public void Assign_nullable_ushort()
    {
        //Arrange
        ushort? v = 1;

        //Act
        DtoNumber dto = v;

        //Assert
        Assert.IsTrue(dto.IsSpecified);
        Assert.IsFalse(dto.IsNull);
        Assert.AreEqual(v.Value, dto.Value);
        Assert.AreEqual(nameof(DtoNumber), dto.GetType().Name);
    }

    [TestMethod]
    public void Assign_int()
    {
        //Arrange
        var v = 10;

        //Act
        DtoNumber dto = v;

        //Assert
        Assert.IsTrue(dto.IsSpecified);
        Assert.IsFalse(dto.IsNull);
        Assert.AreEqual(v, dto.Value);
        Assert.AreEqual(nameof(DtoNumber), dto.GetType().Name);
    }

    [TestMethod]
    public void Assign_nullable_int_null()
    {
        //Arrange
        int? v = null;

        //Act
        DtoNumber dto = v;

        //Assert
        Assert.IsTrue(dto.IsSpecified);
        Assert.IsTrue(dto.IsNull);
        Assert.AreEqual(nameof(DtoNumber), dto.GetType().Name);
    }

    [TestMethod]
    public void Assign_nullable_int()
    {
        //Arrange
        int? v = 12;

        //Act
        DtoNumber dto = v;

        //Assert
        Assert.IsTrue(dto.IsSpecified);
        Assert.IsFalse(dto.IsNull);
        Assert.AreEqual(v.Value, dto.Value);
        Assert.AreEqual(nameof(DtoNumber), dto.GetType().Name);
    }

    [TestMethod]
    public void Assign_uint()
    {
        //Arrange
        uint v = 10;

        //Act
        DtoNumber dto = v;

        //Assert
        Assert.IsTrue(dto.IsSpecified);
        Assert.IsFalse(dto.IsNull);
        Assert.AreEqual(v, dto.Value);
        Assert.AreEqual(nameof(DtoNumber), dto.GetType().Name);
    }

    [TestMethod]
    public void Assign_nullable_uint_null()
    {
        //Arrange
        uint? v = null;

        //Act
        DtoNumber dto = v;

        //Assert
        Assert.IsTrue(dto.IsSpecified);
        Assert.IsTrue(dto.IsNull);
        Assert.AreEqual(nameof(DtoNumber), dto.GetType().Name);
    }

    [TestMethod]
    public void Assign_nullable_uint()
    {
        //Arrange
        uint? v = 133;

        //Act
        DtoNumber dto = v;

        //Assert
        Assert.IsTrue(dto.IsSpecified);
        Assert.IsFalse(dto.IsNull);
        Assert.AreEqual(v.Value, dto.Value);
        Assert.AreEqual(nameof(DtoNumber), dto.GetType().Name);
    }
    [TestMethod]
    public void Assign_long()
    {
        //Arrange
        long v = 111100;

        //Act
        DtoNumber dto = v;

        //Assert
        Assert.IsTrue(dto.IsSpecified);
        Assert.IsFalse(dto.IsNull);
        Assert.AreEqual(v, dto.Value);
        Assert.AreEqual(nameof(DtoNumber), dto.GetType().Name);
    }

    [TestMethod]
    public void Assign_nullable_long_null()
    {
        //Arrange
        long? v = null;

        //Act
        DtoNumber dto = v;

        //Assert
        Assert.IsTrue(dto.IsSpecified);
        Assert.IsTrue(dto.IsNull);
        Assert.AreEqual(nameof(DtoNumber), dto.GetType().Name);
    }

    [TestMethod]
    public void Assign_nullable_long()
    {
        //Arrange
        long? v = 1111004;

        //Act
        DtoNumber dto = v;

        //Assert
        Assert.IsTrue(dto.IsSpecified);
        Assert.IsFalse(dto.IsNull);
        Assert.AreEqual(v.Value, dto.Value);
        Assert.AreEqual(nameof(DtoNumber), dto.GetType().Name);
    }
    //[TestMethod]
    public void Assign_float()
    {
        //Arrange
        var v = 1.1f;

        //Act
        DtoNumber dto = v;

        //Assert
        Assert.IsTrue(dto.IsSpecified);
        Assert.IsFalse(dto.IsNull);
        Assert.AreEqual(v, (float)dto.Value);
        Assert.AreEqual(nameof(DtoNumber), dto.GetType().Name);
    }

    [TestMethod]
    public void Assign_nullable_float_null()
    {
        //Arrange
        float? v = null;

        //Act
        DtoNumber dto = v;

        //Assert
        Assert.IsTrue(dto.IsSpecified);
        Assert.IsTrue(dto.IsNull);
        Assert.AreEqual(nameof(DtoNumber), dto.GetType().Name);
    }

    [TestMethod]
    public void Assign_nullable_float()
    {
        //Arrange
        float? v = 1.2f;

        //Act
        DtoNumber dto = v;

        //Assert
        Assert.IsTrue(dto.IsSpecified);
        Assert.IsFalse(dto.IsNull);
        Assert.AreEqual(v.Value, (float)dto.Value);
        Assert.AreEqual(nameof(DtoNumber), dto.GetType().Name);
    }

    [TestMethod]
    public void Assign_double()
    {
        //Arrange
        var v = 1.1d;

        //Act
        DtoNumber dto = v;

        //Assert
        Assert.IsTrue(dto.IsSpecified);
        Assert.IsFalse(dto.IsNull);
        /// Assert.AreEqual(v, (double)dto.Value);
        Assert.AreEqual(nameof(DtoNumber), dto.GetType().Name);
    }

    [TestMethod]
    public void Assign_nullable_double_null()
    {
        //Arrange
        double? v = null;

        //Act
        DtoNumber dto = v;

        //Assert
        Assert.IsTrue(dto.IsSpecified);
        Assert.IsTrue(dto.IsNull);
        Assert.AreEqual(nameof(DtoNumber), dto.GetType().Name);
    }

    [TestMethod]
    public void Assign_nullable_double()
    {
        //Arrange
        double? v = 1.2d;

        //Act
        DtoNumber dto = v;

        //Assert
        Assert.IsTrue(dto.IsSpecified);
        Assert.IsFalse(dto.IsNull);
        Assert.AreEqual(v.Value, (double)dto.Value);
        Assert.AreEqual(nameof(DtoNumber), dto.GetType().Name);
    }
}
