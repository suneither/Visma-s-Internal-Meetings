using System;
using System.Collections.Generic;

namespace Visma_s_Internal_Meetings 
{
    class Program
    {
        private static bool running = true;
        private static bool loggedIn = false;

        static void Main(string[] args)
        {
            int choice;

            while (running)
            {
                while (!loggedIn)
                {
                    Login();
                }

                Console.Clear();

                Console.WriteLine("Connected user: " + User.nickname);
                Console.WriteLine();
                Console.WriteLine("Close program enter -> 0");
                Console.WriteLine("Create a new meeting enter -> 1");
                Console.WriteLine("Show all meetings enter -> 2");

                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    WrongOptionEntered();
                    continue;
                }

                switch (choice)
                {
                    case 0:
                        {
                            running = false;
                            break;
                        }
                    case 1:
                        {
                            CreateNewMeeting();
                            break;
                        }
                    case 2:
                        {
                            ShowAllMeetings();
                            break;
                        }
                    default:
                        {
                            WrongOptionEntered();
                            break;
                        }

                }

            }
        }

        private static void ShowAllMeetings()
        {
            List<Meeting> meetings = FileWriter.ReadFromFile("main.txt");
            if (meetings == null)
            {
                Console.WriteLine("There are no meetings.");
                return;
            }

            Console.WriteLine("Meetings:");
            Console.WriteLine("___________________________________");
            foreach (var item in meetings)
            {
                Console.WriteLine(meetings.IndexOf(item) + " entry");
                item.Print();
                Console.WriteLine();
            }

            // filter options 
            // back option

            Console.WriteLine("To select meeting enter {1}");
            Console.WriteLine("To filter enter {2}");
            int choice = Console.ReadLine();

            switch (choice)
            {
                case 1:
                    {

                        break;
                    }
            }

        }

        private static void WrongOptionEntered()
        {
            Console.WriteLine("Bad input. Try again.");
            Console.ReadLine();
        }

        private static void Login()
        {
            Console.WriteLine("Simplified Login");
            Console.WriteLine("Write your nickname. It will be used as a resposiblePerson field.");
            string nickaname = Console.ReadLine();
            if (string.IsNullOrEmpty(nickaname))
            {
                Console.WriteLine("Nickname cannot be empty. Press enter to try again.");
                Console.ReadLine();
                return;
            }
            else
            {
                User.nickname = nickaname;
                loggedIn = true;
                Console.WriteLine("Yuo are now connected. Press enter to continue.");
                Console.ReadLine();
            }
        }

        private static void CreateNewMeeting()
        {

            Meeting meeting = new Meeting();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Enter name");
                string input = Console.ReadLine();
                if (string.IsNullOrEmpty(input))
                {
                    WrongOptionEntered();
                    continue;
                }

                meeting.name = input;
                break;
            }

            meeting.responsiblePers = User.nickname;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Enter description");
                string input = Console.ReadLine();
                if (string.IsNullOrEmpty(input))
                {
                    WrongOptionEntered();
                    continue;
                }

                meeting.description = input;
                break;
            }

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Choose category");

                int choice;
                for (int i = 0; i < Meeting.Categories.Count; i++)
                {
                    Console.WriteLine("Enter " + i + " to choose " + Meeting.Categories[i]);
                }

                bool parsed = int.TryParse(Console.ReadLine(), out choice);

                if (!parsed || choice < 0 || choice >= Meeting.Categories.Count)
                {
                    WrongOptionEntered();
                    continue;
                }

                meeting.category = Meeting.Categories[choice];
                break;
            }

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Choose type");

                int choice;
                for (int i = 0; i < Meeting.Types.Count; i++)
                {
                    Console.WriteLine("Enter " + i + " to choose " + Meeting.Types[i]);
                }

                bool parsed = int.TryParse(Console.ReadLine(), out choice);

                if (!parsed || choice < 0 || choice >= Meeting.Types.Count)
                {
                    WrongOptionEntered();
                    continue;
                }

                meeting.type = Meeting.Types[choice];
                break;
            }

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Enter start date. ");
                Console.WriteLine("Date Format: day/month/year hour:minute:second");
                Console.WriteLine("Example input: 13/09/2022 00:00:00");

                DateTime date;
                string input = Console.ReadLine();
                if(!DateTime.TryParse(input, out date))
                {
                    WrongOptionEntered();
                    continue;
                }

                meeting.startDate = date;
                break;
            }

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Enter end date. ");
                Console.WriteLine("Date Format: month/day/year hour:minute:second");
                Console.WriteLine("Example input: 09/13/2022 00:00:00");

                DateTime date;
                string input = Console.ReadLine();
                if (!DateTime.TryParse(input, out date))
                {
                    WrongOptionEntered();
                    continue;
                }

                meeting.endDate = date;
                break;
            }

            FileWriter.AppendToFile("main.txt", meeting);
        }

    }
}