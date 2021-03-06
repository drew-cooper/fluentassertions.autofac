using Autofac;
using Xunit;
using Module = Autofac.Module;

namespace FluentAssertions.Autofac
{
    // ReSharper disable InconsistentNaming
    public class MockContainerBuilderAssertions_Should
    {
        [Fact]
        public void Support_testing_assembly_modules_registrations()
        {
            var sut = new MockContainerBuilder();

            var assembly = typeof(MockContainerBuilderAssertions_Should)
                .Assembly;
            sut.RegisterAssemblyModules(assembly);

            sut.Should().RegisterAssemblyModules(assembly);
            sut.Should().RegisterModule<SampleModule>();
            sut.Should().RegisterModule<SampleModule2>();

#pragma warning disable 618
            sut.Should().RegisterModulesIn(assembly);
#pragma warning restore 618
        }

        [Fact]
        public void Support_testing_module_registration()
        {
            var builder = new MockContainerBuilder();
            builder.RegisterModule<SampleModule>();

            var builderShould = builder.Should();
            builderShould.RegisterModule<SampleModule>();
            builderShould.RegisterModule(typeof(SampleModule));

            builderShould.RegisterModule<SampleModule2>();
        }

        public class SampleModule : Module
        {
            protected override void Load(ContainerBuilder builder)
            {
                builder.RegisterModule<SampleModule2>();
            }
        }

        public class SampleModule2 : Module { }
    }
}
