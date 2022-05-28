using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Visma_s_Internal_Meetings
{
    class FileWriter
    {
        private static JsonSerializerOptions options = new JsonSerializerOptions() 
        {
            WriteIndented = true,
        };
        public static void AppendToFile(string path, object obj)
        {
            List<Meeting> meetings = ReadFromFile(path);
            meetings.Add((Meeting)obj);

            string jsonString = JsonSerializer.Serialize(meetings, options);
            File.WriteAllText(path, jsonString);
        }

        public static List<Meeting> ReadFromFile(string path)
        {
            List<Meeting> meetings = new List<Meeting>();
            string jsonString = null;

            try
            {
                jsonString = File.ReadAllText(path);
            }
            catch (Exception)
            {
                return null;
            }
            
            if(string.IsNullOrEmpty(jsonString))
            {
                return meetings;
            }

            meetings = JsonSerializer.Deserialize<List<Meeting>>(jsonString);
            return meetings;
        }
    }
    
}
