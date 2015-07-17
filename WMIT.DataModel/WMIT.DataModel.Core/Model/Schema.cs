using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WMIT.DataModel.Core.Model
{
    public class Schema
    {
        public List<Model> Models { get; set; }

        public Schema()
        {
            this.Models = new List<Model>();
        }

        public static Schema FromTypes(Type[] types)
        {
            var schema = new Schema();

            var models = types.Select(Model.FromType);
            schema.Models.AddRange(models);

            return schema;
        }

        public static Schema FromAssembly(Assembly assembly, Func<Type, bool> filter = null)
        {
            var types = assembly.GetExportedTypes();
            var filteredTypes = (filter != null) ? types.Where(filter) : types;

            return Schema.FromTypes(types);
        }
    }
}
