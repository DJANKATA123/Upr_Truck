using System;
using System.Collections;
using System.Collections.Generic;
namespace TRUCK
{
    class GasStation
    {
        public int fuel;
        public int distance;
        public int stnumber;
        public GasStation(int f, int d, int n)
        {
            fuel = f;
            distance = d;
            stnumber = n;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Queue<GasStation> stations = new Queue<GasStation>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                int[] stats = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                stations.Enqueue(new GasStation(stats[0], stats[1], i));
            }
            int fuel = 0;
            for (int i = 0; i < n; i++)
            {
                Queue<GasStation> stations1 = new Queue<GasStation>(stations);
                for (int j = 0; j < n; j++)
                {
                    GasStation station1 = stations1.Dequeue();
                    fuel = station1.fuel + fuel;
                    fuel = fuel - station1.distance;
                    if (fuel < 0)
                    {

                        break;

                    }
                }
                GasStation station = stations.Peek();
                if (fuel >= 0)
                {
                    Console.WriteLine(station.stnumber);
                    return;
                }
                else
                {
                    stations.Dequeue();
                    stations.Enqueue(station);
                }
                fuel = 0;
            }
            Console.WriteLine("NOT");
        }
    }
}
