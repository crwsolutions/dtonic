using Dtonic.Json;
using Dtonic.Json.Exceptions;
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
        Assert.IsFalse(jsonDictionary.IsSpecified);
    }

    [TestMethod]
    [ExpectedException(typeof(ValueIsNotSpecifiedException))]
    public void Checking_the_value_of_an_unspecified_should_throw_exception()
    {
        //Arrange
        var jsonDictionary = JsonDictionaryOfObjects<TestDto>.Unspecified;

        //Act
        var x = jsonDictionary.Value;

        //Assert
        Assert.Fail();
    }
}
