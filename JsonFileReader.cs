using System;
using System.IO;

namespace eRejestracjaCovid19
{
    public static class JsonFileReader
    {
        public static string Read(string nameFile)
        {
            var jsonPath = Path.Combine(Environment.CurrentDirectory, nameFile);
            var json = File.ReadAllText(jsonPath);
            return json;
        }
    }
}