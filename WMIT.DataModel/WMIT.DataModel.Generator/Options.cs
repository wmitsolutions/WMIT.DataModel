using CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMIT.DataModel.Generator
{
    class Options
    {
        [Option('i', Required = true)]
        public string Input { get; set; }

        [Option('o', Required = true)]
        public string Output { get; set; }
    }
}
