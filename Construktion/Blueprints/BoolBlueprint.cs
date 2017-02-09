﻿namespace Construktion.Blueprints
{
    public class BoolBlueprint : Blueprint
    {
        private bool value = false;

        public bool Matches(ConstruktionContext context)
        {
            return context.RequestType == typeof(bool);
        }

        public object Build(ConstruktionContext context, ConstruktionPipeline pipeline)
        {
            value = !value;

            return value;
        }
    }
}