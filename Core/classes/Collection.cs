using System;

namespace OmegaConfig.Core
{

    /// <summary>
    /// Define a collection to which an article belongs to. 
    /// </summary>
    public class Collection
    {
        private string _id;
        private string _name;

        ///<summary>
        /// Create a new collection.
        ///</summary>
        ///<param name="id">The identifier code of the collection.</param>
        ///<param name="name">The visible name of the collection.</param>
        public Collection(string id, string name)
        {
            if (String.IsNullOrWhiteSpace(_id) || String.IsNullOrWhiteSpace(name))
            {
                throw new FormatException();
            }
            else
            {
                this._id = id;
                this._name = name;
            }
        }

        /// <value>Gets or sets the name of the collection.</value>
        public string Name
        {
            get => _name;
            set => _name = value;
        }

    }
    
}