using Dtonic.Dto;
using Dtonic.Dto.Exceptions;

namespace Unspecified;

[TestClass]
public class DtoNumberTests
{
    [TestMethod]
    public void Unspecified_should_have_no_value()
    {
        //Arrange
        var dtoNumber = DtoNumber.Unspecified;

        //Act

        //Assert
        Assert.IsFalse(dtoNumber.IsSpecified);
    }

    [TestMethod]
    [ExpectedException(typeof(DtoValueIsNotSpecifiedException))]
    public void Checking_the_value_of_an_unspecified_should_throw_exception()
    {
        //Arrange
        var dtoNumber = DtoNumber.Unspecified;

        //Act
        var x = dtoNumber.Value;

        //Assert
        Assert.Fail();
    }
}
