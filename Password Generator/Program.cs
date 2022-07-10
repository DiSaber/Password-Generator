using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

internal class Program
{
    private static Random random = new Random();

    static void Main(string[] args)
    {
        Console.Write("Generator Seed (leave blank for random): ");

        var seed = Console.ReadLine();

        if (seed != null)
        {
            if (seed == "")
            {
                random = new Random(seed);
            }

            Console.Write("Password Length: ");

            if (int.TryParse(Console.ReadLine(), out int length))
            {
                while (true)
                {
                    Console.Write(RandomPassword(length));
                    Console.ReadLine();
                }
            }
        }
    }

    private static string RandomPassword(int length)
    {
        string password = "";

        for (int i = 0; i < length; i++)
        {
            password += (char)random.Next(32, 127);
        }

        return password;
    }
}
