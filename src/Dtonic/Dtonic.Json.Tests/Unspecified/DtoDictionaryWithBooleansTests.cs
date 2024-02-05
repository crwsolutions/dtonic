using Dtonic.Dto;
using Dtonic.Dto.Exceptions;

namespace Unspecified;

[TestClass]
public class DtoDictionaryWithBooleansTests
{
    [TestMethod]
    public void Unspecified_should_have_no_value()
    {
        //Arrange
        var dtoDictionary = DtoDictionaryWithBooleans.Unspecified;

        //Act

        //Assert
        Assert.IsFalse(dtoDictionary.IsSpecified);
    }

    [TestMethod]
    [ExpectedException(typeof(DtoValueIsNotSpecifiedException))]
    public void Checking_the_value_of_an_unspecified_should_throw_exception()
    {
        //Arrange
        var dtoDictionary = DtoDictionaryWithBooleans.Unspecified;

        //Act
        var x = dtoDictionary.Value;

        //Assert
        Assert.Fail();
    }
}
