using GroupByTech.NExceptionViewer.Core;
using System;
using System.Linq;
using System.Runtime.InteropServices;
using Xunit;

namespace GroupByTech.NExceptionsViewer.Test.Core
{
    public class ExceptionVMTests
    {
        private class CustomException : Exception
        {
            public string StringProp { get; } = "string const";
        }

        [Fact]
        public void Ctor_WhenCalled_CreatesViewmodelsForNotNullData()
        {
            //arrange
            var exception = new Exception();
            exception.Data.Add("key1", new object());
            exception.Data.Add(new object(), "value2");

            //act
            var sut = new ExceptionVM(exception);

            //assert
            Assert.NotNull(sut.DataEntries);
            Assert.Collection(sut.DataEntries,
                x =>
                {
                    Assert.Equal("key1", x.Key);
                    Assert.Equal("System.Object", x.Value);
                },
                x =>
                {
                    Assert.Equal("System.Object", x.Key);
                    Assert.Equal("value2", x.Value);
                });
        }

        [Fact]
        public void Ctor_WhenCalled_CreatesRecordsForCustomProperties()
        {
            //arrange
            var exc = new CustomException();

            //act
            var sut = new ExceptionVM(exc);

            //assert
            Assert.NotNull(sut.CustomProperties);
            Assert.Collection(sut.CustomProperties, 
                x => 
                {
                    Assert.Equal(nameof(CustomException.StringProp), x.Name);
                    Assert.Equal("string const", x.Value);
                    Assert.Equal(typeof(string).Name, x.PropertyType);
                    Assert.Equal(typeof(string).FullName, x.PropertyTypeFullName);
                });            
        }
    }
}
