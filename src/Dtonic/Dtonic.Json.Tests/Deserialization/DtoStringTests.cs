﻿using Dtonic.Dto.Extensions;
using TestClasses;

namespace Deserialization;

[TestClass]
public class DtoStringTests
{
    [TestMethod]
    public void Unspecified_value_should_give_isset_is_false()
    {
        //Arrange
        var dto = "{}";

        //Act
        var testDto = dto.Parse<TestDto>();

        //Assert
        Assert.IsFalse(testDto!.street.IsSpecified);
        Assert.IsTrue(testDto.street.IsNull);
    }

    [TestMethod]
    public void Null_value_should_give_null()
    {
        //Arrange
        var dto = "{\"street\":null}";

        //Act
        var testDto = dto.Parse<TestDto>();

        //Assert
        Assert.IsTrue(testDto!.street.IsSpecified);
        Assert.IsTrue(testDto.street.IsNull);
    }

    [TestMethod]
    public void Specified_value_should_give_the_specified_value()
    {
        //Arrange
        var dto = "{\"street\":\" wallstreet \"}";

        //Act
        var testDto = dto.Parse<TestDto>();

        //Assert
        Assert.IsTrue(testDto!.street.IsSpecified);
        Assert.IsFalse(testDto.street.IsNull);
        Assert.AreEqual(" wallstreet ", testDto.street.Value);
    }

    [TestMethod]
    public void Empty_value_should_give_the_empty_value()
    {
        //Arrange
        var dto = "{\"street\":\"\"}";

        //Act
        var testDto = dto.Parse<TestDto>();

        //Assert
        Assert.IsTrue(testDto!.street.IsSpecified);
        Assert.IsFalse(testDto.street.IsNull);
        Assert.AreEqual(string.Empty, testDto.street.Value);
    }
}