using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    class Program
    {
        static void Main(string[] args)
        {
            // создаем объект пекаря
            Baker baker = new Baker();

            BreadBuilder builder = new RyeBreadBuilder();
            Bread ryebread = baker.Bake(builder);
            Console.WriteLine(ryebread.ToString());
            builder = new WheatBreadBuilder();
            Bread wheatbread = baker.Bake(builder);
            Console.WriteLine(wheatbread.ToString());

            Console.ReadKey();

        }

    }

   abstract class BreadBuilder
    {
        public Bread bread { get; private set; }

        public void CreateBread()
        {
            bread = new Bread();
        }

        public abstract void SetFlour();
        public abstract void SetSalt();
        public abstract void SetAddivities();
    }

    class Baker //пекарь
    {
        public Bread Bake(BreadBuilder breadBuilder)
        {
            breadBuilder.CreateBread();
            breadBuilder.SetFlour();
            breadBuilder.SetSalt();
            breadBuilder.SetAddivities();
            return breadBuilder.bread;
        }
    }

    class RyeBreadBuilder: BreadBuilder
    {
        public override void SetFlour()
        {
            this.bread.flour = new Flour { Sort = "Пшеничная мука 1 сорт" };
        }
        public override void SetSalt()
        {
            this.bread.salt = new Salt();
        }

        public override void SetAddivities()
        {
            //не используется
        }
    }

    class WheatBreadBuilder : BreadBuilder
    {
        public override void SetFlour()
        {
            this.bread.flour = new Flour { Sort = "пшеничная мука высший сорт" };
        }

        public override void SetSalt()
        {
            this.bread.salt = new Salt();
        }

        public override void SetAddivities()
        {
            this.bread.addivities = new Addivities { Name = "Улучшатель хлебопекарный" };
        }

    }

    //Мука
    class Flour
    {
        //Какого сорта мука
        public string Sort { get; set; }


    }

    //соль
    class Salt
    {
       
    }

    //Пищевые добавки
    class Addivities
    {
        public string Name { get; set; }
    }

    class Bread
    {
        public Flour flour { get; set; }
        public Salt salt { get; set; }
        public Addivities addivities { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            if (flour != null) sb.Append(flour.Sort + "\n");
            if (salt != null) sb.Append("Соль \n");
            if (addivities != null) sb.Append("Добавки " + addivities.Name + "\n");
            return sb.ToString();
        }
    }
}
