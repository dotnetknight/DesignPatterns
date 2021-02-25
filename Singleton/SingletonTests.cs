using Autofac;
using NUnit.Framework;
using static Singleton.Program;

namespace Singleton
{
    [TestFixture]
    public class SingletonTests
    {
        [Test]
        public void IsSingletonTest()
        {
            var db = SingletonDatabase.Instance;
            var db2 = SingletonDatabase.Instance;

            Assert.That(db, Is.SameAs(db2));
            Assert.That(SingletonDatabase.Count, Is.EqualTo(1));
        }

        [Test]
        public void SingletonTotalPopulationTest()
        {
            var recordFinder = new SingletonRecordFinder();
            var names = new[] { "New Delhi", "Beijing" };

            var totalPopulations = recordFinder.TotalPopulation(names);
            Assert.That(totalPopulations, Is.EqualTo(21542000 + 14200004));
        }

        [Test]
        public void ConfigurablePopulationTest()
        {
            var configurableRecordFinder = new ConfigurableRecordFinder(new DummyDatabase());
            var names = new[] { "alpha", "gama" };
            int totalPopulation = configurableRecordFinder.TotalPopulation(names);

            Assert.That(totalPopulation, Is.EqualTo(4));
        }
    }
}
