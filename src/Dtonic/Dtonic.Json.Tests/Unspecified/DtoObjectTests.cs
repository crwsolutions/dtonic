using Dtonic.Dto;
using Dtonic.Dto.Exceptions;
using TestClasses;

namespace Unspecified;

[TestClass]
public class DtoObjectTests
{
    [TestMethod]
    public void Unspecified_should_have_no_value()
    {
        //Arrange
        var dtoObject = DtoObject<TestDto>.Unspecified;

        //Act

        //Assert
        Assert.IsFalse(dtoObject.IsSpecified);
    }

    [TestMethod]
    [ExpectedException(typeof(DtoValueIsNotSpecifiedException))]
    public void Checking_the_value_of_an_unspecified_should_throw_exception()
    {
        //Arrange
        var dtoObject = DtoObject<TestDto>.Unspecified;

        //Act
        var x = dtoObject.Value;

        //Assert
        Assert.Fail();
    }
}
