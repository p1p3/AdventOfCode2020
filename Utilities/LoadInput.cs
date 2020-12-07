using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode2020.Utilities
{
    public static class LoadInput
    {
        public static IEnumerable<T> LoadInputData<T>(string path, Func<string, T> parseFunction)
        {
            return System.IO.File.ReadAllLines(path).Select(parseFunction);
        }
    }
}
