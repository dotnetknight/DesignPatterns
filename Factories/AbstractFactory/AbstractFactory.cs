using System;
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
                string s;

                if ((s = Console.ReadLine()) != null
                    && int.TryParse(s, out int i)
                    && i >= 0
                    && i < namedFactories.Count)
                {
                    Console.Write("Specify amount: ");

                    s = Console.ReadLine();

                    if (s != null
                        && int.TryParse(s, out int amount)
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