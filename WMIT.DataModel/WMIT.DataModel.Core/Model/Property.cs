using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WMIT.DataModel.Core.Mapping;

namespace WMIT.DataModel.Core.Model
{
    public class Property
    {
        public string Name { get; set; }
        public string Type { get; set; }

        private static TypeScriptTypeMapper mapper = new TypeScriptTypeMapper();
        public static Property FromPropertyInfo(PropertyInfo propertyInfo)
        {
            var property = new Property();

            property.Name = propertyInfo.Name;
            property.Type = mapper.GetTypeName(propertyInfo.PropertyType);

            return property;
        }
    }
}
