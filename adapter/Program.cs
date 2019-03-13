using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adapter
{

    //у нас есть путешественник, который путешествует на машине. 
    //Но в какой-то момент ему приходится передвигаться по пескам пустыни, где он не может ехать на машине. 
    //Зато он может использовать для передвижения верблюда.
    //Однако в классе путешественника использование класса верблюда не предусмотрено, поэтому нам надо использовать адаптер
    class Program
    {
        static void Main(string[] args)
        {
            Driver driver = new Driver();

            Auto auto = new Auto();

            driver.Travel(auto);

            Camel camel = new Camel();
            ITransport camelTrasport = new CamelToTransportAdapter(camel);
            driver.Travel(camelTrasport);

            Console.ReadKey();
        }
    }

    interface ITransport
    {
        void Drive();

    }

    class Auto : ITransport
    {
        public void Drive()
        {
            Console.WriteLine("Машина едет по дороге");

        }
    }

    class Driver
    {
        public void Travel(ITransport transport)
        {
            transport.Drive();
        }
    }

    interface IAnimal
    {
        void Move();
    }

    class Camel : IAnimal
    {
        public void Move()
        {
            Console.Write("Верблюд едет по пескам пустыни");
        }
    }

    class CamelToTransportAdapter : ITransport
    {

        Camel camel;
        public CamelToTransportAdapter(Camel c)
        {
            camel = c;
        }
        public void Drive()
        {
            camel.Move();
        }
    }
}
