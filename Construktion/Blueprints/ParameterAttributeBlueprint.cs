﻿namespace Construktion.Blueprints
{
    using System;
    using System.Linq;
    using System.Reflection;

    /// <summary>
    /// Base class to construct parameters from an attribute.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ParameterAttributeBlueprint<T> : Blueprint where T : Attribute
    {
        protected readonly Func<T, object> _value;

        public ParameterAttributeBlueprint(Func<T, object> value)
        {
            value.GuardNull();

            _value = value;
        }

        /// <summary>
        /// The base implementation returns true if the parameter has the attribute.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public virtual bool Matches(ConstruktionContext context)
        {
            return context.ParameterInfo?.GetCustomAttributes(typeof(T))
                       .ToList()
                       .Any() ?? false;
        }

        /// <summary>
        /// Construct a parameter using its attribute's value.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="pipeline"></param>
        /// <returns></returns>
        public virtual object Construct(ConstruktionContext context, ConstruktionPipeline pipeline)
        {
            var attribute = (T)context.ParameterInfo.GetCustomAttribute(typeof(T));

            var value = _value(attribute);

            return value;
        }
    }
}