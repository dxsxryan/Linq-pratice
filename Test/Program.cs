using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var path = @"Product.csv";
            using (StreamReader sr = new StreamReader(path))
            {
                List<string> read = new List<string>();
                //先讓product第一行的種類被讀掉
                string line = sr.ReadLine();
                string[] product = new string[] {};
                line = sr.ReadToEnd();
                product = line.Split(',');
                for(int i = 0; i < product.Length; i++)
                {
                    Console.WriteLine(product[i]);
                }
                
            }
        }
    }
}
