using ADSDriver.DataAccess;
using Advantage.Data.Provider;
using NUnit.Framework;


namespace ADSDriverTest
{
    [TestFixture]
    public class DatabaseConnectionTest
    {
        [SetUp]
        public void Init()
        {

        }


        /// <summary>
        /// Test connection to Bo-Test Company
        /// </summary>
        [Test]
        public void ConnectToBoTest()
        {
            var dbDriver = new Database(DataSource: @"E:\Capital\Bo-Test", Username: null, Password: null);

            try
            {
                Assert.True(dbDriver.OpenConnection());
            }catch(AdsException ex)
            {
                dbDriver.CloseConnection();
            }

            dbDriver.CloseConnection();
        }

        /// <summary>
        /// Test connection to Bo-Test Company
        /// </summary>
        [Test]
        public void ConnectToNormistLive()
        {
            var dbDriver = new Database(DataSource: @"E:\Capital\Normist", Username: null, Password: null);

            try
            {
                Assert.True(dbDriver.OpenConnection());
            }
            catch (AdsException ex)
            {
                dbDriver.CloseConnection();
            }

            dbDriver.CloseConnection();
        }


        [TearDown]
        public void Clean()
        {
            
        }
    }
}
