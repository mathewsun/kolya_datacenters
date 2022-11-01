using System;
using System.Collections.Generic;
using System.Linq;

namespace _1testExample
{
    public class DataCenter
    {
        public int Id { get; set; }
        public int R { get; set; }
        public int A { get; set; }
        public List<Server> Servers { get; set; }
    }

    public class Server
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            string str = Console.ReadLine().Trim();

            string[] items = str.Split(' ');

            int n = Int32.Parse(items[0]); //count datacenters
            int m = Int32.Parse(items[1]); //count server per dc
            int q = Int32.Parse(items[2]); //commands count

            List<DataCenter> dcList = new List<DataCenter>();

            for (int i = 1; i <= n; i++)
            {
                DataCenter dc = new DataCenter();

                dc.Id = i;
                dc.A = m;
                dc.R = 0;

                dc.Servers = new List<Server>();

                for (int j = 1; j <= m; j++)
                {
                    dc.Servers.Add(new Server { Id = j, IsActive = true });
                }

                dcList.Add(dc);
            }

            int numCommand = 1;

            while (numCommand <= q)
            {
                str = Console.ReadLine().Trim();

                string[] itemsc = str.Split(' ');

                string command = itemsc[0];

                switch (command)
                {
                    case "RESET":

                        int idcr = Int32.Parse(itemsc[1]);

                        var dcr = dcList.First(x => x.Id == idcr);

                        dcr.A = m;
                        dcr.R++;

                        foreach (var server in dcr.Servers)
                        {
                            server.IsActive = true;
                        }

                        break;
                    case "DISABLE":

                        int idcd = Int32.Parse(itemsc[1]);
                        int js = Int32.Parse(itemsc[2]);

                        var dcd = dcList.First(x => x.Id == idcd);

                        var item = dcd.Servers.First(s => s.Id == js);

                        if (item.IsActive)
                        {
                            item.IsActive = false;
                            dcd.A--;
                        }

                        break;
                    case "GETMAX":

                        var dcgmax = dcList.Max(dc => dc.R * dc.A);

                        var sgmax = dcList.Where(dc => dc.R * dc.A == dcgmax).FirstOrDefault();

                        Console.WriteLine(sgmax.Id);

                        break;
                    case "GETMIN":

                        var dcgmin = dcList.Min(dc => dc.R * dc.A);

                        var sgmin = dcList.Where(dc => dc.R * dc.A == dcgmin).FirstOrDefault();

                        Console.WriteLine(sgmin.Id);

                        break;
                    default:
                        //do a different thing
                        break;
                }

                numCommand++; // подсчитываем команды
            }
        }
    }
}
