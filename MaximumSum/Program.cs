using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace MaximumSum
{
    class Program
    {
        public static void Main(string[] args)
        {
            string pathA = "simple_triangle.txt";
            string pathB = "triangle.txt";

            Console.WriteLine("Triangle from file {0}, maximal sum: {1} ", pathA, MaximalSum(ReadFromFile(pathA)));
            Console.WriteLine("Triangle from file {0}, maximal sum: {1}", pathB, MaximalSum(ReadFromFile(pathB)));

            Console.ReadLine();
        }

        /// <summary>
        /// Search for maximal sum
        /// </summary>
        /// <param name="triangle">List of triangle numbers</param>
        private static int MaximalSum(List<int[]> triangle)
        {
            try
            {
                for (int i = triangle.Count - 2; i >= 0; i--)
                    for (int j = 0; j < i + 1; j++)
                        triangle[i][j] = Math.Max(triangle[i][j] + triangle[i + 1][j], triangle[i][j] + triangle[i + 1][j + 1]);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
                Environment.Exit(0);
            }
            return triangle[0][0];
        }

        /// <summary>
        /// Reading from txt file and convertation to list of integer arrays
        /// </summary>
        /// <param name="path"></param>
        private static List<int[]> ReadFromFile (string path)
        {        
            List<int[]> triangleCollection = new List<int[]>();
            try
            {
                var readedStrings = File.ReadAllLines(path);
                foreach (var str in readedStrings)
                {
                    var clearString = str.Split(' ');
                    triangleCollection.Add(Array.ConvertAll(clearString, s => int.Parse(s)));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
                Environment.Exit(0);
            }
                
            return triangleCollection;
        }
        
    }
}
