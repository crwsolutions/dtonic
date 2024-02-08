using Dtonic.Dto;
using Dtonic.Dto.Extensions;

namespace Serialization;

[TestClass]
public class DtoStringTests
{
    [TestMethod]
    public void Unspecified_should_return_empty_string()
    {
        //Arrange
        var dtoString = DtoString.Unspecified;

        //Act
        var s = dtoString.StringifyWithKey();

        //Assert
        Assert.AreEqual(string.Empty, s);
    }

    [TestMethod]
    public void Null_should_return_null_value()
    {
        //Arrange
        var dtoString = new DtoString(null);

        //Act
        var s = dtoString.StringifyWithKey();

        //Assert
        Assert.AreEqual("\"dtoString\":null", s);
    }

    [TestMethod]
    public void Empty_return_Empty()
    {
        //Arrange
        var dtoString = new DtoString("");

        //Act
        var s = dtoString.StringifyWithKey();

        //Assert
        Assert.AreEqual("\"dtoString\":\"\"", s);
    }

    [TestMethod]
    public void Spaces_return_Spaces()
    {
        //Arrange
        var dtoString = new DtoString("  ");

        //Act
        var s = dtoString.StringifyWithKey();

        //Assert
        Assert.AreEqual("\"dtoString\":\"  \"", s);
    }

    [TestMethod]
    public void Test_string_return_test_string()
    {
        //Arrange
        var dtoString = new DtoString("  test  ");

        //Act
        var s = dtoString.StringifyWithKey();

        //Assert
        Assert.AreEqual("\"dtoString\":\"  test  \"", s);
    }

    [TestMethod]
    public void Littler_than_should_be_escaped()
    {
        //Arrange
        var c = (char)1;
        var dtoString = new DtoString(new string([c]));

        //Act
        var s = dtoString.StringifyWithKey();

        //Assert
        Assert.AreEqual("\"dtoString\":\"\\u0001\"", s);
    }

    [TestMethod]
    public void Carriage_return_linefeed_should_be_escaped()
    {
        //Arrange
        var cr = '\r';
        var lf = '\n';
        var dtoString = new DtoString(new string([cr, lf]));

        //Act
        var s = dtoString.StringifyWithKey();

        //Assert
        Assert.AreEqual("\"dtoString\":\"\\r\\n\"", s);
    }

    [TestMethod]
    public void All_special_characters_should_be_escaped()
    {
        //Arrange
        var a = (char)0;
        var b = (char)1;
        var c = (char)2;
        var d = (char)3;
        var e = (char)4;
        var f = (char)5;
        var g = (char)6;
        var h = (char)7;
        var i = (char)8;
        var j = (char)9;
        var k = (char)10;
        var l = (char)11;
        var m = (char)12;
        var n = (char)13;
        var o = (char)14;
        var p = (char)15;
        var q = (char)16;
        var r = (char)17;
        var s = (char)18;
        var t = (char)19;
        var u = (char)20;
        var dtoString = new DtoString(new string([a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,'"', '\\', '/', '\b', '\f', '\t']));


        //Act
        var ss = dtoString.StringifyWithKey();

        //Assert
        Assert.AreEqual("\"dtoString\":\"\\u0000\\u0001\\u0002\\u0003\\u0004\\u0005\\u0006\\u0007\\b\\t\\n\\u000B\\f\\r\\u000E\\u000F\\u0010\\u0011\\u0012\\u0013\\u0014\\\"\\\\\\/\\b\\f\\t\"", ss);
    }
}