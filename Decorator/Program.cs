using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    class Program
    {
        //у нас есть пиццерия, которая готовит различные типы пицц с различными добавками. 
        //Есть итальянская, болгарская пиццы. К ним могут добавляться помидоры, сыр и т.д. 
        //И в зависимости от типа пицц и комбинаций добавок пицца может иметь разную стоимость
        static void Main(string[] args)
        {

            Pizza Pizza1 = new ItalianPizza();
            Pizza1 = new TomatoPizza(Pizza1);
            Console.WriteLine($"Название: {Pizza1.Name}");
            Console.WriteLine($"Цена: {Pizza1.GetCost()}");

            Pizza pizza2 = new ItalianPizza();
            pizza2 = new CheesePizza(pizza2);// итальянская пиццы с сыром
            Console.WriteLine("Название: {0}", pizza2.Name);
            Console.WriteLine("Цена: {0}", pizza2.GetCost());

            Pizza pizza3 = new BulgarianPizza();
            pizza3 = new TomatoPizza(pizza3);
            pizza3 = new CheesePizza(pizza3);// болгарская пиццы с томатами и сыром
            Console.WriteLine("Название: {0}", pizza3.Name);
            Console.WriteLine("Цена: {0}", pizza3.GetCost());

            Console.ReadKey();
        }
    }

    abstract class Pizza
    {
        public Pizza(string n)
        {
            this.Name = n;
        }
        public String Name { get; set; }

        public abstract int GetCost();
    }

    class ItalianPizza: Pizza
    {
        public ItalianPizza():base("Итальянская пицца")
        {

        }

        public override int GetCost()
        {
            return 10;
        }
    }

    class BulgarianPizza:Pizza
    {
        public BulgarianPizza():base("Болгарская пицца")
        {

        }

        public override int GetCost()
        {
            return 8;
        }

    }

    abstract class PizzaDecorator : Pizza
    {
        protected Pizza pizza;

        public PizzaDecorator(string n, Pizza pizza): base(n)
        {
            this.pizza = pizza;
        }

    }


    class TomatoPizza : PizzaDecorator
    {

        public TomatoPizza(Pizza p) : base(p.Name + ", с томатами", p)
        {

        }

        public override int GetCost()
        {
            return pizza.GetCost() + 3;
        }
    }

    class CheesePizza:PizzaDecorator
    {
        public CheesePizza(Pizza p) : base(p.Name + ", с сыром", p)
        { }

        public override int GetCost()
        {
            return pizza.GetCost() + 5;
        }
    }

}
