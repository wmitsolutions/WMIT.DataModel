using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WMIT.DataModel.Core.Model
{
    public class Model
    {
        public string Name { get; set; }
        public string Inherits { get; set; }

        public List<Property> Properties { get; set; }

        public Model()
        {
            this.Properties = new List<Property>();
        }

        public static Model FromType(Type type)
        {
            var model = new Model();

            model.Name = type.Name;
            model.Inherits = (type.BaseType != typeof(object)) ? type.BaseType.Name : null;

            var properties = type.GetProperties(BindingFlags.Instance | BindingFlags.Public);
            var modelProperties = properties.Select(Property.FromPropertyInfo);

            model.Properties.AddRange(modelProperties);

            return model;
        }
    }
}
