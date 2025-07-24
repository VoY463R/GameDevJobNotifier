using GameDevJobNotifier;
using System.Net;
using System.Net.Mail;


WebScraper skillShot = new WebScraper("https://www.skillshot.pl/");
skillShot.XPath = "//table/tbody/tr[1]/td[2]";
string firstOffer = skillShot.FirstOffer();
bool areSame = true;
if (File.Exists("FirstOffer.txt"))
{
    areSame = OfferCheck.CompareOffers(firstOffer);
}
else
{
    File.WriteAllText("FirstOffer.txt", firstOffer);
}

if (areSame)
{
    string subject = "New GameDev offer has appeared!";
    string body = $"On Skillshot we have new offer: {File.ReadAllText("FirstOffer.txt")}";
    SMTP.SendEmail(subject, body);
}