using System;
using HtmlAgilityPack;
using System.IO;
using System.Collections.Generic;
using System.Net;


namespace AzizKizginCase
{
    class Program
    {

        static void Main()
        {
            //Emlak Jet Website's link
            Uri URL = new Uri("https://www.emlakjet.com/satilik-konut/projeler/");

            WebClient client = new WebClient();

            string html = client.DownloadString(URL);
            HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument();
            document.LoadHtml(html);
            HtmlNodeCollection names = document.DocumentNode.SelectNodes("//div[@class='styles_title__1Jv1h']");
            HtmlNodeCollection prices = document.DocumentNode.SelectNodes("//div[@class='styles_price__1hrV1']");


            List<string>name= new List<string>();
            List<string>price= new List<string>();

            string namelist ="";
            string pricelist="";

            //conversing name data to string
            foreach (var item in names)
            {
                namelist = item.InnerText;

                name.Add(namelist);
                
            }

            //conversing price data to string
            foreach (var item in prices)
            {
                pricelist = item.InnerText;

                price.Add(pricelist);
            }


            //Writing datas on console and file;
            Console.WriteLine("Item Name - "+ "Price");
            string items = "Name - Price\n";
            File.AppendAllText("AllItems.txt", items);
            for (int i = 0; i < price.Count; i++)
            {
                Console.WriteLine(name[i] + " - " + price[i]);
                string itemToFile = name[i]+" - "+price[i];
                File.AppendAllText("AllItems.txt","\n");
                File.AppendAllText("AllItems.txt",itemToFile);
            }
        }
    }
}
