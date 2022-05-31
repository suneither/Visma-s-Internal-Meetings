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
        public static void AppendMeeting(string path, object obj)
        {
            List<Meeting> meetings = GetMeetings(path);
            if(meetings == null) meetings = new List<Meeting>();
            meetings.Add((Meeting)obj);

            string jsonString = JsonSerializer.Serialize(meetings, options);
            File.WriteAllText(path, jsonString);
        }
        public static List<Meeting> GetMeetings(string path)
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
                return null;
            }

            meetings = JsonSerializer.Deserialize<List<Meeting>>(jsonString);
            return meetings;
        }

        public static User GetAttendeeById(string path, int responsiblePersId)
        {
            return GetAttendees(path).Where(attend => attend.Id == responsiblePersId).First();
        }

        public static void AppendUser(string path, object obj)
        {
            List<User> attendees = GetAttendees(path);
            if (attendees == null) attendees = new List<User>();
            attendees.Add((User)obj);

            string jsonString = JsonSerializer.Serialize(attendees, options);
            File.WriteAllText(path, jsonString);
        }
        public static List<User> GetAttendees(string path)
        {
            string jsonString = null;

            try
            {
                jsonString = File.ReadAllText(path);
            }
            catch (Exception)
            {
                return null;
            }

            if (string.IsNullOrEmpty(jsonString))
            {
                return null;
            }

            return JsonSerializer.Deserialize<List<User>>(jsonString);
        }

        public static void UpdateMeetings(string path, List<Meeting> meetings)
        {
            string jsonString = JsonSerializer.Serialize(meetings, options);
            File.WriteAllText(path, jsonString);
        }
    }

  


}
