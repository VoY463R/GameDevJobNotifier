using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevJobNotifier
{
    public static class OfferCheck
    {
        public static string oldfirstOffer;

        static OfferCheck()
        {
            try
            {
                oldfirstOffer = File.ReadAllText("FirstOffer.txt");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"There was a problem with opening file: {ex.Message}");
            }
        }

        public static bool CompareOffers(string newFirstOffer)
        {
            if (oldfirstOffer == newFirstOffer)
            {
                Console.WriteLine("The newest offer is still the same");
                return false;
            }
            else
            {
                Console.WriteLine("The newest offer has been changed!");
                File.WriteAllText("FirstOffer.txt", newFirstOffer);
                return true;
            }
        }
    }
}
