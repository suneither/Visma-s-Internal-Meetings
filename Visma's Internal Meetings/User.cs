using System;
using System.Collections.Generic;

namespace Visma_s_Internal_Meetings
{
    public class User
    {
        public int Id { get; set; }
        public string Nickname { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public List<Tuple<int, DateTime>> MeetingTime { get; set; } = null;

        public void Print()
        {
            Console.WriteLine($"{Nickname} {Name} {Surname}");
        }

        public void AddMeetingAndTime(Meeting meeting, DateTime dateTime)
        {
            if(MeetingTime == null) 
                MeetingTime = new List<Tuple<int, DateTime>>();

            MeetingTime.Add(new Tuple<int, DateTime>(meeting.Id, dateTime));
        }
    }
}