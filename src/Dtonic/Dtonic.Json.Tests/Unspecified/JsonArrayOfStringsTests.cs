using Dtonic.Json;

namespace Unspecified;

[TestClass]
public class JsonArrayOfStringsTests
{
    [TestMethod]
    public void Unspecified_should_have_no_value()
    {
        //Arrange
        var jsonArray = JsonArrayOfStrings.Unspecified;

        //Act

        //Assert
        Assert.IsNull(jsonArray.Value);
        Assert.IsTrue(jsonArray.IsNull);
        Assert.IsFalse(jsonArray.IsSet);
    }
}
