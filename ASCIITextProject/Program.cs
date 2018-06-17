using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ASCIITextProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "If you can read this then good for you";
            Console.ForegroundColor = ConsoleColor.Green;
            //Thread.Sleep(2000);
            DelayedPrintout("Hi Alyssa!");
            DelayedPrintout("Take your Iron Pill!");
            DelayedPrintout("Also, Have a GREAT FUCKING day!");
            DelayedPrintout(":)");

            Console.ReadLine();
        }

        public static void DelayedPrintout(String text)
        {
            var mainText = FixString(text);

            var result = RetrieveAsciiText(mainText);
            var temp = result.ToCharArray();
            foreach (Char c in temp)
            {
                Console.Write(c);
                Thread.Sleep(2);
            }
            Thread.Sleep(750);

        }

        public static string FixString(String text)
        {
            text.Replace(" ", "+");
            return text;
        }

        public static string RetrieveAsciiText(String text)
        {
            string result = string.Empty;
            string url = @"http://artii.herokuapp.com/make?text=" + text + @"&font=6x10";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                result = reader.ReadToEnd();
            }

            
            return result;
        }
    }
}
