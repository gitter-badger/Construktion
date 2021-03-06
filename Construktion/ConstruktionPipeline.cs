﻿namespace Construktion
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Blueprints;

    public interface ConstruktionPipeline
    {
        /// <summary>
        /// Send a request through the pipeline to be constructed.
        /// </summary>
        /// <param name="requestContext"></param>
        /// <returns></returns>
        object Send(ConstruktionContext requestContext);
    }

    internal class DefaultConstruktionPipeline : ConstruktionPipeline
    {
        private readonly IEnumerable<Blueprint> _blueprints;
        private readonly List<Type> _underConstruction = new List<Type>();
        private readonly int _limit;

        public DefaultConstruktionPipeline(IEnumerable<Blueprint> blueprints)
        {
            _blueprints = blueprints;
        }

        public DefaultConstruktionPipeline(IEnumerable<Blueprint> blueprints, int recurrsionDepth)
        {
            _blueprints = blueprints;
            _limit = recurrsionDepth;
        }

        public object Send(ConstruktionContext requestContext)
        {
            var blueprint = _blueprints.First(x => x.Matches(requestContext));

            var result = Construct(requestContext, blueprint);

            return result;
        }

        private object Construct(ConstruktionContext requestContext, Blueprint blueprint)
        {
            var depth = _underConstruction.Count(x => requestContext.RequestType == x);

            if (depth > _limit)
                return default(object);

            _underConstruction.Add(requestContext.RequestType);

            var result = blueprint.Construct(requestContext, this);

            _underConstruction.Remove(requestContext.RequestType);

            return result;
        }
    }
}
