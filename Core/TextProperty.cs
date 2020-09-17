using System;
using System.Reflection;
using System.Resources;
using System.Threading;

namespace OmegaConfig.Core
{

    /// <summary>
    /// A property of an article, belonging to a schema.
    /// </summary>
    public class TextProperty : GenericProperty
    {

        // private fields
        private readonly string _name;
        private string _defaultText;
        private string _currentText;
        private int _maxLenght;
        private int _minLenght;
        private bool _required;

        /// <summary>
        /// Create a new property of text type.
        /// </summary>
        /// <param name="name">The identifier name of the property.</param>
        public TextProperty(string name)
        {
            this._name = name;
            this._required = false;
            this._defaultText = "";
            this._currentText = "";
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
        /// Gets or sets the minimum lenght of the string.
        /// </value>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown when the value is higher than the lenght of the max lenght, the current text or the default text, or is less then zero.</exception>
        public int MinLenght
        {
            get => _minLenght;
            set
            {
                if (value > _currentText.Length || value > _defaultText.Length)
                {
                    var resourceManager = new ResourceManager("Resources.ExceptionMessages", Assembly.GetExecutingAssembly());
                    throw new ArgumentOutOfRangeException(value.ToString(Thread.CurrentThread.CurrentCulture), resourceManager.GetString("ValueIncompatibleWithSetValues", Thread.CurrentThread.CurrentCulture));
                }
                else if (value > _maxLenght)
                {
                    var resourceManager = new ResourceManager("Resources.ExceptionMessages", Assembly.GetExecutingAssembly());
                    throw new ArgumentOutOfRangeException(value.ToString(Thread.CurrentThread.CurrentCulture), resourceManager.GetString("ValueHigherThanUpperBound", Thread.CurrentThread.CurrentCulture));
                }
                else if (value < 0)
                {
                    var resourceManager = new ResourceManager("Resources.ExceptionMessages", Assembly.GetExecutingAssembly());
                    throw new ArgumentOutOfRangeException(value.ToString(Thread.CurrentThread.CurrentCulture), resourceManager.GetString("ValueOutOfBounds", Thread.CurrentThread.CurrentCulture));
                }
                else
                {
                    this._minLenght = value;
                }
            }

        }

        /// <value>
        /// Gets or sets the maximum lenght of the string.
        /// </value>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown when the value is lower than the lenght of the minimum lenght, the current text or the default text.</exception>
        public int MaxLenght
        {
            get => _maxLenght;
            set
            {
                if (value < _currentText.Length || value < _defaultText.Length)
                {
                    var resourceManager = new ResourceManager("Resources.ExceptionMessages", Assembly.GetExecutingAssembly());
                    throw new ArgumentOutOfRangeException(value.ToString(Thread.CurrentThread.CurrentCulture), resourceManager.GetString("ValueIncompatibleWithSetValues", Thread.CurrentThread.CurrentCulture));
                }
                else if (value < _minLenght)
                {
                    var resourceManager = new ResourceManager("Resources.ExceptionMessages", Assembly.GetExecutingAssembly());
                    throw new ArgumentOutOfRangeException(value.ToString(Thread.CurrentThread.CurrentCulture), resourceManager.GetString("ValueLowerThanLowerBound", Thread.CurrentThread.CurrentCulture));
                }
                else
                {
                    this._maxLenght = value;
                }
            }

        }

        /// <value>
        /// Gets or sets the default text of the property.
        /// </value>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown when the lenght of the text is outside the limits.</exception>
        public string DefaultText
        {
            get => _defaultText;
            set
            {
                if (value is null)
                {
                    value = "";
                }
                if (value.Length < _minLenght || value.Length > _maxLenght)
                {
                    var resourceManager = new ResourceManager("Resources.ExceptionMessages", Assembly.GetExecutingAssembly());
                    throw new ArgumentOutOfRangeException(value.ToString(Thread.CurrentThread.CurrentCulture), resourceManager.GetString("ValueOutOfBounds", Thread.CurrentThread.CurrentCulture));
                }
                else
                {
                    this._defaultText = value;
                }
            }
        }

        /// <value>
        /// Gets or sets the current value of the property.
        /// </value>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown when the value is outside upper or lower bound.</exception>
        public string CurrentText
        {
            get => _currentText;
            set
            {
                if (value is null)
                {
                    value = "";
                }
                if (value.Length < _minLenght || value.Length > _maxLenght)
                {
                    var resourceManager = new ResourceManager("Resources.ExceptionMessages", Assembly.GetExecutingAssembly());
                    throw new ArgumentOutOfRangeException(value.ToString(Thread.CurrentThread.CurrentCulture), resourceManager.GetString("ValueOutOfBounds", Thread.CurrentThread.CurrentCulture));
                }
                else
                {
                    this._currentText = value;
                }
            }

        }

        /// <summary>
        /// Reset the current value to the default value.
        /// </summary>
        public void ResetToDefault()
        {
            this._currentText = _defaultText;
        }

        /// <summary>
        /// Create a string with the name of the property and its value, separeted by a colon.
        /// </summary>
        public override string ToString()
        {
            return $"{_name}: {_currentText}";
        }

        /// <summary>
        /// Create a string with the name of the property and its value, in JSON format.
        /// </summary>
        public string ToJSON()
        {
            return $"\"{_name}\": \"{_currentText}\"";
        }

    }

}