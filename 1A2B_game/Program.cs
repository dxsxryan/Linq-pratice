using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1A2B_game
{
    internal class Program
    {
        static void Main(string[] args)
        {
begin:      Console.WriteLine("歡迎來到1A2B猜數字遊戲～");
            Console.WriteLine("------");
            int[] random = Enumerable.Range(0, 10).OrderBy(x => Guid.NewGuid()).ToArray();
            int[] comp = random.Take(4).ToArray();
            foreach(var a in comp)
            {
                Console.Write(a);
            }
            Console.WriteLine();
            int[] ans = new int[4];
replay:     Console.Write("請輸入 4 個數字 :");
            for (int i = 0; i < 4; i++)
            {
                ans[i] = Console.Read() - 48;
            }
            Console.ReadLine();
            int A = 0; int B = 0;
            for (int i = 0; i < 4; i++)
            {
                if (ans[i] == comp[i]) { A++; }
                else if (comp.Contains(ans[i])){ B++; }
            }
            Console.WriteLine($"判定結果是{A}A{B}B");
            Console.WriteLine("------");
            if(A != 4)
            {
                goto replay;
            }
            Console.WriteLine("恭喜你！猜對了！！");
ask:        Console.WriteLine("要繼續遊玩嗎？(y/n)");
            var re = Console.ReadLine();
            if(re == "y")
            {
                goto begin;
            }
            else if(re == "n")
            {
                Console.WriteLine("遊戲結束，下次再來玩喔～");
            }
            else
            {
                Console.WriteLine("都說了只有Yes跟No可以選，不要亂打字啦");
                goto ask;
            }
        }
    }
}

