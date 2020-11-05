using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection.Metadata;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace RockPaperScissors.ConsoleApp {

    // besides JSON, we commonly use XML to store data
    // in .NET for XML, we can use...
    // - DataContractSerializer (also supports JSON)
    // - XmlSerializer (quite old, doesn't support generics)

    public class JsonFilePersistence {

        private readonly string _filePath;

        public JsonFilePersistence(string filePath) {
            _filePath = filePath;
        }
        public ScoreTracker Read() {
            string json;
            try {
                json = File.ReadAllText(_filePath);
            } catch (IOException) {
                return new ScoreTracker();
            }
            ScoreTracker data = JsonSerializer.Deserialize<ScoreTracker>(json);
            return data;
        }

        public void Write(ScoreTracker data) {
            // ways to work with JSON in .NET
            // - DataContractSerializer (built-in, semi-old)
            // - System.Text.Json (built-in, new, fast)
            // - Newtonsoft.Json (aka JSON.NET, very popular 3rd party library)

            string json = JsonSerializer.Serialize(data);

            File.WriteAllText(_filePath, json);
        }
    }
}
