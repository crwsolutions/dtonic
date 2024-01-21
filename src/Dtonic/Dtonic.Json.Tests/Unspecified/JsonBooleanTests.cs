using Dtonic.Json;

namespace Unspecified;

[TestClass]
public class JsonBooleanTests
{
    [TestMethod]
    public void Unspecified_should_have_no_value()
    {
        //Arrange
        var jsonBoolean = JsonBoolean.Unspecified;

        //Act

        //Assert
        Assert.IsNull(jsonBoolean.Value);
        Assert.IsTrue(jsonBoolean.IsNull);
        Assert.IsFalse(jsonBoolean.IsSpecified);
    }
}
