using Dtonic.Dto;
using Dtonic.Dto.Exceptions;

namespace Unspecified;

[TestClass]
public class DtoStringTests
{
    [TestMethod]
    public void Unspecified_should_have_no_value()
    {
        //Arrange
        var dtoString = DtoString.Unspecified;

        //Act

        //Assert
        Assert.IsFalse(dtoString.IsSpecified);
    }

    [TestMethod]
    [ExpectedException(typeof(DtoValueIsNotSpecifiedException))]
    public void Checking_the_value_of_an_unspecified_should_throw_exception()
    {
        //Arrange
        var dtoString = DtoString.Unspecified;

        //Act
        var x = dtoString.Value;

        //Assert
        Assert.Fail();
    }
}
