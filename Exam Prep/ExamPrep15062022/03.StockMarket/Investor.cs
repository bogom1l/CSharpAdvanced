using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace StockMarket
{
    public class Investor
    {
        private List<Stock> Portfolio { get; set; }
        public string FullName { get; set; }
        public string EmailAddress { get; set; }
        public decimal MoneyToInvest { get; set; }
        public string BrokerName { get; set; }

        public Investor(string fullName, string emailAddress, decimal moneyToInvest, string brokerName)
        {
            Portfolio = new List<Stock>();
            FullName = fullName;
            EmailAddress = emailAddress;
            MoneyToInvest = moneyToInvest;
            BrokerName = brokerName;
        }

        public int Count => this.Portfolio.Count; //?

        public void BuyStock(Stock stock)
        {
            if (stock.MarketCapitalization > 10000 && this.MoneyToInvest >= stock.PricePerShare)
            {
                this.MoneyToInvest -= stock.PricePerShare;
                Portfolio.Add(stock);
            }
        }
        public string SellStock(string companyName, decimal sellPrice)
        {
            Stock stock = this.Portfolio.FirstOrDefault(x => x.CompanyName == companyName);

            if (stock == null)
            {
                return $"{companyName} does not exist.";
            }
            if (sellPrice < stock.PricePerShare)
            {
                return $"Cannot sell {companyName}.";
            }
            this.Portfolio.Remove(stock);
            this.MoneyToInvest += sellPrice;
            return $"{companyName} was sold.";
        }

        public Stock FindStock(string companyName)
        {
            return this.Portfolio.FirstOrDefault(x => x.CompanyName == companyName);
        }

        public Stock FindBiggestCompany()
        {
            if (Portfolio.Count > 0)
            {
                return this.Portfolio.OrderByDescending(x => x.MarketCapitalization).FirstOrDefault();
            }
            return null;
        }

        public string InvestorInformation()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"The investor {this.FullName} with a broker {this.BrokerName} has stocks: ");
            foreach (var stock in Portfolio)
            {
                sb.AppendLine(stock.ToString());
            }
            return sb.ToString().TrimEnd();
        }

    }
}
