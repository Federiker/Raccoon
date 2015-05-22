using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raccoon.Objects;

namespace Raccoon.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var q = System.Console.ReadLine();
            writeResponse(q);
            System.Console.ReadLine();
        }

        static async void writeResponse(string q)
        {
            var res = await Response<Videogames>.MakeRequest(q);
            if (res.TookMs.HasValue)
            {
                System.Console.WriteLine(res.TookMs.Value);
            }
            else
            {
                System.Console.WriteLine("No took");
            }
            System.Console.WriteLine(res.Error);
            if (res.Results != null)
            {
                foreach (var v in res.Results)
                {
                    System.Console.WriteLine(v.Source.Title);
                    System.Console.WriteLine(v.Source.Platform);
                    System.Console.WriteLine();
                }
            }
            System.Console.WriteLine("ENDED");
        }
    }
}
