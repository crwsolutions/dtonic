using Dtonic.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TestClasses;

namespace Deserialization;
[TestClass]
public class JsonObjectTests
{
    [TestMethod]
    public void Filled_json_object_should_give_filled_dto()
    {
        //Arrange
        var json = "{\"street\":\"teststreet\"}";

        //Act
        var options = new JsonReaderOptions
        {
            AllowTrailingCommas = true,
            CommentHandling = JsonCommentHandling.Skip
        };
        var jsonReader = new Utf8JsonReader(Encoding.UTF8.GetBytes(json), options);
        var testDto = new TestDto(jsonReader);

        //Assert
        Assert.IsTrue(testDto.street.IsSet);
        Assert.IsFalse(testDto.street.IsNull);
        Assert.AreEqual("teststreet", testDto.street.Value);
    }
}