using System;

namespace OmegaConfig.Core
{

    public class Collection
    {
        private string _id;
        private string _name;

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

    }
    
}