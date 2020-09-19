using NAWD.Utilities;
using System;

namespace NAWD
{
    class Program
    {
        static void Main(string[] args)
        {
            Test();
            Initialize();
        }

        static void Test()
        {
            Console.Title = "NAVER WEBTOON DOWNLOADER";
            Console.WriteLine("WebUtility Load...{0}", WebUtility.Test());

            Console.Clear();
            Console.Beep();
        }

        static void Initialize()
        {
            Console.Write("Enter Title ID : ");
            string titleId = Console.ReadLine();

            Console.Write("Enter start number : ");
            string stnum = Console.ReadLine();

            Console.Write("Enter end number : ");
            string ednum = Console.ReadLine();

            Console.Clear();
            Console.Beep();

            Selector(titleId, int.Parse(stnum), int.Parse(ednum));
        }
        
        static void Selector(string titleId, int stnum, int ednum)
        {
            string source = WebUtility.Load("https://comic.naver.com/webtoon/list.nhn?titleId=" + titleId);

            Console.WriteLine("--------------------------------------------------------------------------------");
            Console.WriteLine("Title : " + source.SingleParse("og:title\" content=\"", "\""));
            Console.WriteLine("Description : " + source.SingleParse("og:description\" content=\"", "\""));
            Console.WriteLine("Range : {0}~{1}({2})", stnum, ednum, ednum - stnum + 1);
            Console.WriteLine("--------------------------------------------------------------------------------");
            Console.WriteLine();

            Console.WriteLine("[1] - Auto Process.");
            Console.WriteLine("[2] - Manual Process.");
            Console.WriteLine("[0THER] - Exit.");
            Console.WriteLine();

            Console.Write("Choose number : ");
            int cnum = int.Parse(Console.ReadLine());

            if (cnum == 1)
            {
                Processor.AutomaticProcess(titleId, stnum, ednum);
            }
            else if (cnum == 2)
            {
                Processor.ManualProcess(stnum, ednum);
            }
            else
            {
                Environment.Exit(0);
            }
        }
    }
}
