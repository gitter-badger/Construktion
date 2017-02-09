﻿namespace Construktion.Tests
{
    using Blueprints;
    using Shouldly;
    using Xunit;

    public class BoolBlueprintTests
    {
        [Fact]
        public void Should_Alternate_Values()
        {
            var blueprint = new BoolBlueprint();

            var result1 = (bool)blueprint.Build(new ConstruktionContext(typeof(bool)), Default.Pipeline);
            var result2 = (bool)blueprint.Build(new ConstruktionContext(typeof(bool)), Default.Pipeline);
            var result3 = (bool)blueprint.Build(new ConstruktionContext(typeof(bool)), Default.Pipeline);

            result1.ShouldBeTrue();
            result2.ShouldBeFalse();
            result3.ShouldBeTrue();
        }
    }
}