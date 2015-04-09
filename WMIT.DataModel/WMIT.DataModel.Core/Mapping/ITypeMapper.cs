using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMIT.DataModel.Core.Mapping
{
    /// <summary>
    /// Represents an interface for a basic type mapper implementation.
    /// </summary>
    public interface ITypeMapper
    {
        /// <summary>
        /// Get a result type name from an input type.
        /// </summary>
        /// <param name="inputType">The input type which is going to be resolved.</param>
        /// <param name="fallback">A fallback value which gets returned when no type mapping could be resolved.</param>
        /// <returns></returns>
        string GetTypeName(Type inputType, string fallback = null);
    }
}
