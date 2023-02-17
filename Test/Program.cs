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
            //筆記
            //執行個體的存取路徑
            //Program p = new Program();
            //p.CreateList();

            //靜態成員的存取路徑
            //CreateList();
            //var product = new Product();
            //product.Number = "p001";
            //Console.WriteLine(product.Number);

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
