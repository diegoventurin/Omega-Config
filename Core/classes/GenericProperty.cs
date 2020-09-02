using System;
using System.Collections;

namespace OmegaConfig.Core
{

    /// <summary>
    /// A property of an article, belonging to a schema.
    /// </summary>
    public class GenericProperty
    {
        private readonly string _name;

        /// <value>Gets the name of the property.</value>
        public string Name
        {
            get
            {
                return _name;
            }

        }


    }
    
}