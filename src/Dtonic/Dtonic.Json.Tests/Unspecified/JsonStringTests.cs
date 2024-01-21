using Dtonic.Json;

namespace Unspecified;

[TestClass]
public class JsonStringTests
{
    [TestMethod]
    public void Unspecified_should_have_no_value()
    {
        //Arrange
        var jsonString = JsonString.Unspecified;

        //Act

        //Assert
        Assert.IsNull(jsonString.Value);
        Assert.IsTrue(jsonString.IsNull);
        Assert.IsFalse(jsonString.IsSpecified);
    }
}