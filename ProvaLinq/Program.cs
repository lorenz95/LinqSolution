using MathNet.Numerics;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ProvaLinq
{
    internal class Program
    {
        public static int VALUE_DELTA = 11;
        static void Main(string[] args)
        {
            // Specify the data source.
            int[] scores = new int[] { 97, 92, 81, 60 };

            List<int> listInt = new List<int>();

            Random rnd = new Random();

            var value = rnd.Next(100);

            Console.WriteLine(" value = " + value);

            int i, temp;

            value = rnd.Next(100);
            for (i = 0; i < VALUE_DELTA; i++)
            {
                var item = value;
                listInt.Add(item);
            }

            temp = i;
            value = rnd.Next(100);
            for (; i < temp + VALUE_DELTA; i++)
            {
                var item = value;
                listInt.Add(item);
            }

            temp = i;
            value = rnd.Next(100);
            for (; i < temp + VALUE_DELTA; i++)
            {
                var item = value;
                listInt.Add(item);
            }

            //Array.Find(points, x => x.X * x.Y > 100000);
            var duplicates = listInt.GroupBy(x => x)
                         .Where(g => g.Count() > 1)
                         .Select(g => g.Key);

            var duplicates3 = listInt
            .GroupBy(x => x)              // Raggruppa per valore
            .Where(g => g.Count() > 10)   // Filtra i gruppi con più di 10 elementi
            .Select(g => g.Key);          // Seleziona la chiave del gruppo (il valore duplicato)

            Console.WriteLine("Duplicates3 \n");

            var siNo = (duplicates3.Count() == 3) ? "si" : "no";

            Console.WriteLine("Il vettore contiene 3 elementi ? {0}", siNo);//, (duplicates3.Count() == 3) ? "si" : "no" );

            foreach(var item in duplicates3)
            {
                Console.Write(" item = " + item);
            }

            //Console.WriteLine("Duplicate1 \n");
            //foreach (var item in duplicates)
            //{
            //    Console.Write(" item1 = " + item);
            //}

            //Console.WriteLine("Duplicate2 \n");
            //foreach (var item in duplicates2)
            //{
            //    Console.Write(" item2 = " + item);
            //}

            HashSet<int> set = new HashSet<int>();

            set.Add(1);
            set.Add(1);
            set.Add(2);

            while (set.Count() < 100)
            {
                int item = rnd.Next(500);
                set.Add(item);
            }

            

            //listInt

            // Define the query expression.
            IEnumerable<int> scoreQuery =
                from num in listInt
                where num > 80
                select num;

            /*
            // Execute the query.
            foreach (var i in scoreQuery)
            {
                Console.Write(i + " ");
            }
            */

            // Output: 97 92 81
        }
    }
}
