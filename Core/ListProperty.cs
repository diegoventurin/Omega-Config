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
        private string _description;
        private readonly SortedList<short, PropertyValue> _propertyValues;
        private PropertyValue _defaultValue;
        private PropertyValue _currentValue;
        private bool _required;

        /// <summary>
        /// Create a new property of list type.
        /// </summary>
        /// <param name="name">The identifier name of the property.</param>
        /// <param name="description">A culture indipendent decription of the property.</param>
        public ListProperty(string name, string description)
        {
            this._name = name;
            this._description = description;
            this._required = false;
            this._propertyValues = new SortedList<short, PropertyValue>();
            this._defaultValue = null;
            this._currentValue = null;
        }

        /// <summary>
        /// Create a new property of list type.
        /// </summary>
        /// <param name="name">The identifier name of the property.</param>
        public ListProperty(string name) : this(name, "")
        {
        }

        /// <value>Gets the name of the property.</value>
        public override string Name
        {
            get
            {
                return _name;
            }
        }

        /// <value>Gets the name of the description.</value>
        public override string Description
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
        /// If a default value is not set, current value will be null.
        /// </summary>
        public void ResetToDefault()
        {
            if (_defaultValue is null)
            {
                _currentValue = null;
            }
            else
            {
                _currentValue = _defaultValue;
            }
                
        }

        /// <value>Add a new value to the property.</value>
        /// <param name="sequence">The sequence for the property.</param>
        /// <param name="value">The property value to be inserted.</param>
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

        /// <value>Set the current value for the property.</value>
        /// <param name="value">The property value that will become the current value.</param>
        /// <exception cref="System.ArgumentException">Property Value doesn't belong to the property.</exception>
        /// <exception cref="System.NullReferenceException">Property is null.</exception>
        public void SetCurrentValue(PropertyValue value)
        {
            if (value is null)
            {
                var resourceManager = new ResourceManager("Resources.ExceptionMessages", Assembly.GetExecutingAssembly());
                throw new ArgumentNullException(nameof(value), resourceManager.GetString("PropertyIsNull", Thread.CurrentThread.CurrentCulture));
            }
            else if (_propertyValues.ContainsValue(value))
            {
                _currentValue = value;
            }
            else
            {
                var resourceManager = new ResourceManager("Resources.ExceptionMessages", Assembly.GetExecutingAssembly());
                throw new ArgumentException(value.Name, resourceManager.GetString("PropertyValueNotFound", Thread.CurrentThread.CurrentCulture));
            }
        }

        /// <value>Set the current value for the property.</value>
        /// <param name="name">The name of the property value that will become the current value.</param>
        /// <exception cref="System.ArgumentException">Property Value doesn't belong to the property.</exception>
        public void SetCurrentValue(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                var resourceManager = new ResourceManager("Resources.ExceptionMessages", Assembly.GetExecutingAssembly());
                throw new ArgumentNullException(nameof(name), resourceManager.GetString("ValueNotValid", Thread.CurrentThread.CurrentCulture));
            }
            else
            {
                bool found = false;
                PropertyValue pValue;
                pValue = null;
                
                foreach (PropertyValue value in _propertyValues.Values)
                {
                    if (value.Name == name)
                    {
                        found = true;
                        pValue = value;
                        break;

                    }
                }

                if (found && !(pValue is null))
                {
                    _currentValue = pValue;
                }
                else
                {
                    var resourceManager = new ResourceManager("Resources.ExceptionMessages", Assembly.GetExecutingAssembly());
                    throw new ArgumentException(name, resourceManager.GetString("PropertyValueNotFound", Thread.CurrentThread.CurrentCulture));
                }
            }
        }

        /// <value>Set the default value for the property.</value>
        /// <param name="value">The property value that will become the deafult value.</param>
        /// <exception cref="System.ArgumentException">Property Value doesn't belong to the property.</exception>
        /// <exception cref="System.NullReferenceException">Property is null.</exception>
        public void SetDefaultValue(PropertyValue value)
        {
            if (value is null)
            {
                var resourceManager = new ResourceManager("Resources.ExceptionMessages", Assembly.GetExecutingAssembly());
                throw new ArgumentNullException(nameof(value), resourceManager.GetString("PropertyIsNull", Thread.CurrentThread.CurrentCulture));
            }
            else if (_propertyValues.ContainsValue(value))
            {
                _defaultValue = value;
            }
            else
            {
                var resourceManager = new ResourceManager("Resources.ExceptionMessages", Assembly.GetExecutingAssembly());
                throw new ArgumentException(value.Name, resourceManager.GetString("PropertyValueNotFound", Thread.CurrentThread.CurrentCulture));
            }
        }

        /// <value>Set the default value for the property.</value>
        /// <param name="name">The name of the property value that will become the default value.</param>
        /// <exception cref="System.ArgumentException">Property Value doesn't belong to the property.</exception>
        public void SetDefaultValue(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                var resourceManager = new ResourceManager("Resources.ExceptionMessages", Assembly.GetExecutingAssembly());
                throw new ArgumentNullException(nameof(name), resourceManager.GetString("ValueNotValid", Thread.CurrentThread.CurrentCulture));
            }
            else
            {
                bool found = false;
                PropertyValue pValue;
                pValue = null;

                foreach (PropertyValue value in _propertyValues.Values)
                {
                    if (value.Name == name)
                    {
                        found = true;
                        pValue = value;
                        break;

                    }
                }

                if (found && !(pValue is null))
                {
                    _defaultValue = pValue;
                }
                else
                {
                    var resourceManager = new ResourceManager("Resources.ExceptionMessages", Assembly.GetExecutingAssembly());
                    throw new ArgumentException(name, resourceManager.GetString("PropertyValueNotFound", Thread.CurrentThread.CurrentCulture));
                }
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