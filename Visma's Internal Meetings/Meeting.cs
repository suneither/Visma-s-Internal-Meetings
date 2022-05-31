using System;
using System.Collections.Generic;

namespace Visma_s_Internal_Meetings
{
    public class Meeting
    {
        public static readonly List<string> s_categories = new List<string>()
        {
            "CodeMonkey",
            "Hub",
            "Short",
            "TeamBuilding"
        };

        public static readonly List<string> s_types = new List<string>()
        {
            "Live",
            "InPerson"
        };

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ResponsiblePersId { get; set; }
        public string Category { get; set; }
        public string Type { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<int> AttendeesIds { get; set; } 
        public void Print()
        {
            Console.WriteLine("name: " + Name);
            Console.WriteLine("description: " + Description);
            User user = FileWriter.GetAttendeeById(UserAuthorization.s_usersPath, ResponsiblePersId);
            Console.WriteLine("responsible Person: " + user.Nickname);
            Console.WriteLine("category:" + Category);
            Console.WriteLine("type: " + Type);
            Console.WriteLine("startDate: " + StartDate);
            Console.WriteLine("endDate: " + EndDate);
            Console.WriteLine("attendees: " + AttendeesIds.Count);
        }

        public void AddAttendee(User attendee)
        {
            if (attendee == null) return;
            if (AttendeesIds == null) AttendeesIds = new List<int>();

            AttendeesIds.Add(attendee.Id);
        }
    }
}
