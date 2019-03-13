using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command

//надо программно организовать включение и выключение прибора, например, телевизора
{
    class Program
    {
        static void Main(string[] args)
        {
            Pult pult = new Pult();
            TV tv = new TV();

            pult.SetCommand(new TVonCommand(tv));
            pult.PressButton();//включение
            pult.PressUndo();//выключение

            Console.ReadKey();
        }
    }

    interface ICommand
    {
        void Execute();
        void Undo();
    }


    //reciver - получатель
    class TV
    {
        public void On()
        {
            Console.WriteLine("Телевизор включен");
        }
        public void Off()
        {
            Console.WriteLine("Телевизор выключен");
        }
    }

    class TVonCommand : ICommand
    {
        TV tv;
        public TVonCommand(TV tvSet)
        {
            tv = tvSet;
        }

        public void Execute()
        {
            tv.On();
        }

        public void Undo()
        {
            tv.Off();
        }
    }

    //Invoker - инициатор

    class Pult
    {
        ICommand command;

        public Pult()
        {

        }

        public void SetCommand(ICommand com)
        {
            command = com;
        }

        public void PressButton()
        {
            command.Execute();
        }

        public void PressUndo()
        {
            command.Undo();
        }
    }
}
