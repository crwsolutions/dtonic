using Dtonic.Json;
using TestClasses;

namespace Unspecified;

[TestClass]
public class JsonDictionaryOfObjectsTests
{
    [TestMethod]
    public void Unspecified_should_have_no_value()
    {
        //Arrange
        var jsonDictionary = JsonDictionaryOfObjects<TestDto>.Unspecified;

        //Act

        //Assert
        Assert.IsNull(jsonDictionary.Value);
        Assert.IsTrue(jsonDictionary.IsNull);
        Assert.IsFalse(jsonDictionary.IsSpecified);
    }
}
