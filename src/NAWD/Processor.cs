using NAWD.Utilities;
using System;
using System.IO;

namespace NAWD
{
    internal static class Processor
    {
        static void CreateDirectory(string dir)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(dir);
            if (directoryInfo.Exists != true)
            {
                directoryInfo.Create();
            }
        }

        public static void AutomaticProcess(string titleId, int startEpisode, int endEpisode)
        {
            Console.Clear();
            Console.Beep();

            int episode;
            int image, imageCount;

            string rootPath = Environment.CurrentDirectory + "\\" + DateTime.Now.ToString("yyyyMMddHHmmss");
            CreateDirectory(rootPath);

            for (episode = startEpisode; episode <= endEpisode; episode++)
            {
                string source = WebUtility.Load("https://comic.naver.com/webtoon/detail.nhn?titleId=" + titleId + "&no=" + startEpisode);
                source = source.SingleParse("<div class=\"wt_viewer\"", "</div>");

                string[] imageArray = source.MultipleParse("src=\"", "\"");
                imageCount = imageArray.GetLength(0) - 2;

                string savePath = rootPath + "\\" + startEpisode;
                CreateDirectory(savePath);

                int a = 1;
                for (image = 0; image <= imageCount; image++)
                {
                    int remainingEpisodes = endEpisode - startEpisode;
                    Console.WriteLine("[Downloading " + episode + "/" + a + "(" + remainingEpisodes + ")" + "]" + " : " + imageArray[image]);
                    WebUtility.DownloadImage(imageArray[image], savePath + "\\" + image + ".png");
                    a++;
                }
                startEpisode++;
            }

            Console.ReadKey();
        }

        public static void ManualProcess(int startEpisode, int endEpisode)
        {
            Console.Clear();
            Console.Beep();

            int episode;
            int image, imageCount;

            string rootPath = Environment.CurrentDirectory + "\\" + DateTime.Now.ToString("yyyyMMddHHmmss");
            CreateDirectory(rootPath);

            for (episode = startEpisode; episode <= endEpisode; episode++)
            {
                string source = string.Empty;

                Console.Write("Enter HTML Source file path : ");
                string sourcePath = Console.ReadLine();
                using (StreamReader stream = new StreamReader(sourcePath))
                {
                    source = stream.ReadToEnd();
                    Console.WriteLine(stream.ReadToEnd());
                }

                source = source.SingleParse("<div class=\"wt_viewer\"", "</div>");

                string[] imageArray = source.MultipleParse("src=\"", "\"");
                imageCount = imageArray.GetLength(0) - 2;

                string savePath = rootPath + "\\" + startEpisode;
                CreateDirectory(savePath);

                int a = 1;
                for (image = 0; image <= imageCount; image++)
                {
                    int remainingEpisodes = endEpisode - startEpisode;
                    Console.WriteLine("[Downloading " + episode + "/" + a + "(" + remainingEpisodes + ")" + "]" + " : " + imageArray[image]);
                    WebUtility.DownloadImage(imageArray[image], savePath + "\\" + image + ".png");
                    a++;
                }
                startEpisode++;
            }

            Console.ReadKey();
        }
    }
}
