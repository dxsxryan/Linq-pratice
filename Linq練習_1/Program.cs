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
            var list = p.CreateList();

            //第一題
Step1:      var sum = list.Sum(x => x.Price);
            Console.WriteLine($"所有商品的總價格為：{sum}\n");

            //第二題
            var avg = list.Average(x => x.Price);
            Console.WriteLine($"所有商品的平均價格為：{avg:n}\n");

            //第三題
            var sum_count = list.Sum(x => x.Count);
            Console.WriteLine($"所有商品的總數為：{sum_count}\n");

            //第四題
            var avg_count = list.Average(x => x.Count);
            Console.WriteLine($"所有商品的平均數為：{avg_count:n} \n");

            //第五題
            var exp = list.Max(x => x.Price);
            var exp_find = list.FirstOrDefault(x => x.Price == exp);
            Console.WriteLine($"最貴的商品為：{exp_find.Name}\n");
            
            //第六題
            var chp = list.Min(x => x.Price);
            var chp_find = list.FirstOrDefault(x => x.Price == chp);
            Console.WriteLine($"最便宜的商品為：{chp_find.Name} \n");

            //第七題
            var sum_3C = list.Where((x) => x.Description == "3C").Sum((x) => x.Price);
            Console.WriteLine($"產品類別為 3C 的商品總價為：{sum_3C} \n");

            //第八題
            var sum_other = list.Where((x) => x.Description == "飲料" || x.Description == "食品").Sum((x) => x.Price);
            Console.WriteLine($"產品類別為 飲料 和 食品 的商品總價為：{sum_other} \n");

            //第九題
            var find = list.Where((x) => x.Description == "食品");
            Console.WriteLine($"商品種類為 食品，而且商品數量大於100的商品為：\n");
            foreach (var a in find)
            {
                if (a.Count > 100)
                {
                    Console.WriteLine($"{a.Name}\n");
                }
            }

            //第十題
            var gp = list.GroupBy((x) => x.Description);
            Console.WriteLine($"各個商品類別中，商品的價格大於 1000 的商品為：\n");
            foreach (var a in gp)
            {
                Console.WriteLine($"商品種類：{a.Key}\n");
                foreach (var b in a)
                {
                    if (b.Price > 1000)
                    {
                        Console.WriteLine($"{b.Name}\n");
                    }
                }
            }

            //第十一題
            var filter_3C = list.Where((x) => x.Price > 1000　&& x.Description == "3C");
            var filter_drink = list.Where((x) => x.Price > 1000 && x.Description == "飲料");
            var filter_food = list.Where((x) => x.Price > 1000 && x.Description == "食品");
            Console.WriteLine($"各個商品類別中，商品的價格大於 1000 的商品平均價格為：\n");
            int avg_3C1000 = 0; int i = 0;
            foreach (var a in filter_3C)
            {
                i++;
                avg_3C1000 += a.Price;
            }
            if (i == 0) { Console.WriteLine($"3C：沒有超過 1000 的商品\n"); }
            else { Console.WriteLine($"3C：{avg_3C1000 / i}\n"); }
            int avg_drink1000 = 0; i = 0;
            foreach (var a in filter_drink)
            {
                i++;
                avg_drink1000 += a.Price;
            }
            if (i == 0) { Console.WriteLine($"飲料：沒有超過 1000 的商品\n"); }
            else { Console.WriteLine($"飲料：{avg_drink1000 / i}\n"); }
            int avg_food1000 = 0; i = 0;
            foreach (var a in filter_food)
            {
                i++;
                avg_food1000 += a.Price;
                Console.WriteLine(a.Name);
            }
            if (i == 0) { Console.WriteLine($"食品：沒有超過 1000 的商品\n"); }
            else { Console.WriteLine($"食品：{avg_food1000 / i}\n"); }

            //第十二題
            var odd = list.OrderByDescending((x) => x.Price);
            Console.WriteLine("依照商品的價格由高到低分別為：\n");
            foreach (var a in odd)
            {
                Console.WriteLine($"{a.Name} - {a.Price} 元\n");
            }

            //第十三題
            var od = list.OrderBy((x) => x.Count);
            Console.WriteLine("依照商品的數量由少到多的順序為：\n");
            foreach (var a in od)
            {
                Console.WriteLine($"{a.Name} - 數量 ： {a.Count}\n");
            }

            //第十四題
            var exp_3C = list.Where((x) => x.Description == "3C").Max((x) => x.Price);
            var exp_drink = list.Where((x) => x.Description == "飲料").Max((x) => x.Price);
            var exp_food = list.Where((x) => x.Description == "食品").Max((x) => x.Price);
            Console.WriteLine($"3C中最貴的價格為{exp_3C}\n");
            Console.WriteLine($"飲料中最貴的價格為{exp_drink}\n");
            Console.WriteLine($"食品中最貴的價格為{exp_food}\n");

            //第十五題
            var chp_3C = list.Where((x) => x.Description == "3C").Min((x) => x.Price);
            var chp_drink = list.Where((x) => x.Description == "飲料").Min((x) => x.Price);
            var chp_food = list.Where((x) => x.Description == "食品").Min((x) => x.Price);
            Console.WriteLine($"3C中最便宜的價格為{chp_3C}\n");
            Console.WriteLine($"飲料中最便宜的價格為{chp_drink}\n");
            Console.WriteLine($"食品中最便宜的價格為{chp_food}\n");

            //第十六題
            var prdt_10000 = list.Where((x) => x.Price <= 10000);
            Console.WriteLine("在所有商品中， 價格小於等於10000的商品有\n");
            foreach(var a in prdt_10000)
            {
                Console.WriteLine($"{a.Name} - {a.Price} 元\n");
            }

            //第十七題
            Console.WriteLine("上面的資料看好了 請按下任意鍵進入分頁選擇器\n");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("總共有5個分頁，第一個分頁就會回到前面1~16題的題目\n");
            Console.WriteLine("後面的2~5的分頁才是其他東西\n");
