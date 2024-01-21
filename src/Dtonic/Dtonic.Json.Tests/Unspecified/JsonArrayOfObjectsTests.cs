using Dtonic.Json;
using TestClasses;

namespace Unspecified;

[TestClass]
public class JsonArrayOfObjectsTests
{
    [TestMethod]
    public void Unspecified_should_have_no_value()
    {
        //Arrange
        var jsonArray = JsonArrayOfObjects<TestDto>.Unspecified;

        //Act

        //Assert
        Assert.IsNull(jsonArray.Value);
        Assert.IsTrue(jsonArray.IsNull);
        Assert.IsFalse(jsonArray.IsSpecified);
    }
}
