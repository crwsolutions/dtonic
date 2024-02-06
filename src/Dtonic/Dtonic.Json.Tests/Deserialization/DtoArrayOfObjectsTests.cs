using Dtonic.Dto.Extensions;
using TestClasses;

namespace Deserialization;

[TestClass]
public class DtoArrayOfObjectsTests
{
    [TestMethod]
    public void Unspecified_value_should_give_isset_is_false()
    {
        //Arrange
        var dto = "{}";

        //Act
        var testDto = dto.Parse<TestDto>();

        //Assert
        Assert.IsFalse(testDto!.anArrayOfObjects.IsSpecified);
        Assert.IsTrue(testDto.anArrayOfObjects.IsNull);
    }

    [TestMethod]
    public void Null_value_should_give_null()
    {
        //Arrange
        var dto = "{\"anArrayOfObjects\":null}";

        //Act
        var testDto = dto.Parse<TestDto>();

        //Assert
        Assert.IsTrue(testDto!.anArrayOfObjects.IsSpecified);
        Assert.IsTrue(testDto.anArrayOfObjects.IsNull);
    }

    [TestMethod]
    public void Empty_array_should_give_the_zero_number_of_items()
    {
        //Arrange
        var dto = "{\"anArrayOfObjects\":[]}";

        //Act
        var testDto = dto.Parse<TestDto>();

        //Assert
        Assert.IsTrue(testDto!.anArrayOfObjects.IsSpecified);
        Assert.IsFalse(testDto.anArrayOfObjects.IsNull);
        Assert.AreEqual(0, testDto.anArrayOfObjects.Value!.Count());
    }

    [TestMethod]
    public void Filled_object_array_should_give_back_that_array_value()
    {
        //Arrange
        var dto = "{\"anArrayOfObjects\":[{\"aString\":\" wallstreet \"},null,{\"aNumber\":12}]}";

        //Act
        var testDto = dto.Parse<TestDto>();
        var a = testDto!.anArrayOfObjects.Value!.ToArray();

        //Assert
        Assert.IsTrue(testDto!.anArrayOfObjects.IsSpecified);
        Assert.IsFalse(testDto.anArrayOfObjects.IsNull);
        Assert.AreEqual(" wallstreet ", a[0]!.aString.Value);
        Assert.IsNull(a[1]);
        Assert.AreEqual(12, a[2]!.aNumber.Value);
        Assert.AreEqual(3, a.Length);
    }
}
