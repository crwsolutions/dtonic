using Dtonic.Dto;
using Dtonic.Dto.Exceptions;

namespace Unspecified;

[TestClass]
public class DtoBooleanTests
{
    [TestMethod]
    public void Unspecified_should_have_no_value()
    {
        //Arrange
        var dtoBoolean = DtoBoolean.Unspecified;

        //Act

        //Assert
        Assert.IsFalse(dtoBoolean.IsSpecified);
    }

    [TestMethod]
    [ExpectedException(typeof(DtoValueIsNotSpecifiedException))]
    public void Checking_the_value_of_an_unspecified_should_throw_exception()
    {
        //Arrange
        var dtoBoolean = DtoBoolean.Unspecified;

        //Act
        var x = dtoBoolean.Value;

        //Assert
        Assert.Fail();
    }
}
