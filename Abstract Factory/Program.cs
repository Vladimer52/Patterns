using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract_Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            Hero Elf = new Hero(new ElfFActory());
            Elf.Hit();
            Elf.Run();

            Hero Voin = new Hero(new VoinFactory());
            Voin.Hit();
            Voin.Run();
            Console.ReadKey();
        }
    }

    abstract class Weapon
    {
        public abstract void Hit();
    }

    abstract class Movement
    {
        public abstract void Move();
    }

    class Arbalet : Weapon
    {
        public override void Hit()
        {
            Console.WriteLine("Стреляет из лука");
        }
    }

    class Sword : Weapon
    {
        public override void Hit()
        {
            Console.WriteLine("Бьет мечом");
        }
    }

    class FlyMovment : Movement
    {
        public override void Move()
        {
            Console.WriteLine("летим");
        }
    }

    class RunMovment : Movement
    {
        public override void Move()
        {
            Console.WriteLine("Бежим");
        }
    }

    abstract class HeroFactory
    {
        public abstract Movement CreateMovement();
        public abstract Weapon CreateWeapon();
    }

    class ElfFActory : HeroFactory
    {
        public override Movement CreateMovement()
        {
            return new FlyMovment();
        }

        public override Weapon CreateWeapon()
        {
            return new Arbalet();
        }
    }

    class VoinFactory : HeroFactory
    {
        public override Movement CreateMovement()
        {
            return new RunMovment();
        }

        public override Weapon CreateWeapon()
        {
            return new Sword();
        }
    }

    class Hero
    {
        private Weapon _weapon;
        private Movement _movement;

        public Hero(HeroFactory factory)
        {
            _weapon = factory.CreateWeapon();
            _movement = factory.CreateMovement();
        }

        public void Run()
        {
            _movement.Move();
        }

        public void Hit()
        {
            _weapon.Hit();
        }
    }
}
