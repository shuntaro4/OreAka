using WhatsApp.WPF.Domain;
using Xunit;

namespace WhatsApp.WPF.Test.Domain
{
    public class TypeParseTest
    {
        [Fact(DisplayName = "正：数値文字列")]
        [Trait("TypeParse", "ToInt")]
        public void ToIntTrue1()
        {
            var target = "123";
            var actual = TypeParse.ToInt(target);
            Assert.Equal(123, actual);
        }

        [Fact(DisplayName = "異：null -> 0")]
        [Trait("TypeParse", "ToInt")]
        public void ToIntFalse1()
        {
            var actual = TypeParse.ToInt(null);
            Assert.Equal(0, actual);
        }

        [Fact(DisplayName = "異：\"\" -> 0")]
        [Trait("TypeParse", "ToInt")]
        public void ToIntFalse2()
        {
            var target = "";
            var actual = TypeParse.ToInt(target);
            Assert.Equal(0, actual);
        }

        [Fact(DisplayName = "異：数値文字列以外 -> 0")]
        [Trait("TypeParse", "ToInt")]
        public void ToIntFalse3()
        {
            var target = "hoge";
            var actual = TypeParse.ToInt(target);
            Assert.Equal(0, actual);
        }
    }
}
