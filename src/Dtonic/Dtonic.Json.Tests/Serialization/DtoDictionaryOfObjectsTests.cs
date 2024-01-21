using Dtonic.Dto;
using Dtonic.Dto.Extensions;
using TestClasses;

namespace Serialization;

[TestClass]
public class DtoDictionaryOfObjectsTests
{
    [TestMethod]
    public void Unspecified_should_return_empty_string()
    {
        //Arrange
        var dtoDictionary = DtoDictionaryOfObjects<TestDto>.Unspecified;

        //Act
        var s = dtoDictionary.StringifyWithKey();

        //Assert
        Assert.AreEqual(string.Empty, s);
    }

    [TestMethod]
    public void Null_should_return_null_value()
    {
        //Arrange
        var dtoDictionary = new DtoDictionaryOfObjects<TestDto>(null);

        //Act
        var s = dtoDictionary.StringifyWithKey();

        //Assert
        Assert.AreEqual("\"dtoDictionary\":null", s);
    }

    [TestMethod]
    public void DtoDictionary_should_return_object()
    {
        //Arrange
        var dict = new Dictionary<string, TestDto?>() { { "one", new TestDto() }, { "two", new TestDto() } };
        var dtoDictionary = new DtoDictionaryOfObjects<TestDto>(dict);

        //Act
        var s = dtoDictionary.StringifyWithKey();

        //Assert
        Assert.AreEqual("\"dtoDictionary\":[{\"one\":{}},{\"two\":{}}]", s);
    }

    [TestMethod]
    public void DtoDictionary_with_null_value_row_should_return_object()
    {
        //Arrange
        var dict = new Dictionary<string, TestDto?>() { { "one", new TestDto() }, { "two", null } };
        var dtoDictionary = new DtoDictionaryOfObjects<TestDto>(dict);

        //Act
        var s = dtoDictionary.StringifyWithKey();

        //Assert
        Assert.AreEqual("\"dtoDictionary\":[{\"one\":{}},{\"two\":null}]", s);
    }
}