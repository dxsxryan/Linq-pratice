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
            var avg = p.CreateList().Average(x => x.Price);
            var sum_count = p.CreateList().Sum(x => x.Count);
            var avg_count = p.CreateList().Average(x => x.Count);
            var exp = p.CreateList().Max(x => x.Price);
            var exp_find = p.CreateList().FirstOrDefault(x => x.Price == exp);
            var chp = p.CreateList().Min(x => x.Price);
            var chp_find = p.CreateList().FirstOrDefault(x => x.Price == chp);
            var sum_3C = p.CreateList().Where((x) => x.Description == "3C").Sum((x) => x.Price);
            var sum_other = p.CreateList().Where((x) => x.Description == "飲料" || x.Description == "食品").Sum((x) => x.Price);
            var find = p.CreateList().Where((x) => x.Description == "食品");
            var gp = p.CreateList().GroupBy((x) => x.Description);

            Console.WriteLine($"所有商品的總價格為：{sum}\n");
            Console.WriteLine($"所有商品的平均價格為：{avg:n}\n");
            Console.WriteLine($"所有商品的總數為：{sum_count}\n");
            Console.WriteLine($"所有商品的平均數為：{avg_count:n} \n");
            Console.WriteLine($"最貴的商品為：{exp_find.Name}\n");
            Console.WriteLine($"最便宜的商品為：{chp_find.Name} \n");
            Console.WriteLine($"產品類別為 3C 的商品總價為：{sum_3C} \n");
            Console.WriteLine($"產品類別為 飲料 和 食品 的商品總價為：{sum_other} \n");
            Console.WriteLine($"商品種類為 食品，而且商品數量大於100的商品為：\n");
            foreach (var a in find) 
            {
                if(a.Count > 100)
                {
                    Console.WriteLine($"{a.Name}\n");
                }
            }
            Console.WriteLine($"各個商品類別中，商品的價格大於 1000 的商品為：\n");
            foreach (var a in gp)
            {
                Console.WriteLine($"商品種類：{a.Key}\n");
                foreach(var b in a)
                {
                    if(b.Price > 1000)
                    {
                        Console.WriteLine($"{b.Name}\n");
                    }
                }
            }





        }

        public List<Product> CreateList()
        {
            var path = @"Product.csv";
            using (StreamReader sr = new StreamReader(path))
            {
                List<string> read = new List<string>();
                //先讓product第一行的種類被讀掉
                string line = sr.ReadLine();

                //把所有元素都丟到Product清單裡面
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
