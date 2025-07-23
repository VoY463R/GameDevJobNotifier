using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace GameDevJobNotifier
{
    public class WebScraper
    {
        public HttpClient HttpClient { get; private set; }
        public string Html { get; private set; }
        public HtmlDocument HtmlDocument { get; private set; } 

        public string XPath { get; set; }

        public WebScraper(string url)
        {
            
            HttpClient = new HttpClient();
            HtmlDocument = new HtmlDocument();
            Html = HttpClient.GetStringAsync(url).Result;
            HtmlDocument.LoadHtml(Html);

        }

        public string FirstOffer()
        {
            var firstOffer = HtmlDocument.DocumentNode.SelectSingleNode(XPath);
            return firstOffer.InnerText;
        }

    }
}
