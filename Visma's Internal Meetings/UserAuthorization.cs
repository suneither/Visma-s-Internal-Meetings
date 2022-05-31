using System;
using System.Collections.Generic;
using System.Linq;

namespace Visma_s_Internal_Meetings
{
    public class UserAuthorization
    {
        public readonly static string s_usersPath = "users.txt";
        public static bool s_loggedIn = false;
        public static User s_user = null;

        public static void Login()
        {
            bool loggingIn = true;
            while (loggingIn)
            {
                while (loggingIn)
                {
                    Console.Clear();
                    Console.WriteLine("Login");
                    Console.WriteLine("Enter -1 to exit login.");
                    Console.WriteLine("Enter nickname.");
                    string nickname = Console.ReadLine();

                    if (string.IsNullOrEmpty(nickname))
                    {
                        HelperClass.BadInput();
                        continue;
                    }

                    if (int.TryParse(nickname, out int output))
                    {
                        if (output == -1)
                        {
                            loggingIn = false;
                            break;
                        }

                        HelperClass.BadInput();
                        continue;
                    }

                    while (loggingIn)
                    {
                        Console.Clear();
                        Console.WriteLine("Login");
                        Console.WriteLine("Enter -1 to exit login.");
                        Console.WriteLine("Enter password");
                        string password = Console.ReadLine();

                        if (string.IsNullOrEmpty(password))
                        {
                            HelperClass.BadInput();
                            continue;
                        }

                        if (int.TryParse(password, out output))
                        {
                            if (output == -1)
                            {
                                loggingIn = false;
                                break;
                            }

                            HelperClass.BadInput();
                            continue;
                        }

                        List<User> users = FileWriter.GetAttendees(s_usersPath);

                        if(users == null)
                        {
                            Console.WriteLine("User do not exists.");
                            Console.WriteLine("Press any key to try again.");
                            Console.ReadKey();
                            break;
                        }

                        var user = (User)users.Where(user => user.Nickname == nickname && user.Password == password).FirstOrDefault();

                        if(user == null)
                        {
                            Console.WriteLine("User do not exists.");
                            Console.WriteLine("Press any key to try again.");
                            Console.ReadKey();
                            break;
                        }

                        s_user = user;
                        s_loggedIn = true;
                        loggingIn = false;
                        Console.WriteLine($"You are logged in as {s_user.Nickname}.");
                        Console.WriteLine("Press any key to continue.");
                        Console.ReadKey();
                        return;
                    }
                }
            }
        }

        public static void Register()
        {
            bool registering = true;
            User user = new User();
            while (registering)
            {
                Console.Clear();
                Console.WriteLine("Registration");
                Console.WriteLine("Enter -1 to exit registration.");
                Console.WriteLine("Enter nickname");
                string userInput = Console.ReadLine();

                if (string.IsNullOrEmpty(userInput))
                {
                    HelperClass.BadInput();
                    continue;
                }

                if(int.TryParse(userInput, out int output)){
                    if (output == -1)
                    {
                        registering = false;
                        break;
                    }
                }

                List<User> users = FileWriter.GetAttendees(s_usersPath);

                if(users != null)
                {
                    if (users.Exists(user => user.Nickname == userInput))
                    {
                        Console.WriteLine("User with this nickname already exists.");
                        Console.WriteLine("Press any key to try again.");
                        Console.ReadKey();
                        continue;
                    }
                }
                
                user.Nickname = userInput;

                while (registering)
                {
                    Console.Clear();
                    Console.WriteLine("Registration");
                    Console.WriteLine("Enter -1 to exit registration.");
                    HelperClass.ShowBackOption();
                    Console.WriteLine("Enter password");
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
                            registering = false;
                            break;
                        }else if(output == 0)
                        {
                            break;
                        }
                    }

                    user.Password = userInput;

                    while (registering)
                    {
                        Console.Clear();
                        Console.WriteLine("Registration");
                        Console.WriteLine("Enter -1 to exit registration.");
                        HelperClass.ShowBackOption();
                        Console.WriteLine("Enter name");
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
                                registering = false;
                                break;
                            }
                            else if (output == 0)
                            {
                                break;
                            }
                        }

                        user.Name = userInput;

                        while (registering)
                        {
                            Console.Clear();
                            Console.WriteLine("Registration");
                            Console.WriteLine("Enter -1 to exit registration.");
                            HelperClass.ShowBackOption();
                            Console.WriteLine("Enter surname");
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
                                    registering = false;
                                    break;
                                }
                                else if (output == 0)
                                {
                                    break;
                                }
                            }

                            user.Surname = userInput;

                            if(users != null)
                            {
                                if (users.Count > 0)
                                    user.Id = users.ElementAt(users.Count - 1).Id + 1;
                            }
                            else
                            {
                                user.Id = 0;
                            }


                            FileWriter.AppendUser(s_usersPath, user);
                            s_user = user;
                            s_loggedIn = true;
                            registering = false;
                            Console.WriteLine($"You successfully registered as {s_user.Nickname}");
                            Console.WriteLine("Press any key to continue.");
                            Console.ReadKey();
                            return;
                        }
                    }
                }
            }
        }
    }
}
