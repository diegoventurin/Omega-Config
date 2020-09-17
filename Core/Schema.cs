using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Threading;

namespace OmegaConfig.Core
{
    /// <summary>
    /// A schema that contains the properties and rules for a configurable article.
    /// Schema is mandatory for configurable articles.
    /// </summary>
    public class Schema
    {

        // private fields
        private readonly string _name;
        private readonly SortedList<short, GenericProperty> _properties;

        /// <summary>
        /// Create a new schema.
        /// </summary>
        /// <param name="name">The name of the schema.</param>
        public Schema(string name)
        {
            _name = name;
            _properties = new SortedList<short, GenericProperty>();    
        }

        /// <value>Gets the name of the schema.</value>
        public string Name
        {
            get
            {
                return _name;
            }

        }

        /// <value>Add a new property to the schema.</value>
        /// <exception cref="System.ArgumentException">Sequence or property name are already used.</exception>
        /// <exception cref="System.NullReferenceException">Property is null.</exception>
        public void AddProperty(short sequence, GenericProperty property)
        {
            if (property is null)
            {
                var resourceManager = new ResourceManager("Resources.ExceptionMessages", Assembly.GetExecutingAssembly());
                throw new ArgumentNullException(nameof(property), resourceManager.GetString("PropertyIsNull", Thread.CurrentThread.CurrentCulture));
            }

            if (_properties.ContainsKey(sequence))
            {
                bool found = false;
                foreach (GenericProperty prop in _properties.Values)
                {
                    if (prop.Name == property.Name)
                    {
                        found = true;
                        break;
                    }
                }

                if (found)
                {
                    var resourceManager = new ResourceManager("Resources.ExceptionMessages", Assembly.GetExecutingAssembly());
                    throw new ArgumentException(sequence.ToString(Thread.CurrentThread.CurrentCulture), resourceManager.GetString("DuplicatedPropertyName", Thread.CurrentThread.CurrentCulture));
                }
                else
                {
                    _properties.Add(sequence, property);
                }
            }
            else
            {
                var resourceManager = new ResourceManager("Resources.ExceptionMessages", Assembly.GetExecutingAssembly());
                throw new ArgumentException(sequence.ToString(Thread.CurrentThread.CurrentCulture), resourceManager.GetString("DuplicatedSequence", Thread.CurrentThread.CurrentCulture));
            }

        }

    }
    
}