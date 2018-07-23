﻿using System;
using FluentAssertions;
using Xunit;
using static LanguageExt.UnitTesting.Tests.TestsHelper;

namespace LanguageExt.UnitTesting.Tests
{
    public class OptionExtensionsTests
    {
        [Fact]
        public void ShouldBeSome_GivenNone_Throws()
        {
            Action act = () => GetNone().ShouldBeSome(ValidationNoop);
            act.Should().Throw<Exception>().WithMessage("Expected Some, got None instead.");
        }

        [Fact]
        public void ShouldBeNone_GivenSome_Throws()
        {
            Action act = () => GetSome().ShouldBeNone();
            act.Should().Throw<Exception>().WithMessage("Expected None, got Some instead.");
        }

        [Fact]
        public void ShouldBeSome_GivenSome_RunsValidation()
        {
            var validationRan = false;
            GetSome().ShouldBeSome(x => validationRan = true);
            validationRan.Should().BeTrue();
        }

        [Fact]
        public void ShouldBeNone_GivenNone_DoesNotThrow() => GetNone().ShouldBeNone();

        private static Option<string> GetNone() => Option<string>.None;
        private static Option<string> GetSome() => "some";
    }
}
