using Dtonic.Dto;
using Dtonic.Dto.Exceptions;

namespace Unspecified;

[TestClass]
public class DtoArrayOfNumbersTests
{
    [TestMethod]
    public void Unspecified_should_have_no_value()
    {
        //Arrange
        var dtoArray = DtoArrayOfNumbers.Unspecified;

        //Act

        //Assert
        Assert.IsFalse(dtoArray.IsSpecified);
    }

    [TestMethod]
    [ExpectedException(typeof(DtoValueIsNotSpecifiedException))]
    public void Checking_the_value_of_an_unspecified_should_throw_exception()
    {
        //Arrange
        var dtoArray = DtoArrayOfNumbers.Unspecified;

        //Act
        var x = dtoArray.Value;

        //Assert
        Assert.Fail();
    }
}
