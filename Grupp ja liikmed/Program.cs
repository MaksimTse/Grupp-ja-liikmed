using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupp_ja_liikmed
{
    public class Program
    {
        public static void Main()
        {
            Random random = new Random();

            List<string> group1Members = new List<string>();
            List<string> group2Members = new List<string>();

            for (int i = 0; i < 20; i++)
            {
                string name1 = GenerateRandomName(random);
                string name2 = GenerateRandomName(random);
                group1Members.Add(name1);
                group2Members.Add(name2);
            }

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Group 1 Candidates:");
            PrintColoredNames(group1Members);

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nGroup 2 Candidates:");
            PrintColoredNames(group2Members);
            Console.ResetColor();

            string groupName1 = GenerateRandomName(random);
            int maxAmount1 = 20;
            Console.ForegroundColor = ConsoleColor.Red;
            Group group1 = new Group(maxAmount1);
            Console.WriteLine($"\nGroup 1 Max Spaces: {maxAmount1} ");

            string groupName2 = GenerateRandomName(random);
            int maxAmount2 = 20;

            Group group2 = new Group(maxAmount2);
            Console.WriteLine($"Group 2 Max Spaces: {maxAmount2}\n");
            Console.ResetColor();

            for (int i = 0; i < maxAmount1; i++)
            {
                if (group1Members.Count > 0)
                {
                    string memberName = group1Members[0];
                    int age = random.Next(18, 60);
                    group1.AddMember(memberName, age);
                    group1Members.RemoveAt(0);
                }
            }

            for (int i = 0; i < maxAmount2; i++)
            {
                if (group2Members.Count > 0)
                {
                    int randomIndex = random.Next(group2Members.Count);
                    string memberName = group2Members[randomIndex];
                    int age = random.Next(18, 60);
                    group2.AddMember(memberName, age);
                    group2Members.RemoveAt(randomIndex);
                }
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Group 1 Successfully joined members: {string.Join(", ", group1.Members)}");
            Console.WriteLine($"Group 2 Successfully joined members: {string.Join(", ", group2.Members)}  \n");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(group1.GetOldestMember());
            Console.WriteLine(group2.GetOldestMember());
            Console.ResetColor();
        }

        public static void Shuffle<T>(IList<T> list, Random random)
        {
            int n = list.Count;
            for (int i = 0; i < n; i++)
            {
                int r = i + random.Next(n - i);
                T temp = list[i];
                list[i] = list[r];
                list[r] = temp;
            }
        }

        public static string GenerateRandomName(Random random)
        {
            string[] names = { "John", "Mary", "Samantha", "Robert", "Emily", "Maksim", "Luca", "Alex", "Martin", "Yarik", "Sasha", "Timur", "Arkadii", "Archi", "Artur", "Albert", "Stark", "Tony", "Alik", "Mart", "Kirill", "Oleg" };
            return names[random.Next(names.Length)];
        }

        public static void PrintColoredNames(List<string> names)
        {
            HashSet<string> uniqueNames = new HashSet<string>();
            foreach (string name in names)
            {
                if (uniqueNames.Contains(name))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    uniqueNames.Add(name);
                }
                Console.Write($"{name}, ");
            }
            Console.ResetColor();
            Console.WriteLine();
        }
    }
}
