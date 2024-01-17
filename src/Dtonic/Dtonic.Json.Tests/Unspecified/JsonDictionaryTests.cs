using Dtonic.Json;

namespace Unspecified;

[TestClass]
public class JsonDictionaryTests
{
    [TestMethod]
    public void Unspecified_should_have_no_value()
    {
        //Arrange
        var jsonDictionary = JsonDictionary<int>.Unspecified;

        //Act

        //Assert
        Assert.IsNull(jsonDictionary.Value);
        Assert.IsTrue(jsonDictionary.IsNull);
        Assert.IsFalse(jsonDictionary.IsSet);
    }
}
