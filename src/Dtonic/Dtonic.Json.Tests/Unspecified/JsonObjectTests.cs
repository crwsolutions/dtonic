using Dtonic.Json;

namespace Unspecified;

[TestClass]
public class JsonObjectTests
{
    [TestMethod]
    public void Unspecified_should_have_no_value()
    {
        //Arrange
        var jsonObject = JsonObject<object>.Unspecified;

        //Act

        //Assert
        Assert.IsNull(jsonObject.Value);
        Assert.IsTrue(jsonObject.IsNull);
        Assert.IsFalse(jsonObject.IsSet);
    }
}
