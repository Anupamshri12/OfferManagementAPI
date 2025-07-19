using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace PiePayAssignment.Enitites
{
  

    public class OfferModel
    {
       
            public required string adjustment_type { get; set; }
            public required string adjustment_sub_type { get; set; }
           
            public required string adjustment_id { get; set; }
            public required string title { get; set; }
            public required string summary { get; set; }
            public required Contributors contributors { get; set; }

            public required bool is_discover { get; set; }
            public required List<string> display_tags { get; set; }


        
    }

    public class Contributors
    {
        public required List<string> payment_instrument { get; set; }
        public required List<string> banks { get; set; }
        public required List<string> emi_months { get; set; }
        public required List<string>card_networks{ get; set; }

    }

    public static class GetDiscount
    {
        public static decimal getOfferDiscount(string summary, int amountToPay)
        {
            summary = summary.ToLower();
            var percentMatch = Regex.Match(summary, @"(\d+)%\s*cashback.*?up\s*(?:to|upto)\s*[₹rs\.]*\s*(\d+[,\d]*)", RegexOptions.IgnoreCase);

            if (percentMatch.Success)
            {
                var percent = decimal.Parse(percentMatch.Groups[1].Value);
                var max = decimal.Parse(percentMatch.Groups[2].Value.Replace(",", ""));
                var calc = (percent / 100) * amountToPay;
                return Math.Min(calc, max);
            }


            // 2. Flat cashback with min order
            var flatMinMatch = Regex.Match(summary, @"flat\s*[₹rs\.]*\s*(\d+).*?min\s*order\s*value\s*[₹rs\.]*\s*(\d+)");
            if (flatMinMatch.Success)
            {
                var cashback = decimal.Parse(flatMinMatch.Groups[1].Value);
                var minOrder = decimal.Parse(flatMinMatch.Groups[2].Value);
                return amountToPay >= minOrder ? cashback : 0;
            }

            // 3. Flat discount with min order
            var flatOffWithMin = Regex.Match(summary, @"₹\s*(\d+)\s*off.*?(min(?:imum)?\s*order(?:\s*value)?\s*(?:of)?\s*[₹rs\.]*\s*(\d+))", RegexOptions.IgnoreCase);
            if (flatOffWithMin.Success)
            {
                var discount = decimal.Parse(flatOffWithMin.Groups[1].Value);
                var minOrder = decimal.Parse(flatOffWithMin.Groups[3].Value.Replace(",", ""));
                return amountToPay >= minOrder ? discount : 0;
            }

            // 4. Plain flat discount
            var flatMatch = Regex.Match(summary, @"₹\s*(\d+)\s*off");
            if (flatMatch.Success)
            {
                var discount = decimal.Parse(flatMatch.Groups[1].Value);

                // Try to find a min order in the same summary
                var minOrderMatch = Regex.Match(summary, @"min(?:imum)?\s*order(?:\s*value)?\s*(?:of)?\s*[₹rs\.]*\s*(\d+)", RegexOptions.IgnoreCase);
                if (minOrderMatch.Success)
                {
                    var minOrder = decimal.Parse(minOrderMatch.Groups[1].Value.Replace(",", ""));
                    return amountToPay >= minOrder ? discount : 0;
                }

                // No min order requirement found
                return discount;
            }
            return -1;

        }

    }


}

