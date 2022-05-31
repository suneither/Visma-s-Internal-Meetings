using System;

namespace Visma_s_Internal_Meetings
{
    public class HelperClass
    {
        public static string s_format = "MM/dd/yyyy hh:mm:ss tt";

        public static void ShowBackOption()
        {
            Console.WriteLine("Enter 0 to go back.");
        }

        public static void BadInput()
        {
            Console.WriteLine("Bad input. Press any key to continue.");
            Console.ReadKey();
        }
    }
}
