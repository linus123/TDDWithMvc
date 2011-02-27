using NDbUnit.Core.SqlClient;

namespace IntegrationTests.DataAccess
{
    public class BaseDbUnitDataLoader
    {
        private const string DatabaseXsd01 = @"IntegrationTests.TestData.Database.xsd";
        private const string TestdataXml01 = @"IntegrationTests.TestData.TestData.xml";

        private const string DatabaseXsd02 = @"..\..\TestData\Database.xsd";
        private const string TestdataXml02 = @"..\..\TestData\TestData.xml";

        private NDbUnit.Core.INDbUnitTest _mySqlDatabase;

        public void DatabaseSetUp()
        {
            _mySqlDatabase.PerformDbOperation(NDbUnit.Core.DbOperationFlag.CleanInsertIdentity);
        }

        public string FindFile(
            string file00,
            string file01)
        {
            if (System.IO.File.Exists(file00))
                return file00;

            return file01;

        }

        public string GetCurrentAssemblyDirectory()
        {
            var currentAssemblyFile = System.Reflection.Assembly.GetAssembly(typeof(BaseDbUnitDataLoader)).Location;

            System.Console.WriteLine("currentAssemblyFile: " + currentAssemblyFile);

            if (string.IsNullOrEmpty(currentAssemblyFile))
                return "";

            var splits = currentAssemblyFile.Split('\\');

            var returnValue = "";

            for (int index = 0; index < splits.Length - 1; index++)
            {
                var split = splits[index];
                returnValue += split + "\\";
            }

            System.Console.WriteLine("returnValue: " + returnValue);

            return returnValue;
        }

        public System.IO.Stream GetDataSchemaFile()
        {
            var thisExe = System.Reflection.Assembly.GetExecutingAssembly();
            System.IO.Stream file = thisExe.GetManifestResourceStream(DatabaseXsd01);

            return file;
        }

        public System.IO.Stream GetDataFile()
        {
            var thisExe = System.Reflection.Assembly.GetExecutingAssembly();
            System.IO.Stream file = thisExe.GetManifestResourceStream(TestdataXml01);

            return file;
        }

        public void DatabaseFixtureSetUp()
        {
            var testdataDatabaseXsd01 = GetDataSchemaFile();
            var testdataTestdataXml01 = GetDataFile();

            var connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["IntegrationTests.Properties.Settings.TDDWithMVCConnectionString"].ConnectionString;
            _mySqlDatabase = new SqlDbUnitTest(connectionString);

            _mySqlDatabase.ReadXmlSchema(testdataDatabaseXsd01);
            _mySqlDatabase.ReadXml(testdataTestdataXml01);
        }

        public void GetMyTestDataXmlFile()
        {
            var connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["IntegrationTests.Properties.Settings.TDDWithMVCConnectionString"].ConnectionString;

            var mySqlDatabase = new SqlDbUnitTest(connectionString);

            mySqlDatabase.ReadXmlSchema(DatabaseXsd02);

            System.Data.DataSet ds = mySqlDatabase.GetDataSetFromDb();
            ds.WriteXml(TestdataXml02);
        }

    }
}