using Dtonic.Dto;
using Dtonic.Dto.Extensions;
using TestClasses;

namespace Serialization;

[TestClass]
public class DtoDictionaryWithArrayofObjectsTests
{
    [TestMethod]
    public void Unspecified_should_return_empty_string()
    {
        //Arrange
        var dtoDictionary = DtoDictionaryWithArrayofObjects<TestDto>.Unspecified;

        //Act
        var s = dtoDictionary.StringifyWithKey();

        //Assert
        Assert.AreEqual(string.Empty, s);
    }

    [TestMethod]
    public void Null_should_return_null_value()
    {
        //Arrange
        var dtoDictionary = new DtoDictionaryWithArrayofObjects<TestDto>(null);

        //Act
        var s = dtoDictionary.StringifyWithKey();

        //Assert
        Assert.AreEqual("\"dtoDictionary\":null", s);
    }

    [TestMethod]
    public void DtoDictionary_should_return_object()
    {
        //Arrange
        var dict = new Dictionary<string, IEnumerable<TestDto?>?>() 
        { 
            { "one", [new TestDto() { aBoolean = true }] },
            { "two", [new TestDto() { aBoolean = true }, 
                      null, 
                      new TestDto() { aBoolean = false }] }
        };

        var dtoDictionary = new DtoDictionaryWithArrayofObjects<TestDto>(dict);

        //Act
        var s = dtoDictionary.StringifyWithKey();

        //Assert
        Assert.AreEqual("\"dtoDictionary\":[{\"one\":[{\"aBoolean\":true}]},{\"two\":[{\"aBoolean\":true},null,{\"aBoolean\":false}]}]", s);
    }

    [TestMethod]
    public void DtoDictionary_with_null_value_row_should_return_object()
    {
        //Arrange
        var dict = new Dictionary<string, IEnumerable<TestDto?>?>() { { "one", [new TestDto() { aBoolean = true }] }, { "two", null } };
        var dtoDictionary = new DtoDictionaryWithArrayofObjects<TestDto>(dict);

        //Act
        var s = dtoDictionary.StringifyWithKey();

        //Assert
        Assert.AreEqual("\"dtoDictionary\":[{\"one\":[{\"aBoolean\":true}]},{\"two\":null}]", s);
    }
}