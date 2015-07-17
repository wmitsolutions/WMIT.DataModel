using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMIT.DataModel.Core.Model;

namespace WMIT.DataModel.Generator
{
    class Program
    {
        static void Main(string[] args)
        {
            //var options = new Options();
            //var result = CommandLine.Parser.Default.ParseArguments(args, options);
            //if (result)
            //{
                
            //}

            var types = new Type[] { typeof(Person) };
            var schema = Schema.FromTypes(types);
        }
    }

    class Entity
    {
        public int Id { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
    }

    class Person : Entity
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
    }
}
