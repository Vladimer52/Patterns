using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory_Method
{
    class Program
    {
        static void Main(string[] args)
        {
            Developer dev = new PanelDeveloper("КирпичСтрой");
            House housePan = dev.Create();

            dev = new WoodDeveloper("Частный застройщик");
            House house = dev.Create();

            Console.ReadKey();
        }
    }

   

    abstract class Developer
    {
        public string Name { get; set; }

        public Developer(string name)
        {
            Name = name;
        }
        abstract public House Create();
    }

    class PanelDeveloper : Developer
    {
        public PanelDeveloper(string name):base(name)
        {

        }

        public override House Create()
        {
            return new PanelHouse();
        }
    }

    class WoodDeveloper : Developer
    {
        public WoodDeveloper(string name) : base(name)
        {

        }

        public override House Create()
        {
            return new WoodHouse();
        }
    }

    abstract class House { }

    class PanelHouse : House
    {
        public PanelHouse()
        {
            Console.WriteLine("Панельный дом построен");
        
        }
    }
    class WoodHouse : House
    {
        public WoodHouse()
        {
            Console.WriteLine("деревянный дом построен");

        }
    }
}
