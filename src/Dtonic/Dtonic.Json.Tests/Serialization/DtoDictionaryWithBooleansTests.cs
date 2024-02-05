using Dtonic.Dto;
using Dtonic.Dto.Extensions;

namespace Serialization;

[TestClass]
public class DtoDictionaryWithBooleansTests
{
    [TestMethod]
    public void Unspecified_should_return_empty_string()
    {
        //Arrange
        var dtoDictionary = DtoDictionaryWithBooleans.Unspecified;

        //Act
        var s = dtoDictionary.StringifyWithKey();

        //Assert
        Assert.AreEqual(string.Empty, s);
    }

    [TestMethod]
    public void Null_should_return_null_value()
    {
        //Arrange
        var dtoDictionary = new DtoDictionaryWithBooleans(null);

        //Act
        var s = dtoDictionary.StringifyWithKey();

        //Assert
        Assert.AreEqual("\"dtoDictionary\":null", s);
    }

    [TestMethod]
    public void DtoDictionary_should_return_object()
    {
        //Arrange
        var dict = new Dictionary<string, bool?>() { { "one", true }, { "two", false } };
        var dtoDictionary = new DtoDictionaryWithBooleans(dict);

        //Act
        var s = dtoDictionary.StringifyWithKey();

        //Assert
        Assert.AreEqual("\"dtoDictionary\":[{\"one\":true},{\"two\":false}]", s);
    }

    [TestMethod]
    public void DtoDictionary_with_null_value_row_should_return_object()
    {
        //Arrange
        var dict = new Dictionary<string, bool?>() { { "one", true }, { "two", null } };
        var dtoDictionary = new DtoDictionaryWithBooleans(dict);

        //Act
        var s = dtoDictionary.StringifyWithKey();

        //Assert
        Assert.AreEqual("\"dtoDictionary\":[{\"one\":true},{\"two\":null}]", s);
    }
}