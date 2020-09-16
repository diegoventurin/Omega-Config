using System;
using System.Reflection;
using System.Resources;
using System.Threading;

namespace OmegaConfig.Core
{

    /// <summary>
    /// A property of an article, belonging to a schema.
    /// </summary>
    public class IntegerProperty : GenericProperty
    {
        // private fields
        private readonly string _name;
        private int _defaultValue;
        private int _currentValue;
        private int _upperBound;
        private int _lowerBound;
        private bool _required;

        /// <summary>
        /// Create a new property of integer type.
        /// </summary>
        /// <param name="name">The identifier name of the property.</param>
        public IntegerProperty(string name)
        {
            this._name = name;
            this._lowerBound = Int32.MinValue;
            this._upperBound = Int32.MaxValue;
            this._defaultValue = 0;
            this._currentValue = 0;
            this._required = false;
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

        /// <value>
        /// Gets or sets the lower bound of the property.
        /// </value>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown when the value is lower than variable limit, current upper bound, current value or default value.</exception>
        public int LowerBound
        {
            get => _lowerBound;
            set
            {
                if (value > _currentValue || value > _defaultValue)
                {
                    var resourceManager = new ResourceManager("Resources.ExceptionMessages", Assembly.GetExecutingAssembly());
                    throw new ArgumentOutOfRangeException(value.ToString(Thread.CurrentThread.CurrentCulture), resourceManager.GetString("ValueIncompatibleWithSetValues", Thread.CurrentThread.CurrentCulture));
                }
                else if (value > _upperBound)
                {
                    var resourceManager = new ResourceManager("Resources.ExceptionMessages", Assembly.GetExecutingAssembly());
                    throw new ArgumentOutOfRangeException(value.ToString(Thread.CurrentThread.CurrentCulture), resourceManager.GetString("ValueHigherThanUpperBound", Thread.CurrentThread.CurrentCulture));
                }
                else if (value < Int32.MinValue)
                {
                    var resourceManager = new ResourceManager("Resources.ExceptionMessages", Assembly.GetExecutingAssembly());
                    throw new ArgumentOutOfRangeException(value.ToString(Thread.CurrentThread.CurrentCulture), resourceManager.GetString("ValueOutOfBounds", Thread.CurrentThread.CurrentCulture));
                }
                else
                {
                    this._lowerBound = value;
                }
            }

        }

        /// <value>
        /// Gets or sets the upper limit of the property.
        /// </value>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown when the value is higher than variable limit, current lower bound, current value or default value.</exception>
        public int UpperBound
        {
            get => _upperBound;
            set
            {
                if (value < _currentValue || value < _defaultValue)
                {
                    var resourceManager = new ResourceManager("Resources.ExceptionMessages", Assembly.GetExecutingAssembly());
                    throw new ArgumentOutOfRangeException(value.ToString(Thread.CurrentThread.CurrentCulture), resourceManager.GetString("ValueIncompatibleWithSetValues", Thread.CurrentThread.CurrentCulture));
                }
                else if (value < _lowerBound)
                {
                    var resourceManager = new ResourceManager("Resources.ExceptionMessages", Assembly.GetExecutingAssembly());
                    throw new ArgumentOutOfRangeException(value.ToString(Thread.CurrentThread.CurrentCulture), resourceManager.GetString("ValueLowerThanLowerBound", Thread.CurrentThread.CurrentCulture));
                }
                else if (value > Int32.MaxValue)
                {
                    var resourceManager = new ResourceManager("Resources.ExceptionMessages", Assembly.GetExecutingAssembly());
                    throw new ArgumentOutOfRangeException(value.ToString(Thread.CurrentThread.CurrentCulture), resourceManager.GetString("ValueOutOfBounds", Thread.CurrentThread.CurrentCulture));
                }
                else
                {
                    this._upperBound = value;
                }
            }

        }

        /// <value>
        /// Gets or sets the default value of the property.
        /// </value>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown when the value is outside upper or lower bound.</exception>
        public int DefaultValue
        {
            get => _defaultValue;
            set
            {
                if (value < _lowerBound || value > _upperBound)
                {
                    var resourceManager = new ResourceManager("Resources.ExceptionMessages", Assembly.GetExecutingAssembly());
                    throw new ArgumentOutOfRangeException(value.ToString(Thread.CurrentThread.CurrentCulture), resourceManager.GetString("ValueOutOfBounds", Thread.CurrentThread.CurrentCulture));
                }
                else
                {
                    this._defaultValue = value;
                }
            }

        }

        /// <value>
        /// Gets or sets the current value of the property.
        /// </value>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown when the value is outside upper or lower bound.</exception>
        public int CurrentValue
        {
            get => _currentValue;
            set
            {
                if (value < _lowerBound || value > _upperBound)
                {
                    var resourceManager = new ResourceManager("Resources.ExceptionMessages", Assembly.GetExecutingAssembly());
                    throw new ArgumentOutOfRangeException(value.ToString(Thread.CurrentThread.CurrentCulture), resourceManager.GetString("ValueOutOfBounds", Thread.CurrentThread.CurrentCulture));
                }
                else
                {
                    this._currentValue = value;
                }
            }

        }

        /// <summary>
        /// Reset the current value to the default value.
        /// </summary>
        public void ResetToDefault()
        {
            this._currentValue = _defaultValue;
        }

        /// <summary>
        /// Create a string with the name of the property and its value, separeted by a colon.
        /// </summary>
        public override string ToString()
        {
            return $"{_name}: {_currentValue}";
        }

        /// <summary>
        /// Create a string with the name of the property and its value, in JSON format.
        /// </summary>
        public string ToJSON()
        {
            return $"\"{_name}\": {_currentValue}";
        }


    }
    
}