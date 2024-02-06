﻿using Dtonic.Dto;
using Dtonic.Dto.Extensions;

namespace Serialization;

[TestClass]
public class DtoDictionaryWithArrayofStringsTests
{
    [TestMethod]
    public void Unspecified_should_return_empty_string()
    {
        //Arrange
        var dtoDictionary = DtoDictionaryWithArrayofStrings.Unspecified;

        //Act
        var s = dtoDictionary.StringifyWithKey();

        //Assert
        Assert.AreEqual(string.Empty, s);
    }

    [TestMethod]
    public void Null_should_return_null_value()
    {
        //Arrange
        var dtoDictionary = new DtoDictionaryWithArrayofStrings(null);

        //Act
        var s = dtoDictionary.StringifyWithKey();

        //Assert
        Assert.AreEqual("\"dtoDictionary\":null", s);
    }

    [TestMethod]
    public void DtoDictionary_should_return_object()
    {
        //Arrange
        var dict = new Dictionary<string, IEnumerable<string?>?>() { { "one", ["a"] }, { "two", ["a", null, "b"] } };
        var dtoDictionary = new DtoDictionaryWithArrayofStrings(dict);

        //Act
        var s = dtoDictionary.StringifyWithKey();

        //Assert
        Assert.AreEqual("\"dtoDictionary\":[{\"one\":[\"a\"]},{\"two\":[\"a\",null,\"b\"]}]", s);
    }

    [TestMethod]
    public void DtoDictionary_with_null_value_row_should_return_object()
    {
        //Arrange
        var dict = new Dictionary<string, IEnumerable<string?>?>() { { "one", ["a"] }, { "two", null } };
        var dtoDictionary = new DtoDictionaryWithArrayofStrings(dict);

        //Act
        var s = dtoDictionary.StringifyWithKey();

        //Assert
        Assert.AreEqual("\"dtoDictionary\":[{\"one\":[\"a\"]},{\"two\":null}]", s);
    }
}