using Dtonic.Json;

namespace Unspecified;

[TestClass]
public class JsonNumberTests
{
    [TestMethod]
    public void Unspecified_should_have_no_value()
    {
        //Arrange
        var jsonNumber = JsonNumber.Unspecified;

        //Act

        //Assert
        Assert.IsNull(jsonNumber.Value);
        Assert.IsTrue(jsonNumber.IsNull);
        Assert.IsFalse(jsonNumber.IsSpecified);
    }
}
