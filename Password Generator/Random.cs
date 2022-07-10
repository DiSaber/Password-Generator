using System;
using System.Text;

internal class Random
{
    public string Seed;
    private long cycle = 0;
    public Random(string seed)
    {
        Seed = seed;
    }

    public Random()
    {
        Seed = DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds.ToString();
    }

    public double NextDouble()
    {
        using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
        {
            byte[] inputBytes = Encoding.ASCII.GetBytes($"{cycle}-{Seed}");
            byte[] hashBytes = md5.ComputeHash(inputBytes);

            cycle++;

            return (double)Math.Abs(BitConverter.ToInt64(hashBytes, 0)) / long.MaxValue % 1;
        }
    }

    public long Next()
    {
        using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
        {
            byte[] inputBytes = Encoding.ASCII.GetBytes($"{cycle}-{Seed}");
            byte[] hashBytes = md5.ComputeHash(inputBytes);

            cycle++;

            return BitConverter.ToInt64(hashBytes, 0);
        }
    }

    public long Next(long exclusive)
    {
        return (long)(NextDouble() * exclusive);
    }

    public long Next(long minimum, long maximum)
    {
        return Next(maximum - minimum) + minimum;
    }

    public float NextFloat(float minimum, float maximum)
    {
        return ((float)NextDouble() * (maximum - minimum)) + minimum;
    }
}
