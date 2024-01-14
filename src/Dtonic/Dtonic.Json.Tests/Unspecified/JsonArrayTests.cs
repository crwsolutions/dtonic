using Dtonic.Json;

namespace Unspecified;

[TestClass]
public class JsonArrayTests
{
    [TestMethod]
    public void Unspecified_should_have_no_value()
    {
        //Arrange
        var jsonArray = JsonArray<int>.Unspecified;

        //Act

        //Assert
        Assert.IsNull(jsonArray.Value);
        Assert.IsTrue(jsonArray.IsNull);
        Assert.IsFalse(jsonArray.IsSet);
    }
}
