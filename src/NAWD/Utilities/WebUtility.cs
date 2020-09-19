using System;
using System.Text;
using System.Net;
using System.IO;
using System.Linq;

namespace NAWD.Utilities
{
    internal static class WebUtility
    {
        internal static string Test()
        {
            if (!IsInternetConnected())
            {
                return "FAILURE";
            }
            else
            {
                return "OK";
            }
        }

        private static bool IsInternetConnected()
        {
            const string NCSI_TEST_URL = "http://www.msftncsi.com/ncsi.txt";
            const string NCSI_TEST_RESULT = "Microsoft NCSI";
            const string NCSI_DNS = "dns.msftncsi.com";
            const string NCSI_DNS_IP_ADDRESS = "131.107.255.255";

            try
            {
                // NCSI 테스트 링크 접속 확인.
                var webClient = new WebClient();
                string result = webClient.DownloadString(NCSI_TEST_URL);
                if (result != NCSI_TEST_RESULT)
                {
                    return false;
                }

                // NCSI DNS 주소 확인.
                var dnsHost = Dns.GetHostEntry(NCSI_DNS);
                if (dnsHost.AddressList.Count() < 0 || dnsHost.AddressList[0].ToString() != NCSI_DNS_IP_ADDRESS)
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }

            return true;
        }

        internal static string Load(string Url)
        {
            try
            {
                HttpWebRequest wReq;
                
                wReq = (HttpWebRequest)WebRequest.Create(Url);
                wReq.Method = "GET";
                HttpWebResponse wRes = (HttpWebResponse)wReq.GetResponse();

                if (wRes.StatusCode == HttpStatusCode.OK)
                {
                    StreamReader str = new StreamReader(wRes.GetResponseStream(), Encoding.UTF8);
                    return str.ReadToEnd();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Failed to receive web requests. Status code : {0}.", wRes.StatusCode);
                    Console.ResetColor();
                    return "WebHTML Load error occured.";
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Failed to recieve page.");
                Console.WriteLine(ex.StackTrace);
                Console.ResetColor();
            }

            return null;
        }

        internal static void DownloadImage(string Url, string FileName)
        {
            HttpWebRequest webReq = (HttpWebRequest)WebRequest.Create(Url);
            webReq.UserAgent = "Other";
            webReq.Referer = "https://www.naver.com/";
            HttpWebResponse webResponse = (HttpWebResponse)webReq.GetResponse();

            using (Stream receivedStream = webResponse.GetResponseStream())
            {
                byte[] read = new byte[512];

                // 스트림 내의 현재 위치는 읽은 바이트 수만큼 앞으로 이동(512 바이트 씩 Read)
                int bytes = receivedStream.Read(read, 0, 512);

                // 파일 객체 생성
                // 파일에 대해 Stream 을 제공하여, 읽기, 쓰기 작업을 모두 지원
                Encoding encode;
                encode = Encoding.Default;

                using (FileStream fileStream = new FileStream(FileName, FileMode.OpenOrCreate, FileAccess.Write))
                {
                    // FileStream에 byte 쓰기
                    // 스트림의 끝에 도달 하면 0 이 Return
                    while (bytes > 0)
                    {
                        // 버퍼의 데이터를 사용하여 이 스트림에 바이트 블록을 씀
                        fileStream.Write(read, 0, bytes);
                        bytes = receivedStream.Read(read, 0, 512);

                    }
                    // Save File
                    using (BinaryWriter fileWriter = new BinaryWriter(fileStream, encode))
                    {
                        fileWriter.Close();
                    }

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("OK");
                    Console.ResetColor();
                }
            }
        }
    }
}
