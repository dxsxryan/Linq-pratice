using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Linq練習_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            var sum = p.CreateList().Sum(x => x.Price);
            Console.WriteLine($"所有商品的總價格為：{sum}");


        }

        public List<Product> CreateList()
        {
            var path = @"Product.csv";
            using (StreamReader sr = new StreamReader(path))
            {
                List<string> read = new List<string>();
                //先讓product第一行的種類被讀掉
                string line = sr.ReadLine();

                //把所有元素都丟到Product陣列裡面
                var list = new List<Product>();
                while((line = sr.ReadLine()) != null)
                {
                    var product = line.Split(',');
                    var product_1 = new Product();
                    product_1.Number = product[0];
                    product_1.Name = product[1];
                    product_1.Count = int.Parse(product[2]);
                    product_1.Price= int.Parse(product[3]);
                    product_1.Description = product[4];
                    list.Add(product_1);
                }
                return list;
            }
        }
    }
}
