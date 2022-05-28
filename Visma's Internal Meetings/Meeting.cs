using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visma_s_Internal_Meetings
{
    class Meeting
    {
        public static readonly List<string> Categories = new List<string>()
        {
            "CodeMonkey",
            "Hub",
            "Short",
            "TeamBuilding"
        };

        public static readonly List<string> Types = new List<string>()
        {
            "Live",
            "InPerson"
        };

        public string name { get; set; }
        public string description { get; set; }
        public string responsiblePers { get; set; }
        public string category { get; set; }
        public string type { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }

        public void Print()
        {
            Console.WriteLine("name: " + name);
            Console.WriteLine("description: " + description);
            Console.WriteLine("responsible Person: " + responsiblePers);
            Console.WriteLine("category:" + category);
            Console.WriteLine("type: " + type);
            Console.WriteLine("startDate: " + startDate);
            Console.WriteLine("endDate: " + endDate);
        }
    }
}
