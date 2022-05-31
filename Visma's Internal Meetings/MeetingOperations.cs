using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visma_s_Internal_Meetings
{
    public class MeetingOperations
    {
        private static readonly string s_meetingPath = "meetings.txt";
        public static void CreateNewMeeting()
        {
            Meeting meeting = new Meeting();

            meeting.ResponsiblePersId = UserAuthorization.s_user.Id;

            bool creatingMeeting = true;

            while (creatingMeeting)
            {
                Console.Clear();
                Console.WriteLine("Enter -1 to exit meeting creation.");
                Console.WriteLine("Creating meeting step 1/7.");
                Console.WriteLine("Enter name.");

                string userInput = Console.ReadLine();

                if (string.IsNullOrEmpty(userInput)){
                    HelperClass.BadInput();
                    continue;
                }

                if(int.TryParse(userInput, out int output))
                {
                    if (output == -1)
                    {
                        creatingMeeting = false;
                        break;
                    }
                    else
                    {
                        HelperClass.BadInput();
                        continue;
                    }
                }

                meeting.Name = userInput;

                while (creatingMeeting)
                {
                    Console.Clear();
                    Console.WriteLine("Enter -1 to exit meeting creation.");
                    HelperClass.ShowBackOption();
                    Console.WriteLine("Creating meeting step 2/7.");
                    Console.WriteLine("Enter description.");

                    userInput = Console.ReadLine();

                    if (string.IsNullOrEmpty(userInput))
                    {
                        HelperClass.BadInput();
                        continue;
                    }

                    if (int.TryParse(userInput, out output))
                    {
                        if (output == -1)
                        {
                            creatingMeeting = false;
                            break;
                        }
                        else if(output == 0)
                        {
                            break;
                        }
                        else
                        {
                            HelperClass.BadInput();
                            continue;
                        }
                    }


                    meeting.Description = userInput;

                    while (creatingMeeting)
                    {
                        Console.Clear();
                        Console.WriteLine("Enter -1 to exit meeting creation.");
                        HelperClass.ShowBackOption();
                        Console.WriteLine("Creating meeting step 3/7.");
                        for (int i = 0; i < Meeting.s_categories.Count; i++)
                        {
                            Console.WriteLine($"Enter {i + 1}, to choose {Meeting.s_categories[i]}");
                        }
                        Console.WriteLine("Enter {number} to choose category");

                        userInput = Console.ReadLine();

                        if (string.IsNullOrEmpty(userInput))
                        {
                            HelperClass.BadInput();
                            continue;
                        }

                        if (!int.TryParse(userInput, out output))
                        {
                            HelperClass.BadInput();
                            continue;
                        }

                        if (output == -1)
                        {
                            creatingMeeting = false;
                            break;
                        }
                        else if (output == 0)
                        {
                            break;
                        }
                        else if(output > Meeting.s_categories.Count)
                        {
                            HelperClass.BadInput();
                            continue;
                        }

                        meeting.Category = Meeting.s_categories[--output];

                        while (creatingMeeting)
                        {
                            Console.Clear();
                            Console.WriteLine("Enter -1 to exit meeting creation.");
                            HelperClass.ShowBackOption();
                            Console.WriteLine("Creating meeting step 4/7.");
                            for (int i = 0; i < Meeting.s_types.Count; i++)
                            {
                                Console.WriteLine($"Enter {i + 1}, to choose {Meeting.s_categories[i]}");
                            }
                            Console.WriteLine("Enter {number} to choose category");

                            userInput = Console.ReadLine();

                            if (string.IsNullOrEmpty(userInput))
                            {
                                HelperClass.BadInput();
                                continue;
                            }

                            if (!int.TryParse(userInput, out output))
                            {
                                HelperClass.BadInput();
                                continue;
                            }

                            if (output == -1)
                            {
                                creatingMeeting = false;
                                break;
                            }
                            else if (output == 0)
                            {
                                break;
                            }
                            else if (output > Meeting.s_types.Count)
                            {
                                HelperClass.BadInput();
                                continue;
                            }

                            meeting.Category = Meeting.s_types[--output];

                            while (creatingMeeting)
                            {
                                Console.Clear(); 
                                Console.WriteLine("Enter -1 to exit meeting creation.");
                                HelperClass.ShowBackOption();
                                Console.WriteLine("Creating meeting step 5/7.");
                                Console.WriteLine("Enter start date.");
                                Console.WriteLine("Date Format: MM/dd/yyyy hh:mm:ss tt");
                                Console.WriteLine("Example input: 09/13/2022 11:00:00 am");
                                userInput = Console.ReadLine();

                                if (string.IsNullOrEmpty(userInput))
                                {
                                    HelperClass.BadInput();
                                    continue;
                                }

                                if (int.TryParse(userInput, out output))
                                {
                                    if (output == -1)
                                    {
                                        creatingMeeting = false;
                                        break;
                                    }
                                    else if (output == 0)
                                    {
                                        break;
                                    }
                                }

                                if (!DateTime.TryParseExact(userInput, HelperClass.s_format, null, System.Globalization.DateTimeStyles.None, out DateTime dateOutput))
                                {
                                    HelperClass.BadInput();
                                    continue;
                                }
                                
                                meeting.StartDate = dateOutput;

                                while (creatingMeeting)
                                {
                                    Console.Clear();
                                    Console.WriteLine("Enter -1 to exit meeting creation.");
                                    HelperClass.ShowBackOption();
                                    Console.WriteLine("Creating meeting step 6/7.");
                                    Console.WriteLine("Enter end date.");
                                    Console.WriteLine("Date Format: MM/dd/yyyy hh:mm:ss tt");
                                    Console.WriteLine("Example input: 09/13/2022 11:00:00 am");

                                    userInput = Console.ReadLine();

                                    if (string.IsNullOrEmpty(userInput))
                                    {
                                        HelperClass.BadInput();
                                        continue;
                                    }

                                    if (int.TryParse(userInput, out output))
                                    {
                                        if (output == -1)
                                        {
                                            creatingMeeting = false;
                                            break;
                                        }
                                        else if (output == 0)
                                        {
                                            break;
                                        }
                                    }

                                    if (!DateTime.TryParse(userInput, out dateOutput))
                                    {
                                        HelperClass.BadInput();
                                        continue;
                                    }

                                    meeting.EndDate = dateOutput;

                                    while (creatingMeeting)
                                    {
                                        bool creatingAttendees = true;
                                        while (creatingAttendees)
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Enter -1 to exit meeting creation.");
                                            HelperClass.ShowBackOption();
                                            Console.WriteLine("Creating meeting step 7/7.");
                                            Console.WriteLine("Enter 1 to add attendee.");
                                            Console.WriteLine("Enter 2 to finish meeting creation.");

                                            userInput = Console.ReadLine();

                                            if (string.IsNullOrEmpty(userInput))
                                            {
                                                HelperClass.BadInput();
                                                continue;
                                            }

                                            if (!int.TryParse(userInput, out output))
                                            {
                                                HelperClass.BadInput();
                                                continue;
                                            }

                                            if (output == -1)
                                            {
                                                creatingMeeting = false;
                                                creatingAttendees = false;
                                                break;
                                            }
                                            else if (output == 0)
                                            {
                                                creatingAttendees = false;
                                                break;
                                            }
                                            else if (output == 1)
                                            {
                                                AddingAttendeesToMeeting(meeting);
                                                break;
                                            }
                                            else if(output == 2)
                                            {
                                                List<Meeting> meetings = FileWriter.GetMeetings(s_meetingPath);
                                                if (meetings == null)
                                                {
                                                    meeting.Id = 1;
                                                }
                                                else
                                                {
                                                    meeting.Id = meetings.Count + 1;
                                                }
                                                FileWriter.AppendMeeting(s_meetingPath, meeting);
                                                creatingMeeting = false;
                                                creatingAttendees = false;
                                                Console.WriteLine("Meeting created.");
                                                Console.WriteLine("Press any key to continue.");
                                                Console.ReadKey();
                                                break;
                                            }
                                            else
                                            {
                                                HelperClass.BadInput();
                                                continue;
                                            }
                                        }
                                        if (creatingAttendees == false) break;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        public static void ShowAllMeetings()
        {
            List<Meeting> meetings = FileWriter.GetMeetings(s_meetingPath);

            while (true)
            {
                if (meetings == null)
                {
                    Console.Clear();
                    Console.WriteLine("Meetings");
                    Console.WriteLine("There are no meetings. Press any key to continue.");
                    Console.ReadKey();
                    return;
                }

                bool showingMeetings = true;

                while (showingMeetings)
                {
                    Console.Clear();
                    if (meetings == null) break;
                    PrintMeetings(meetings);

                    HelperClass.ShowBackOption();
                    Console.WriteLine("Enter 1 to filter meetings.");
                    Console.WriteLine("Enter 2 to delete meeting.");
                    Console.WriteLine("Enter 3 to add attendees to meeting.");

                    string userInput = Console.ReadLine();

                    if (string.IsNullOrEmpty(userInput))
                    {
                        HelperClass.BadInput();
                        continue;
                    }

                    if (!int.TryParse(userInput, out int output))
                    {
                        HelperClass.BadInput();
                        continue;
                    }

                    switch (output)
                    {
                        case 0:
                            {
                                showingMeetings = false;
                                break;
                            }
                        case 1:
                            {
                                //FilteringMeetings(meetings);
                                Console.WriteLine("Not implemented.");
                                Console.WriteLine("Press any key to continue.");
                                Console.ReadKey();
                                break;
                            }
                        case 2:
                            {
                                DeletingMeetings(meetings);
                                break;
                            }
                        case 3:
                            {
                                AddingAttendeesToMeetings(meetings);
                                break;
                            }
                        default:
                            {
                                HelperClass.BadInput();
                                break;
                            }
                    }
                }
            }
        }
        /*public static void FilteringMeetings(List<Meeting> meetings)
        {
            bool filteringMeetings = true;
            while (filteringMeetings)
            {
                PrintMeetings(meetings);

                int? choice = IntInput("Filtering meetings.",
                    new string[] {  "Enter {1} to filter by NAME",
                                    "Enter {2} to filter by RESPONSIBLE_PERSON",
                                    "Enter {3} to filter by DESCRIPTION",
                                    "Enter {4} to filter by CATEGORY",
                                    "Enter {5} to filter by TYPE",
                                    "Enter {6} to filter by DATE_TIME",
                                    "Enter {7} to filter by NUMBER OF ATTENDEES" });

                if (choice == null) choice = 0;

                switch (choice)
                {
                    case 0:
                        {
                            filteringMeetings = false;
                            break;
                        }
                    case 1:
                        {
                            while (true)
                            {
                                string text = StringInput("Filtering meetings by NAME.", "Enter filter {text}.");

                                if (text == null) break;

                                List<Meeting> filteredMeetings = meetings.Where(m => m.name.Contains(text)).ToList();

                                if (filteredMeetings.Count == 0)
                                {
                                    Console.WriteLine("There are no meetings with this filter. Press any key to try again.");
                                    Console.ReadKey();
                                    continue;
                                }

                                foreach (var item in filteredMeetings)
                                {
                                    item.Print();
                                }

                                Console.WriteLine("Press any key to try again.");
                                Console.ReadKey();
                            }

                            break;
                        }
                    case 2:
                        {
                            while (true)
                            {
                                string text = StringInput("Filtering meetings by RESPONSIBLE_PERSON", "Enter filter {text}.");

                                if (text == null) break;

                                List<Meeting> filteredMeetings = meetings.Where(m => m.responsiblePers.Contains(text)).ToList();

                                if (filteredMeetings.Count == 0)
                                {
                                    Console.WriteLine("There are no meetings with this filter. Press any key to try again.");
                                    Console.ReadKey();
                                    continue;
                                }

                                foreach (var item in filteredMeetings)
                                {
                                    item.Print();
                                }

                                Console.WriteLine("Press any key to try again.");
                                Console.ReadKey();
                            }

                            break;
                        }
                    case 3:
                        {
                            while (true)
                            {
                                string text = StringInput("Filtering meetings by DESCRIPTION", "Enter filter {text}.");

                                if (text == null) break;

                                List<Meeting> filteredMeetings = meetings.Where(m => m.description.Contains(text)).ToList();

                                if (filteredMeetings.Count == 0)
                                {
                                    Console.WriteLine("There are no meetings with this filter. Press any key to try again.");
                                    Console.ReadKey();
                                    continue;
                                }

                                foreach (var item in filteredMeetings)
                                {
                                    item.Print();
                                }

                                Console.WriteLine("Press any key to try again.");
                                Console.ReadKey();
                            }

                            break;
                        }
                    case 4:
                        {
                            while (true)
                            {
                                int? categoryChoice = OptionsInput(Meeting.Categories, "Filtering meetings by CATEGORY", "Enter {number} of desired CATEGORY.");

                                if (categoryChoice == null) break;

                                List<Meeting> filteredMeetings = meetings.Where(m => m.category.Equals(Meeting.Categories[(int)categoryChoice])).ToList();

                                if (filteredMeetings.Count == 0)
                                {
                                    Console.WriteLine("There are no meetings with this filter. Press any key to try again.");
                                    Console.ReadKey();
                                    continue;
                                }

                                foreach (var item in filteredMeetings)
                                {
                                    item.Print();
                                }

                                Console.WriteLine("Press any key to try again.");
                                Console.ReadKey();
                            }

                            break;
                        }
                    case 5:
                        {
                            while (true)
                            {
                                int? typeChoice = OptionsInput(Meeting.Categories, "Filtering meetings by TYPE", "Enter {number} of desired TYPE.");

                                if (typeChoice == null) break;

                                List<Meeting> filteredMeetings = meetings.Where(m => m.category.Equals(Meeting.Categories[(int)typeChoice])).ToList();

                                if (filteredMeetings.Count == 0)
                                {
                                    Console.WriteLine("There are no meetings with this filter. Press any key to try again.");
                                    Console.ReadKey();
                                    continue;
                                }

                                foreach (var item in filteredMeetings)
                                {
                                    item.Print();
                                }

                                Console.WriteLine("Press any key to try again.");
                                Console.ReadKey();
                            }

                            break;
                        }
                    case 6:
                        {
                            bool filteringMeetingsByDates = true;
                            while (filteringMeetingsByDates)
                            {
                                choice = IntInput("Filtering meetings by dates.",
                                    new string[] { "Enter {1} to filter from desired DATE_TIME.",
                                                   "Enter {2} to filter beetween two DATE_TIME's.",
                                                   "Enter {3} to filter already happened DATE_TIME's"});

                                switch (choice)
                                {
                                    case 0:
                                        {
                                            filteringMeetingsByDates = false;
                                            break;
                                        }
                                    case 1:
                                        {
                                            while (true)
                                            {
                                                DateTime? date = DateTimeInput("Filtering meetings from specified DATE_TIME.", "Enter date {text}");

                                                if (date == null) break;

                                                List<Meeting> filteredMeetings = meetings.Where(m => m.startDate.CompareTo((DateTime)date) >= 0).ToList();

                                                if (filteredMeetings.Count == 0)
                                                {
                                                    Console.WriteLine("There are no meetings with this filter. Press any key to try again.");
                                                    Console.ReadKey();
                                                    continue;
                                                }

                                                foreach (var item in filteredMeetings)
                                                {
                                                    item.Print();
                                                }

                                                Console.WriteLine("Press any key to try again.");
                                                Console.ReadKey();
                                            }

                                            break;
                                        }
                                    case 2:
                                        {
                                            while (true)
                                            {
                                                DateTime? startingDate = DateTimeInput("Filtering meetings beetween two DATE_TIME's.", "Enter starting date {text}");

                                                if (startingDate == null) break;

                                                DateTime? endingDate = DateTimeInput("Filtering meetings from specified DATE_TIME.", "Enter ending date {text}");

                                                if (endingDate == null) break;

                                                List<Meeting> filteredMeetings = meetings.Where(m => m.startDate.CompareTo((DateTime)startingDate) >= 0
                                                                                                  && m.startDate.CompareTo((DateTime)endingDate) <= 0).ToList();

                                                if (filteredMeetings.Count == 0)
                                                {
                                                    Console.WriteLine("There are no meetings with this filter. Press any key to try again.");
                                                    Console.ReadKey();
                                                    continue;
                                                }

                                                foreach (var item in filteredMeetings)
                                                {
                                                    item.Print();
                                                }

                                                Console.WriteLine("Press any key to try again.");
                                                Console.ReadKey();
                                            }

                                            break;
                                        }
                                    case 3:
                                        {
                                            while (true)
                                            {
                                                List<Meeting> filteredMeetings = meetings.Where(m => m.startDate.CompareTo(DateTime.Now) < 0).ToList();

                                                if (filteredMeetings.Count == 0)
                                                {
                                                    Console.WriteLine("There are no meetings with this filter. Press any key to continue.");
                                                    Console.ReadKey();
                                                    break;
                                                }

                                                foreach (var item in filteredMeetings)
                                                {
                                                    item.Print();
                                                }

                                                Console.WriteLine("Press any key to continue.");
                                                Console.ReadKey();
                                                break;
                                            }

                                            break;
                                        }
                                    default:
                                        {
                                            WrongOptionEntered();
                                            break;
                                        }
                                }
                            }

                            break;
                        }
                    case 7:
                        {
                            bool filteringMeetingsByAttendees = true;
                            while (filteringMeetingsByAttendees)
                            {
                                choice = IntInput("Filtering meetings by attendees.",
                                    new string[] { "Enter {1} to filter meetings that have less than specific number of attendees.",
                                                   "Enter {2} to filter meetings that have more than specific number of attendees.",
                                                   "Enter {3} to filter meetings that have exact number of attendees."});

                                if (choice == null) choice = 0;

                                switch (choice)
                                {
                                    case 0:
                                        {
                                            filteringMeetingsByAttendees = false;
                                            break;
                                        }
                                    case 1:
                                        {
                                            while (true)
                                            {
                                                int? number = IntInput("Filtering meetings that have less than specific number of attendees", new string[] { "Enter number of attendees {number}" });

                                                if (number == null) break;

                                                List<Meeting> filteredMeetings = meetings.Where(m => m.attendees.Count < (int)number).ToList();

                                                if (filteredMeetings.Count == 0)
                                                {
                                                    Console.WriteLine("There are no meetings with this filter. Press any key to try again.");
                                                    Console.ReadKey();
                                                    continue;
                                                }

                                                foreach (var item in filteredMeetings)
                                                {
                                                    item.Print();
                                                }

                                                Console.WriteLine("Press any key to try again.");
                                                Console.ReadKey();
                                            }

                                            break;
                                        }
                                    case 2:
                                        {
                                            while (true)
                                            {
                                                int? number = IntInput("Filtering meetings that have more than specific number of attendees", new string[] { "Enter {number} of attendees" });

                                                if (number == null) break;

                                                List<Meeting> filteredMeetings = meetings.Where(m => m.attendees.Count > (int)number).ToList();

                                                if (filteredMeetings.Count == 0)
                                                {
                                                    Console.WriteLine("There are no meetings with this filter. Press any key to try again.");
                                                    Console.ReadKey();
                                                    continue;
                                                }

                                                foreach (var item in filteredMeetings)
                                                {
                                                    item.Print();
                                                }

                                                Console.WriteLine("Press any key to try again.");
                                                Console.ReadKey();
                                            }

                                            break;
                                        }
                                    case 3:
                                        {
                                            while (true)
                                            {
                                                int? number = IntInput("Filtering meetings that have exact number of attendees", new string[] { "Enter {number} of attendees" });

                                                if (number == null) break;

                                                List<Meeting> filteredMeetings = meetings.Where(m => m.attendees.Count == (int)number).ToList();

                                                if (filteredMeetings.Count == 0)
                                                {
                                                    Console.WriteLine("There are no meetings with this filter. Press any key to try again.");
                                                    Console.ReadKey();
                                                    continue;
                                                }

                                                foreach (var item in filteredMeetings)
                                                {
                                                    item.Print();
                                                }

                                                Console.WriteLine("Press any key to try again.");
                                                Console.ReadKey();
                                            }

                                            break;
                                        }
                                    default:
                                        {
                                            WrongOptionEntered();
                                            break;
                                        }
                                }
                            }

                            break;
                        }
                    default:
                        {
                            WrongOptionEntered();
                            break;
                        }
                }
            }
        }*/
        public static void DeletingMeetings(List<Meeting> meetings)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Deleting meetings");
                HelperClass.ShowBackOption();
                if (meetings == null) break;
                PrintMeetings(meetings);
                Console.WriteLine("Enter meeting entry number you wish to delete.");

                string userInput = Console.ReadLine();

                if (string.IsNullOrEmpty(userInput))
                {
                    HelperClass.BadInput();
                    continue;
                }

                if (!int.TryParse(userInput, out int output))
                {
                    HelperClass.BadInput();
                    continue;
                }

                if (output == 0)
                {
                    break;
                }
                else if (output > meetings.Count)
                {
                    HelperClass.BadInput();
                    continue;
                }

                meetings.Remove(meetings.ElementAt(--output));
                FileWriter.UpdateMeetings(s_meetingPath, meetings);
            }
        }
        public static void AddingAttendeesToMeeting(Meeting meeting)
        {
            List<User> allUsers = FileWriter.GetAttendees(UserAuthorization.s_usersPath);

            while (true)
            {
                if (allUsers.Count == 0)
                {
                    Console.WriteLine("There are nothing to choose from.");
                    Console.WriteLine("Press any key to continue.");
                    Console.ReadKey();
                    break;
                }

                Console.Clear();
                Console.WriteLine("Adding attendees to meeting");
                HelperClass.ShowBackOption();
                Console.WriteLine("Enter {number} to choose attendee");

                for (int i = 0; i < allUsers.Count; i++)
                {
                    User tempUser = allUsers.ElementAt(i);
                    Console.WriteLine($"{i + 1} {tempUser.Nickname} {tempUser.Name} {tempUser.Surname}");
                }

                string userInput = Console.ReadLine();

                if (string.IsNullOrEmpty(userInput))
                {
                    HelperClass.BadInput();
                    continue;
                }

                if (!int.TryParse(userInput, out int output))
                {
                    HelperClass.BadInput();
                    continue;
                }

                if(output == 0)
                {
                    break;
                }
                else if (output < 1 || output > allUsers.Count)
                {
                    HelperClass.BadInput();
                    continue;
                }

                User attendee = allUsers.ElementAt(--output);

                if(meeting.AttendeesIds != null)
                {
                    if (meeting.AttendeesIds.Any(att => att.Equals(attendee.Id)))
                    {
                        Console.WriteLine("Attendee is already in the meeting.");
                        Console.WriteLine("Press any key to continue.");
                        Console.ReadKey();
                        continue;
                    }
                }


                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("Addiding attendees to meeting");
                    HelperClass.ShowBackOption();
                    Console.WriteLine($"Meeting start at {meeting.StartDate}");
                    Console.WriteLine($"and ends at {meeting.EndDate}");
                    Console.WriteLine("Enter at what time attendee should join the meeting.");
                    Console.WriteLine("Date Format: MM/dd/yyyy hh:mm:ss tt");
                    Console.WriteLine("Example input: 09/13/2022 11:00:00 am");
                    userInput = Console.ReadLine();

                    if (string.IsNullOrEmpty(userInput)){
                        HelperClass.BadInput();
                        continue;
                    }

                    if (int.TryParse(userInput, out output))
                    {
                        if (output == 0)
                        {
                            break;
                        }
                        else
                        {
                            HelperClass.BadInput();
                            continue;
                        }
                    }

                    if (!DateTime.TryParse(userInput, out DateTime dateOutput))
                    {
                        HelperClass.BadInput();
                        continue;
                    }

                    if(dateOutput.CompareTo(meeting.StartDate) >= 0 && dateOutput.CompareTo(meeting.EndDate) <= 0)
                    {
                        attendee.AddMeetingAndTime(meeting, dateOutput);
                        meeting.AddAttendee(attendee);
                        Console.WriteLine("Attendee added");
                        Console.WriteLine("Press any key to continue.");
                        Console.ReadKey();
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Entered date is not at meeting time.");
                        Console.WriteLine("Press any key to try again.");
                        Console.ReadKey();
                        continue;
                    }
                }
            }
        }
        public static void AddingAttendeesToMeetings(List<Meeting> meetings)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Adding attendees to meetings.");
                HelperClass.ShowBackOption();
                if (meetings == null) break;
                PrintMeetings(meetings);
                Console.WriteLine("Enter meeting entry number to start adding attendees.");

                string userInput = Console.ReadLine();

                if (string.IsNullOrEmpty(userInput))
                {
                    HelperClass.BadInput();
                    continue;
                }

                if(!int.TryParse(userInput, out int output))
                {
                    HelperClass.BadInput();
                    continue;
                }

                if(output == 0)
                {
                    break;
                }
                else if (output > meetings.Count)
                {
                    HelperClass.BadInput();
                    continue;
                }

                AddingAttendeesToMeeting(meetings.ElementAt(--output));
            }
        }
        public static void PrintMeetings(List<Meeting> meetings)
        {
            Console.WriteLine("Meetings:___________________________________");
            foreach (var item in meetings)
            {
                Console.WriteLine($"{meetings.IndexOf(item) + 1} entry");
                item.Print();
                Console.WriteLine();
            }
        }
    }
}
