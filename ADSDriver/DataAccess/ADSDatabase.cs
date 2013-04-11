using System;
using System.Collections.Generic;
using Advantage.Data.Provider;

namespace ADSDriver.DataAccess
{
    public class Database
    {

        private string _strDataSource;
        private string _strDataUsername;
        private string _strDataPassword;

        internal AdsConnectionStringBuilder aCsb;
        internal AdsConnection dbInstance;
        //internal AdsDataReader dbDataReader;
        internal AdsTransaction txn;

        /// <summary>
        /// Create a new instance of the ZNW Database
        /// </summary>
        public Database(string DataSource, string Username, string Password)
        {

            _strDataSource = DataSource;
            _strDataUsername = Username;
            _strDataPassword = Password;

            SetupConnection();

        }


        private void SetupConnection()
        {
            // Load up the configuration to allow access to the datasource
            aCsb = new AdsConnectionStringBuilder();
            aCsb.DataSource = _strDataSource;

            aCsb.ServerType = "Remote";
            aCsb.UserID = _strDataUsername;
            aCsb.Password = _strDataPassword;
            aCsb.TrimTrailingSpaces = true;
            aCsb.TableType = "CDX";
            //aCsb.LockMode = "COMPATIBLE";
            aCsb.ShowDeleted = false;


            // Create the Instance of the datasource
            dbInstance = new AdsConnection();
            dbInstance.ConnectionString = aCsb.ToString();
        }

    

        // Open the Database Connection
        public bool OpenConnection()
        {
            try
            {
                dbInstance.Open();  // Open the database connection
                dbInstance.DateFormat = "DD/MM/CCYY";   // Set date format to DD/MM/YYYY as we are not in the US
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Close the database connection
        /// </summary>
        public void CloseConnection()
        {
            dbInstance.Close();
        }

        /// <summary>
        /// Run an SQl Statement on the Database Server
        /// </summary>
        /// <param name="SQL">SQL Command</param>
        /// <returns>Advantage Database Reader Object</returns>
        public AdsDataReader RunSQL(string SQL)
        {
            AdsCommand sqlCommand;
            AdsDataReader dataReader;

            sqlCommand = new AdsCommand(SQL, dbInstance);

            dataReader = sqlCommand.ExecuteReader();

            return dataReader;

        }

        /// <summary>
        /// Execute an SQL statement and returns the number of rows affected
        /// </summary>
        /// <param name="SQL"></param>
        /// <returns></returns>
        public int RunNonQuery(string SQL)
        {
            AdsCommand sqlCommand;

            sqlCommand = new AdsCommand(SQL, dbInstance);

            return sqlCommand.ExecuteNonQuery();
        }

        public bool ExecuteNonQueriesInTransaction(List<string> queries)
        {
            string curQuery = "";

            txn = dbInstance.BeginTransaction();

            try
            {
                //execute queries
                foreach (string SQL in queries)
                {
                    curQuery = SQL;
                    RunNonQuery(SQL);
                }

                txn.Commit();
            }
            catch (Exception ex )
            {
                //Loggers.DebugLogger.Error("Failed executing the nonqueries. trying to roll back the transaction");
                txn.Rollback();
                //Loggers.DebugLogger.Error("transaction was rolled back successfully");
                throw new Exception(ex.Message + " Current query string: " + curQuery);
            }
            finally
            {

            }

            return true;
        }

        public List<string> GetTableNames()
        {

            //EXECUTE PROCEDURE sp_GetTables(NULL,NULL,NULL,'TABLE')
            return null;
        }
    }
}
