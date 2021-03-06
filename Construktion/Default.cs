﻿namespace Construktion
{
    using System.Collections.Generic;
    using Blueprints;
    using Blueprints.Recursive;
    using Blueprints.Simple;

    internal static class Default
    {
        public static List<Blueprint> Blueprints => new List<Blueprint>
        {
            new StringPropertyBlueprint(),
            new StringBlueprint(),
            new NumericBlueprint(),
            new CharBlueprint(),
            new GuidBlueprint(),
            new BoolBlueprint(),
            new TimespanBlueprint(),
            new DictionaryBlueprint(),
            new EnumerableBlueprint(),
            new ArrayBlueprint(),
            new EnumBlueprint(),
            new DateTimeBlueprint(),
            new NullableTypeBlueprint(),
            new EmptyCtorBlueprint(),
            new NonEmptyCtorBlueprint(),
            new InterfaceBlueprint(),
            new DefensiveBlueprint()
        };

        public static ConstruktionPipeline Pipeline => new DefaultConstruktionPipeline(Blueprints);
    }
}
