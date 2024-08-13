using System;
using Xunit;

namespace DeveloperSample.Container
{
    internal interface IContainerTestInterface
    {
    }

    internal class ContainerTestClass : IContainerTestInterface
    {
    }
     
    public class ContainerTest
    {
        [Fact]
        public void CanBindAndGetService()
        {
            var container = new Container();
            container.Bind(typeof(IContainerTestInterface), typeof(ContainerTestClass));
            var testInstance = container.Get<IContainerTestInterface>();
            Assert.IsType<ContainerTestClass>(testInstance);
        }

        // Need to add a test for the case when the type does not exist
        [Fact]
        public void Get_ThrowsExceptionWhenTypeNotMapped()
        {
            var container = new Container();
            Assert.Throws<InvalidOperationException>(() => container.Get<IContainerTestInterface>());
        }

        [Fact]
        public void Bind_ThrowsExceptionWhenTypeAlreadyMapped()
        {
            var container = new Container();
            container.Bind(typeof(IContainerTestInterface), typeof(ContainerTestClass));
            Assert.Throws<ArgumentException>(() => container.Bind(typeof(IContainerTestInterface), typeof(ContainerTestClass))
            );
        }
    }
}