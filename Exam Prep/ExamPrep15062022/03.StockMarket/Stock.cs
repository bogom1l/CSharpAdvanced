using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace StockMarket
{
    public class Stock
    {
        public string CompanyName { get; set; }
        public string Director { get; set; }
        public decimal PricePerShare { get; set; }
        public int TotalNumberOfShare { get; set; }
        public decimal MarketCapitalization { get; set; }

        public Stock(string companyName, string director, decimal pricePerShare, int totalNumberOfShare)
        {
            CompanyName = companyName;
            Director = director;
            PricePerShare = pricePerShare;
            TotalNumberOfShare = totalNumberOfShare;
            MarketCapitalization = pricePerShare * totalNumberOfShare;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Company: {CompanyName}");
            sb.AppendLine($"Director: {Director}");
            sb.AppendLine($"Price per share: {PricePerShare}");
            sb.AppendLine($"Market capitalization: {MarketCapitalization}");

            return sb.ToString().TrimEnd();
        }
    }
}
