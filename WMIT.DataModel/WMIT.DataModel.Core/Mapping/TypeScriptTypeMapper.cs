using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMIT.DataModel.Core.Mapping
{
    public class TypeScriptTypeMapper : ITypeMapper
    {
        public Dictionary<Type, string> Mappings { get; set; }

        private const string DEFAULT_NUMBER_TYPE = "number";
        private const string DEFAULT_STRING_TYPE = "string";
        private const string DEFAULT_BOOLEAN_TYPE = "bool";
        private const string DEFAULT_DATETIME_TYPE = "Date";

        private const string DEFAULT_FALLBACK_TYPE = "any";

        public TypeScriptTypeMapper()
        {
            this.Mappings = new Dictionary<Type, string>()
            {
                 { typeof(string), DEFAULT_STRING_TYPE },

                 { typeof(int), DEFAULT_NUMBER_TYPE },
                 { typeof(Int16), DEFAULT_NUMBER_TYPE },
                 { typeof(Int64), DEFAULT_NUMBER_TYPE },
                 { typeof(decimal), DEFAULT_NUMBER_TYPE },
                 { typeof(float), DEFAULT_NUMBER_TYPE },
                 { typeof(double), DEFAULT_NUMBER_TYPE },

                 { typeof(bool), DEFAULT_BOOLEAN_TYPE },

                 { typeof(DateTime), DEFAULT_DATETIME_TYPE },
                 { typeof(DateTimeOffset), DEFAULT_DATETIME_TYPE }
            };
        }

        public string GetTypeName<T>()
        {
            return GetTypeName(typeof(T));
        }

        public string GetTypeName(Type type, string fallback = DEFAULT_FALLBACK_TYPE)
        {
            string result = fallback;

            if (this.Mappings.TryGetValue(type, out result))
            {
                return result;
            }
            else
            {
                if (type.IsArray)
                {
                    // Arrays
                    Type elementType = type.GetElementType();
                    result = GetTypeName(elementType, fallback);
                    result = string.Format("{0}[]", result);
                }
                else if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
                {
                    // Nullable types
                    Type elementType = type.GetGenericArguments().First();
                    result = GetTypeName(elementType, fallback);
                    result = string.Format("{0}?", result);
                }
                else if (type.IsGenericType && type.GetInterface(typeof(IEnumerable).Name) != null)
                {
                    // Collection types
                    Type elementType = type.GetGenericArguments().First();
                    result = GetTypeName(elementType, fallback);
                    result = string.Format("{0}[]", result);
                }
                else if (type.IsClass)
                {
                    // Classes
                    result = type.Name;
                }
                else if (type.IsValueType && !type.IsEnum)
                {
                    // Structs
                    result = type.Name;
                }
                else if (type.IsValueType && type.IsEnum)
                {
                    // Enums
                    result = type.Name;
                }
            }

            return result;
        }
    }
}
