﻿using System;
using System.Collections.Generic;

namespace Factories.AbstractFactory
{
    //Give out abstract objects rather than conrecte objects.
    public interface IHotDrink
    {
        void Consume();
    }

    internal class Tea : IHotDrink
    {
        public void Consume()
        {
            Console.WriteLine("This tea is nice, but i'd prefer it with milk.");
        }
    }

    internal class Coffe : IHotDrink
    {
        public void Consume()
        {
            Console.WriteLine("This coffe is sensetional!");
        }
    }

    public interface IHotDrinkFactory
    {
        IHotDrink Prepare(int amount);
    }

    internal class TeaFactory : IHotDrinkFactory
    {
        public IHotDrink Prepare(int amount)
        {
            Console.WriteLine($"Put in in the bag, boil water, pour {amount} ml, enjoy");
            return new Tea();
        }
    }

    internal class CoffeFactory : IHotDrinkFactory
    {
        public IHotDrink Prepare(int amount)
        {
            Console.WriteLine($"Grind some beans, boil water, pour {amount} ml, enjoy");
            return new Coffe();
        }
    }

    public class HotDrinkMachine
    {
        private readonly List<Tuple<string, IHotDrinkFactory>> namedFactories = new List<Tuple<string, IHotDrinkFactory>>();

        public HotDrinkMachine()
        {
            foreach (var t in typeof(HotDrinkMachine).Assembly.GetTypes())
            {
                if (typeof(IHotDrinkFactory).IsAssignableFrom(t) && !t.IsInterface)
                {
                    namedFactories.Add(Tuple.Create(
                      t.Name.Replace("Factory", string.Empty), (IHotDrinkFactory)Activator.CreateInstance(t)));
                }
            }
        }

        public IHotDrink MakeDrink()
        {
            Console.WriteLine("Available drinks");

            for (var index = 0; index < namedFactories.Count; index++)
            {
                var tuple = namedFactories[index];
                Console.WriteLine($"{index}: {tuple.Item1}");
            }

            while (true)
            {
                string specifiedAmount;

                if ((specifiedAmount = Console.ReadLine()) != null
                    && int.TryParse(specifiedAmount, out int i)
                    && i >= 0
                    && i < namedFactories.Count)
                {
                    Console.Write("Specify amount: ");

                    specifiedAmount = Console.ReadLine();

                    if (specifiedAmount != null
                        && int.TryParse(specifiedAmount, out int amount)
                        && amount > 0)
                    {
                        return namedFactories[i].Item2.Prepare(amount);
                    }
                }

                Console.WriteLine("Incorrect input, try again.");
            }
        }
    }

    class AbstractFactory
    {
        static void Main(string[] args)
        {
            var machine = new HotDrinkMachine();

            IHotDrink drink = machine.MakeDrink();
            drink.Consume();
        }
    }
}


//Version 2

/*
 using System;
using System.Collections.Generic;

namespace Factories.AbstractFactory
{
    public interface IBottle
    {
        public void Interact(IWater water);
    }

    public class CocaColaBottle : IBottle
    {
        public string Name { get; set; }
        public string Color { get; set; }

        public void Interact(IWater water)
        {
            Console.WriteLine(this + " interacts with " + water);
        }
    }

    public class PepsiBottle : IBottle
    {
        public string Name { get; set; }
        public string Color { get; set; }

        public void Interact(IWater water)
        {
            Console.WriteLine(this + " interacts with " + water);
        }
    }

    public interface IWater
    {

    }

    public class CocaColaWater : IWater
    {

    }

    public class PepsiWater : IWater
    {

    }

    public interface IDrinkFactory
    {
        public IWater CreateWater();
        public IBottle CreateBottle();
    }

    public class CocaColaFactory : IDrinkFactory
    {
        public IBottle CreateBottle()
        {
            return new CocaColaBottle()
            {
                Color = "Red",
                Name = "Coca-Cola"
            };
        }

        public IWater CreateWater()
        {
            return new CocaColaWater();
        }
    }

    public class PepsiFactory : IDrinkFactory
    {
        public IBottle CreateBottle()
        {
            return new PepsiBottle()
            {
                Color = "Blue",
                Name = "Pepsi"
            };
        }

        public IWater CreateWater()
        {
            return new PepsiWater();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var pepsiBottle = new PepsiFactory().CreateBottle();
            var pepsiWater = new PepsiFactory().CreateWater();

            var cocaColaBottle = new CocaColaFactory().CreateBottle();
            var cocaColaWater = new CocaColaFactory().CreateWater();

            cocaColaBottle.Interact(cocaColaWater);
            pepsiBottle.Interact(pepsiWater);
        }
    }
}
 */