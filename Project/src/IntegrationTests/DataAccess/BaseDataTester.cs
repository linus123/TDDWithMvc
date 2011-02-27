using NUnit.Framework;

namespace IntegrationTests.DataAccess
{
    [TestFixture]
    public class BaseDataTester
    {
        private BaseDbUnitDataLoader _baseDbUnitDataLoader;

        public BaseDataTester()
        {
            _baseDbUnitDataLoader = new BaseDbUnitDataLoader();
        }

        [TestFixtureSetUp]
        public void BaseTesterFixtureSetup()
        {
            _baseDbUnitDataLoader.DatabaseFixtureSetUp();
        }
        
        [SetUp]
        public void BaseTesterSetUp()
        {
            _baseDbUnitDataLoader.DatabaseSetUp();
        }

        [TestFixtureTearDown]
        public void BaseTesterTearDown()
        {
            _baseDbUnitDataLoader.DatabaseSetUp();
        }
    }
}