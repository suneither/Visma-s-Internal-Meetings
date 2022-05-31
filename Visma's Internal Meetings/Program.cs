using System;
using System.Collections.Generic;
using System.Linq;

namespace Visma_s_Internal_Meetings 
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Login();

                Console.Clear();
                Console.WriteLine($"Logged in as {UserAuthorization.s_user.Nickname}");
                Console.WriteLine("Enter 1 to create meeting");
                Console.WriteLine("Enter 2 to show all meetings");

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
                    case 1:
                    {
                        MeetingOperations.CreateNewMeeting();
                        break;
                    }
                    case 2:
                    {
                        MeetingOperations.ShowAllMeetings();
                        break;
                    }
                }
            }
        }
        private static void Login()
        {
            while (!UserAuthorization.s_loggedIn)
            {
                Console.Clear();
                Console.WriteLine("Registration and Login.");
                Console.WriteLine("Enter {1} to login.");
                Console.WriteLine("Enter {2} to register.");

                string userInput = Console.ReadLine();

                if (string.IsNullOrEmpty(userInput))
                {
                    HelperClass.BadInput();
                    continue;
                }

                if (!int.TryParse(userInput, out int output)){
                    HelperClass.BadInput();
                    continue;
                }

                if(output < 1 || output > 2)
                {
                    HelperClass.BadInput();
                    continue;
                }

                switch (output)
                {
                    case 1:
                    {
                        UserAuthorization.Login();
                        break;
                    }
                    case 2:
                    {
                        UserAuthorization.Register();
                        break;
                    }
                }
            }
        }
    }
}