using System;
using System.Collections;
using System.ComponentModel; 
using System.Diagnostics.CodeAnalysis;

namespace OmegaConfig.Core
{

    public class PropertyValue
    {
        // private fields
        private readonly string _name;
        private string _description;

        /// <summary>
        /// Create a new value for a property.
        /// </summary>
        /// <param name="name">The identifier name of the property.</param>
        /// <param name="description">A culture indipendent decription of the property value.</param>
        public PropertyValue(string name, string description)
        {
            this._name = name;
            this._description = description;
        }

        /// <summary>
        /// Create a new value for a property.
        /// </summary>
        /// <param name="name">The identifier name of the property.</param>
        public PropertyValue(string name) : this(name, "")
        {
        }

        /// <value>Gets the name of the property.</value>
        public string Name
        {
            get
            {
                return _name;
            }

        }

        /// <value>Gets the name of the description.</value>
        public string Description
        {
            set
            {
                this._description = value;
            }
            get
            {
                return _description;
            }

        }



    }
    
}