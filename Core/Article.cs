using System;
using System.Reflection;
using System.Resources;
using System.Threading;

namespace OmegaConfig.Core
{
    /// <summary>
    /// An article. It can be configurable or not.
    /// </summary>
    public class Article
    {
        // private fields
        private readonly string _code;

        private ArtSchema _schema;
        private bool _configurable;

        private string _series;
        private string _class1;
        private string _class2;
        private string _class3;
        private string _class4;
        private string _class5;

        private double _lenght;
        private double _width;
        private double _height;
        private double _weight;

        /// <summary>
        /// Create a non-configurable article.
        /// </summary>
        /// <param name="code">The identifier code of the article.</param>
        public Article(string code)
        {
            this._code = code;
            this._configurable = false;
            this._schema = null;
            SetDefaultValues();
        }

        /// <summary>
        /// Create a configurable article.
        /// </summary>
        /// <param name="code">The identifier code of the article.</param>
        /// <param name="schema">The schema of the configuration properties.</param>
        public Article(string code, ArtSchema schema)
        {
            this._code = code;
            this._schema = schema;
            this._configurable = true;
            SetDefaultValues();
        }

        /// <value>Gets the article code.</value>
        public string Code { get => _code;}

        /// <value>Gets or sets the collection.</value>
        public string Series
        {
            get => _series;
            set => _series = value;
        }

        /// <value>Gets or sets the current configuration.</value>
        public ArtSchema Schema
        {
            get => _schema;
        }

        /// <value>Get the classification strings.</value>
        public string[] GetClassification()
        {
            return new string[] {_class1, _class2, _class3, _class4, _class5};
        }

        /// <value>Gets or sets the lenght. Value must be 0 or positive.</value>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown when value is less than zero.</exception>
        public double Lenght
        {
            get => _lenght;
            set
            {
                if (value >= 0)
                {
                    _lenght = value;
                }
                else
                {
                    var resourceManager = new ResourceManager("Resources.ExceptionMessages", Assembly.GetExecutingAssembly());
                    throw new ArgumentOutOfRangeException(value.ToString(Thread.CurrentThread.CurrentCulture), resourceManager.GetString("ValueMustBeEqualOrGreaterThanZero", Thread.CurrentThread.CurrentCulture));
                }
            }
        }

        /// <value>Gets or sets the width. Value must be 0 or positive.</value>
        public double Width
        {
            get => _width;
            set
            {
                if (value >= 0)
                {
                    _width = value;
                }
                else
                {
                    var resourceManager = new ResourceManager("Resources.ExceptionMessages", Assembly.GetExecutingAssembly());
                    throw new ArgumentOutOfRangeException(value.ToString(Thread.CurrentThread.CurrentCulture), resourceManager.GetString("ValueMustBeEqualOrGreaterThanZero", Thread.CurrentThread.CurrentCulture));
                }
            }
        }

        /// <value>Gets or sets the height. Value must be 0 or positive./value>
        public double Height
        {
            get => _height;
            set
            {
                if (value >= 0)
                {
                    _height = value;
                }
                else
                {
                    var resourceManager = new ResourceManager("Resources.ExceptionMessages", Assembly.GetExecutingAssembly());
                    throw new ArgumentOutOfRangeException(value.ToString(Thread.CurrentThread.CurrentCulture), resourceManager.GetString("ValueMustBeEqualOrGreaterThanZero", Thread.CurrentThread.CurrentCulture));
                }
            }
        }

        /// <value>Gets or sets the weight. Value must be 0 or positive.</value>
        public double Weight
        {
            get => _weight;
            set
            {
                if (value >= 0)
                {
                    _weight = value;
                }
                else
                {
                    var resourceManager = new ResourceManager("Resources.ExceptionMessages", Assembly.GetExecutingAssembly());
                    throw new ArgumentOutOfRangeException(value.ToString(Thread.CurrentThread.CurrentCulture), resourceManager.GetString("ValueMustBeEqualOrGreaterThanZero", Thread.CurrentThread.CurrentCulture));
                }
            }
        }

        /// <summary>
        /// Sets the article as configurable.
        /// </summary>
        /// <param name="schema">The schema used for configuration.</param>
        public void SetConfigurable(ArtSchema schema)
        {
            this._configurable = true;
            this._schema = schema;
        }

        /// <summary>
        /// Sets the article as configurable.
        /// </summary>
        /// <param name="schema">The schema used for configuration.</param>
        public bool IsConfigurable()
        {
            return _configurable;
        }

        /// <summary>
        /// Sets the article as non-configurable.
        /// </summary>
        /// <param name="schema">The schema used for configuration.</param>
        public void SetNotConfigurable()
        {
            this._configurable = false;
            this._schema = null;
        }

        /// <summary>
        /// Add classification fields to article.
        /// Can be used only for statistics.
        /// </summary>
        /// <param name="c1">First classificantion parameter (mandatory).</param>
        /// <param name="c2">Second classificantion parameter (optional).</param>
        /// <param name="c3">Third classificantion parameter (optional).</param>
        /// <param name="c4">Forth classificantion parameter (optional).</param>
        /// <param name="c5">Fifth classificantion parameter (optional).</param>
        public void AddClassification(string c1, string c2 = "", string c3 = "", string c4 = "", string c5 = "")
        {
            this._class1 = c1;
            this._class2 = c2;
            this._class3 = c3;
            this._class4 = c4;
            this._class5 = c5;
        }

        /// <summary>
        /// Set the default value for article.
        /// Used only by constructors.
        /// </summary>
        private void SetDefaultValues()
        {

            _series = "";
            _class1 = "";
            _class2 = "";
            _class3 = "";
            _class4 = "";
            _class5 = "";
            _lenght = 0;
            _width = 0;
            _height = 0;
            _weight = 0;

        }


    }
    
}