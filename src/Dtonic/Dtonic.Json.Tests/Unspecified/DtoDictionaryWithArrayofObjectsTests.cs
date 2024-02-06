using Dtonic.Dto;
using Dtonic.Dto.Exceptions;
using TestClasses;

namespace Unspecified;

[TestClass]
public class DtoDictionaryWithArrayofObjectsTests
{
    [TestMethod]
    public void Unspecified_should_have_no_value()
    {
        //Arrange
        var dtoDictionary = DtoDictionaryWithArrayofObjects<TestDto>.Unspecified;

        //Act

        //Assert
        Assert.IsFalse(dtoDictionary.IsSpecified);
    }

    [TestMethod]
    [ExpectedException(typeof(DtoValueIsNotSpecifiedException))]
    public void Checking_the_value_of_an_unspecified_should_throw_exception()
    {
        //Arrange
        var dtoDictionary = DtoDictionaryWithArrayofObjects<TestDto>.Unspecified;

        //Act
        var x = dtoDictionary.Value;

        //Assert
        Assert.Fail();
    }
}
