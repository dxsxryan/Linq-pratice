﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq練習_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var list = CreateList();

        }

        private List<Product> CreateList()
        {
            var path = @"Product.csv";
            using (StreamReader sr = new StreamReader(path))
            {
                List<string> read = new List<string>();
                //先讓product第一行的種類被讀掉
                string line = sr.ReadLine();
                string[] product = new string[5];
                while ((line = sr.ReadLine()) != null)
                {
                    read.Add(line);
                }
                return new List<Product>()
                {   
                    new Product
                        {
                            Number = int.Parse(product[0]),
                            Name = product[1],
                            Count = int.Parse(product[0]),
                            Price = int.Parse(product[3]),
                            Description = product[4]
                        }
                    
                    };
            }

        }
    }
}
