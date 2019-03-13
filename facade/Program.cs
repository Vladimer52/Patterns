using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace facade
{
    // Думаю, большинство программистов согласятся со мной, что писать в Visual Studio код одно удовольствие по сравнению с тем,
    // как писался код ранее до появления интегрированных сред разработки.Мы просто пишем код, нажимаем на кнопку и все - приложение готово. 
    //В данном случае интегрированная среда разработки представляет собой фасад, который скрывает всю сложность процесса компиляции и запуска приложения
    class Program
    {
        static void Main(string[] args)
        {
            TextEditor textEditor = new TextEditor();

            Comiler comiler = new Comiler();

            CLR clr = new CLR();

            VSFacade ide = new VSFacade(textEditor, comiler, clr);

            Programmer programmer = new Programmer();

            programmer.CreateApplication(ide);

            Console.ReadKey();
        }
    }

    class TextEditor
    {
        public void CreateCode()
        {
            Console.WriteLine("Написание кода");

        }

        public void Save()
        {
            Console.WriteLine("Сохранение кода");
        }
    }

    class Comiler
    {
        public void Compile()
        {
            Console.WriteLine("Компиляция приложения");
        }

    }

    class CLR
    {
        public void Execute()
        {
            Console.WriteLine("Выполнение приложения");
        }

        public void Finish()
        {
            Console.WriteLine("завершение работы приложения");
        }
    }

    class VSFacade
    {
        TextEditor textEditor;
        Comiler compiler;
        CLR clr;

        public VSFacade(TextEditor te, Comiler compile, CLR clr)
        {
            this.textEditor = te;
            this.compiler = compile;
            this.clr = clr;
        }

        public void Start()
        {
            textEditor.CreateCode();
            textEditor.Save();
            compiler.Compile();
            clr.Execute();
        }
        public void Stop()
        {
            clr.Finish();
        }
    }

    class Programmer
    {
        public void CreateApplication(VSFacade facade)
        {
            facade.Start();
            facade.Stop();
        }
    }

}