Step2:      Console.Write("請輸入想要進入的分頁(要結束請按Q)：");
            string page = Console.ReadLine();
            if (page == "1")
            {
                Console.WriteLine("那就往前跳到剛剛的題目\n");
                goto Step1;
            }
            else if (page == "2")
            {
                Console.Clear();
                for (i = 0; i < 4; i++)
                {
                    var good_4 = list.ElementAt(i);
                    Console.WriteLine($"{good_4.Number} {good_4.Name} {good_4.Price} {good_4.Count} {good_4.Description}\n");
                }
                goto Step2;
            }
            else if(page == "3")
            {
                Console.Clear();
                for (i = 4; i < 8; i++)
                {
                    var good_4 = list.ElementAt(i);
                    Console.WriteLine($"{good_4.Number} {good_4.Name} {good_4.Price} {good_4.Count} {good_4.Description}\n"); 
                }
                goto Step2;
            }
            else if (page == "4")
            {
                Console.Clear();
                for (i = 8; i < 12; i++)
                {
                    var good_4 = list.ElementAt(i);
                    Console.WriteLine($"{good_4.Number} {good_4.Name} {good_4.Price} {good_4.Count} {good_4.Description}\n"); 
                }
                goto Step2;
            }
            else if (page == "5")
            {
                Console.Clear();
                for (i = 12; i < 16; i++)
                {
                    var good_4 = list.ElementAt(i);
                    Console.WriteLine($"{good_4.Number} {good_4.Name} {good_4.Price} {good_4.Count} {good_4.Description}\n");
                }
                goto Step2;
            }
            else if(page == "q" || page == "Q")
            {
                Console.Clear();
                Console.WriteLine("88辣");
            }
            else
            {
                Console.Clear();
                Console.WriteLine("都說了只有5個分頁了\n");
                Console.WriteLine("還輸入其他東西\n");
                Console.ReadKey();
                Console.WriteLine("很皮喔\n");
                goto Step2;
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
