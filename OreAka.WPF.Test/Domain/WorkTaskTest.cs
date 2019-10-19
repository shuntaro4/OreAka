using OreAka.WPF.Domain;
using System;
using Xunit;

namespace OreAka.WPF.Test.Domain
{
    public class WorkTaskTest
    {
        [Fact(DisplayName = "正：Answerが正しいフォーマット")]
        [Trait("WorkTask", "WorkTask")]
        public void WorkTaskTrue1()
        {
            var answer = "C#,80";
            var actual = new WorkTask(answer);

            Assert.NotNull(actual);
            Assert.Equal("C#", actual.Title);
            Assert.Equal(80, actual.Minutes);
        }

        [Fact(DisplayName = "正：Answerに空白を含む")]
        [Trait("WorkTask", "WorkTask")]
        public void WorkTaskTrue2()
        {
            var answer = " C# , 80 ";
            var actual = new WorkTask(answer);

            Assert.NotNull(actual);
            Assert.Equal("C#", actual.Title);
            Assert.Equal(80, actual.Minutes);
        }

        [Fact(DisplayName = "異：Answer = null")]
        [Trait("WorkTask", "WorkTask")]
        public void WorkTaskFalse1()
        {
            var exception = Assert.Throws<ArgumentException>(() =>
            {
                var actual = new WorkTask(null);
            });
            Assert.Equal("Answer value is null or empty.", exception.Message);
        }

        [Fact(DisplayName = "異：Answer = \"\"")]
        [Trait("WorkTask", "WorkTask")]
        public void WorkTaskFalse2()
        {
            var exception = Assert.Throws<ArgumentException>(() =>
            {
                var actual = new WorkTask("");
            });
            Assert.Equal("Answer value is null or empty.", exception.Message);
        }

        [Fact(DisplayName = "異：Answer = \" 　\"")]
        [Trait("WorkTask", "WorkTask")]
        public void WorkTaskFalse3()
        {
            var exception = Assert.Throws<ArgumentException>(() =>
            {
                var actual = new WorkTask(" 　");
            });
            Assert.Equal("Answer value is null or empty.", exception.Message);
        }

        [Fact(DisplayName = "異：Answer = カンマがない")]
        [Trait("WorkTask", "WorkTask")]
        public void WorkTaskFalse4()
        {
            var answer = "C# 80";
            var exception = Assert.Throws<ArgumentException>(() =>
            {
                var actual = new WorkTask(answer);
            });
            Assert.Equal("Answer format is invalid.(e.g \"send mail, 90\")", exception.Message);
        }

        [Fact(DisplayName = "異：Answer = カンマ後が数値文字列でない")]
        [Trait("WorkTask", "WorkTask")]
        public void WorkTaskFalse5()
        {
            var answer = "C#,hoge";
            var exception = Assert.Throws<ArgumentException>(() =>
            {
                var actual = new WorkTask(answer);
            });
            Assert.Equal("Answer format is invalid.(e.g \"send mail, 90\")", exception.Message);
        }
    }
}
