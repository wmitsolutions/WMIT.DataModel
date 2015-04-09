using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMIT.DataModel.Core.Model
{
    public class Entity
    {
        public string Name { get; set; }
        public string BaseType { get; set; }

        public List<Property> Properties { get; set; }
    }
}
