using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMIT.DataModel.Core.Mapping
{
    public interface ITypeMapper
    {
        string GetTypeName(Type inputType, string fallback = null);
    }
}
