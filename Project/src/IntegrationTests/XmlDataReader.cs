using IntegrationTests.DataAccess;
using NUnit.Framework;

namespace IntegrationTests
{
    public class XmlDataReader : BaseDbUnitDataLoader
    {
        [Test]
        [Explicit]
        public void ReadDataFromLocalDatabase()
        {
            GetMyTestDataXmlFile();
        }            
    }
}