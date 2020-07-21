using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace MountainDataSet.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var parser = new MountainDataParser();
            var mountains = parser.ParseData<List<MountainInfo>>();
            var serializedJson = JsonConvert.SerializeObject(mountains, Formatting.Indented);
            string fileName = Path.ChangeExtension(Path.GetTempFileName(), "json");
            File.WriteAllText(fileName, serializedJson);
            System.Console.WriteLine(fileName);
        }
    }
}
