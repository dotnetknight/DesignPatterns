using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MoreLinq;

namespace Singleton
{
    //We need to use the Singleton Design Pattern in C# when we need to ensures that only one instance of a particular class is going to be created and then provide simple global access to that instance for the entire application.

    //Some Real-time scenarios where you can use the Singleton Design Pattern:
    // Service Proxies: As we know invoking a Service API is an extensive operation in an application.The process that taking most of the time is creating the Service client in order to invoke the service API. If you create the Service proxy as Singleton then it will improve the performance of your application.

    //  Facades: You can also create the Database connections as Singleton which can improve the performance of the application.

    // Logs: In an application, performing the I/O operation on a file is an expensive operation.If you create your Logger as Singleton then it will improve the performance of the I/O operation.

    // Data sharing: If you have any constant values or configuration values then you can keep these values in Singleton So that these can be read by other components of the application.

    // Caching: As we know fetching the data from a database is a time-consuming process. In your application, you can cache the master and configuration in memory which will avoid the DB calls.In such situations, the Singleton class can be used to handle the caching with thread synchronization in an efficient manner which drastically improves the performance of the application.


    class Program
    {
        public interface IDatabase
        {
            int Population(string name);
        }

        public class SingletonDatabase : IDatabase
        {
            private static int instanceCount;
            private Dictionary<string, int> capitals;
            private static Lazy<SingletonDatabase> instance = new Lazy<SingletonDatabase>(() => new SingletonDatabase());

            public static SingletonDatabase Instance => instance.Value;
            public static int Count => instanceCount;

            private SingletonDatabase()
            {
                instanceCount++;
                Console.WriteLine("Initializing database");

                capitals = File.ReadAllLines(
                 Path.Combine(
                   new FileInfo(typeof(IDatabase).Assembly.Location).DirectoryName, "capitals.txt")
                 )
                 .Batch(2)
                 .ToDictionary(
                   list => list.ElementAt(0).Trim(),
                   list => int.Parse(list.ElementAt(1)));
            }

            public int Population(string name)
            {
                return capitals[name];
            }
        }

        public class OrdinaryDatabase : IDatabase
        {
            private readonly Dictionary<string, int> capitals;

            private OrdinaryDatabase()
            {
                Console.WriteLine("Initializing database");

                capitals = File.ReadAllLines(
                 Path.Combine(
                   new FileInfo(typeof(IDatabase).Assembly.Location).DirectoryName, "capitals.txt")
                 )
                 .Batch(2)
                 .ToDictionary(
                   list => list.ElementAt(0).Trim(),
                   list => int.Parse(list.ElementAt(1)));
            }

            public int Population(string name)
            {
                return capitals[name];
            }
        }

        public class SingletonRecordFinder
        {
            public int TotalPopulation(IEnumerable<string> names)
            {
                int result = 0;
                foreach (var name in names)
                    result += SingletonDatabase.Instance.Population(name);

                return result;
            }
        }

        public class ConfigurableRecordFinder
        {
            private readonly IDatabase database;

            public ConfigurableRecordFinder(IDatabase database)
            {
                this.database = database;
            }

            public int TotalPopulation(IEnumerable<string> names)
            {
                int result = 0;
                foreach (var name in names)
                    result += database.Population(name);

                return result;
            }
        }

        public class DummyDatabase : IDatabase
        {
            public int Population(string name)
            {
                return new Dictionary<string, int>
                {
                    ["alpha"] = 1,
                    ["beta"] = 2,
                    ["gama"] = 3
                }[name];
            }
        }

        //static void Main(string[] args)
        //{
        //    var db = SingletonDatabase.Instance;

        //    string city = "Tokyo";
        //    int population = db.Population(city);

        //    Console.WriteLine($"{city} has population {population}");

        //    Console.ReadLine();
        //}
    }
}

//DEMO2

/*
   public class Foo
    {
        public EventBroker Broker;

        public Foo(EventBroker broker)
        {
            Broker = broker ?? throw new ArgumentNullException(paramName: nameof(broker));
        }
    }

    public class EventBroker
    {

    }

    // socially acceptable 
    public class SingletonDI
    {
        static void Main()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<EventBroker>().SingleInstance();
            builder.RegisterType<Foo>();

            using (var c = builder.Build())
            {
                var foo1 = c.Resolve<Foo>();
                var foo2 = c.Resolve<Foo>();

                Console.WriteLine(ReferenceEquals(foo1, foo2));
                Console.WriteLine(ReferenceEquals(foo1.Broker, foo2.Broker));
            }

        }
    }
 */


//DEMO 3

/*
 public sealed class Singleton
    {
        private static int counter = 0;
        private static Singleton instance = null;
        public static Singleton GetInstance
        {
            get
            {
                if (instance == null)
                    instance = new Singleton();
                return instance;
            }
        }
        
        private Singleton()
        {
            counter++;
            Console.WriteLine("Counter Value " + counter.ToString());
        }
        public void PrintDetails(string message)
        {
            Console.WriteLine(message);
        }
    }

class Program
    {
        static void Main(string[] args)
        {
            Singleton fromTeachaer = Singleton.GetInstance;
            fromTeachaer.PrintDetails("From Teacher");
            Singleton fromStudent = Singleton.GetInstance;
            fromStudent.PrintDetails("From Student");
            Console.ReadLine();
        }
    }
 */