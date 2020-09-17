using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Resources;
using System.Threading;

namespace OmegaConfig.Core
{

    /// <summary>
    /// A property of an article, belonging to a schema.
    /// </summary>
    public class ListProperty : GenericProperty
    {

        // private fields
        private readonly string _name;
        private readonly SortedList<short, PropertyValue> _propertyValues;
        private PropertyValue _currentValue;
        private bool _required;

        /// <summary>
        /// Create a new property of text type.
        /// </summary>
        /// <param name="name">The identifier name of the property.</param>
        public ListProperty(string name)
        {
            this._name = name;
            this._required = false;
            this._propertyValues = new SortedList<short, PropertyValue>();
            this._currentValue = null;
        }

        /// <value>Gets the name of the property.</value>
        public override string Name
        {
            get
            {
                return _name;
            }
        }

        /// <value>Gets or sets the value of the required.</value>
        public bool Required
        {
            set
            {
                _required = value;
            }
            get
            {
                return _required;
            }
        }

        /// <summary>
        /// Reset the current value to the default value.
        /// </summary>
        public void ResetToDefault()
        {
            this._currentValue = null;
        }

        /// <value>Add a new value to the property.</value>
        /// <exception cref="System.ArgumentException">Sequence or value name are already used.</exception>
        /// <exception cref="System.NullReferenceException">Property is null.</exception>
        public void AddValue(short sequence, PropertyValue value)
        { 
            if (value is null)
            {
                var resourceManager = new ResourceManager("Resources.ExceptionMessages", Assembly.GetExecutingAssembly());
                throw new ArgumentNullException(nameof(value), resourceManager.GetString("PropertyIsNull", Thread.CurrentThread.CurrentCulture));
            }

            if (_propertyValues.ContainsKey(sequence))
            {
                bool found = false;
                foreach (PropertyValue val in _propertyValues.Values)
                {
                    if (val.Name == value.Name)
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
                    _propertyValues.Add(sequence, value);
                }
            }
            else
            {
                var resourceManager = new ResourceManager("Resources.ExceptionMessages", Assembly.GetExecutingAssembly());
                throw new ArgumentException(sequence.ToString(Thread.CurrentThread.CurrentCulture), resourceManager.GetString("DuplicatedSequence", Thread.CurrentThread.CurrentCulture));
            }
        }

        /// <summary>
        /// Create a string with the name of the property and its value, separeted by a colon.
        /// </summary>
        public override string ToString()
        {
            return $"{_name}: {_currentValue.Name}";
        }

        /// <summary>
        /// Create a string with the name of the property and its value, in JSON format.
        /// </summary>
        public string ToJSON()
        {
            return $"\"{_name}\": \"{_currentValue.Name}\"";
        }


    }
    
}