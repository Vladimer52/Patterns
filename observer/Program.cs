using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace observer

/*Допустим, у нас есть биржа, где проходят торги, и есть брокеры и банки,
 * которые следят за поступающей информацией и в зависимости от поступившей 
 * информации производят определенные действия:*/
{
    class Program
    {
        static void Main(string[] args)
        {

            Stock stock = new Stock();
            Bank bank = new Bank("ЮнитБанк", stock);
            Broker broker = new Broker("Иван Иваныч", stock);

            //имитация торгов:
            stock.Market();

            broker.StopTrade();

            stock.Market();

            Console.ReadKey();
        }
    }

    interface IObserver
    {
        void Update(Object ob);
    }

    interface IObservable
    {
        void RegusterObserver(IObserver o);
        void RemoveObserver(IObserver o);
        void NotifyObservers();
    }


    class Stock : IObservable //имитирует валютную биржу
    {
        StockInfo sInfo;
        List<IObserver> observers;
        public Stock()
        {
            observers = new List<IObserver>();
            sInfo = new StockInfo();
        }

        public void NotifyObservers()
        {
            foreach (IObserver o in observers)
            {
                o.Update(sInfo);
            }
        }

        public void RegusterObserver(IObserver o)
        {
            observers.Add(o);
        }

        public void RemoveObserver(IObserver o)
        {
            observers.Remove(o);
        }

        public void Market()
        {
            Random rand = new Random();
            sInfo.USD = rand.Next(20, 40);
            sInfo.Euro = rand.Next(30, 50);
            NotifyObservers();
        }
    }

    class StockInfo
    {
        public int USD { get; set; }
        public int Euro { get; set; }
    }

    class Broker : IObserver
    {
        public string Name { get; set; }
        IObservable stock;
        public Broker(string Name, IObservable obs)
        {
            this.Name = Name;
            stock = obs;
            stock.RegusterObserver(this);
        }

        public void Update(object ob)
        {
            StockInfo stockInfo = (StockInfo)ob;

            if (stockInfo.USD > 30) Console.WriteLine($"Брокер {this.Name} продает доллары; курс доллара: {stockInfo.USD}");

            else Console.WriteLine($"Брокер { this.Name} продает доллары; курс доллара: { stockInfo.USD}  ");
        }

        public void StopTrade()
        {
            stock.RemoveObserver(this);
            stock = null;
        }
    }

    class Bank : IObserver
    {
        public string Name { get; set; }
        IObservable stock;
        public Bank(string  name, IObservable obs)
        {
            this.Name = name;
            stock = obs;
            stock.RegusterObserver(this);

        }

        public void Update(object ob)
        {
            StockInfo sInfo = (StockInfo)ob;
            if (sInfo.Euro > 40) Console.WriteLine($"банк {this.Name} продает Евро; курс евро: {sInfo.Euro}");

            else Console.WriteLine($"Банк { this.Name} Покупает Евро; курс Евро: { sInfo.Euro} ");
        }
    }
}
