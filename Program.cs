using GameDevJobNotifier;
using HtmlAgilityPack;

WebScraper skillShot = new WebScraper("https://www.skillshot.pl/");
skillShot.XPath = "//table/tbody/tr[1]/td[2]/a";
string firstOffer = skillShot.FirstOffer();

