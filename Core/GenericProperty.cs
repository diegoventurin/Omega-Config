using System;
using System.Collections;

namespace OmegaConfig.Core
{

    /// <summary>
    /// A property of an article, belonging to a schema.
    /// </summary>
    public abstract class GenericProperty
    {
        public abstract string Name { get; }
        public abstract string Description { set;  get; }


    }
    
}