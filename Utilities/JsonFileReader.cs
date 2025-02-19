using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Utilities
{
    public class JsonFileReader
    {
        // Base path for JSON files (can be modified as per your project structure)
        private readonly string jsonDirectory;

        // Constructor to initialize the base path for JSON files
        public JsonFileReader(string basePath = null)
        {
            string relativePath = Path.Combine("TestData");
            jsonDirectory = basePath ?? Path.Combine(Directory.GetCurrentDirectory(), relativePath);
        }

        // Method to read a JSON file by filename and return a JObject
        public JObject ReadJsonFile(string fileName)
        {
            // Ensure the filename ends with ".json"
            if (!fileName.EndsWith(".json"))
            {
                fileName += ".json";
            }

            // Combine the base directory with the filename to get the full path
            string filePath = Path.Combine(jsonDirectory, fileName);

            // Check if the file exists
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"JSON file '{fileName}' not found in path '{jsonDirectory}'.");
            }

            try
            {
                // Read the entire JSON file as a string
                string jsonContent = File.ReadAllText(filePath);

                // Parse the string into a JObject and return
                return JObject.Parse(jsonContent);
            }
            catch (Exception ex)
            {
                // Catch any errors during file reading or JSON parsing and throw a new exception
                throw new Exception($"Error reading or parsing JSON file '{fileName}': {ex.Message}", ex);
            }
        }

        // Method to read a JSON file as a string (useful if you need raw text)
        public string ReadJsonFileAsString(string fileName)
        {
            // Ensure the filename ends with ".json"
            if (!fileName.EndsWith(".json"))
            {
                fileName += ".json";
            }

            // Combine the base directory with the filename to get the full path
            string filePath = Path.Combine(jsonDirectory, fileName);

            // Check if the file exists
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"JSON file '{fileName}' not found in path '{jsonDirectory}'.");
            }

            try
            {
                // Read and return the entire JSON file as a string
                return File.ReadAllText(filePath);
            }
            catch (Exception ex)
            {
                // Catch any errors during file reading and throw a new exception
                throw new Exception($"Error reading JSON file '{fileName}': {ex.Message}", ex);
            }
        }
    }
}
