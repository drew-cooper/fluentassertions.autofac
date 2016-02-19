﻿using System;
using Autofac;
using NEdifis.Attributes;
using NSubstitute;
using NUnit.Framework;

namespace FluentAssertions.Autofac
{
    [TestFixtureFor(typeof(AutofacAssertionExtensions))]
    // ReSharper disable InconsistentNaming
    internal class AutofacAssertionExtensions_Should
    {
        [Test]
        public void Provide_builder_extension()
        {
            var builder = new MockContainerBuilder();
            builder.ShouldHave().Should().BeOfType<MockContainerBuilderAssertions>();
        }

        [Test]
        public void Provide_register_extension()
        {
            var container = new ContainerBuilder().Build();
            container.ShouldHave().Should().BeOfType<ContainerRegistrationAssertions>();
        }

        [Test]
        public void Provide_resolve_extension()
        {
            var builder = new ContainerBuilder();
            builder.RegisterInstance(Substitute.For<IDisposable>());
            var container = builder.Build();
            container.ShouldResolve<IDisposable>().Should().BeOfType<ResolveAssertions<IDisposable>>();
        }
    }
}