using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Advantage.Data;
using Advantage.Data.Provider;

namespace Capital_Data_Driver.Generic
{
    public abstract class TGenericTable<T>
    {

        //public AdsDataReader GeneralSQLQuery(String statement)
        //{
        //    AdsDataReader returnReader;
        // }
        //string _ConnString = @"Data Source=" + Properties.Settings.Default.DataSource + ";UserID=" + Properties.Settings.Default.userName + ";Password=" + Properties.Settings.Default.password + ";ServerType=Remote;TableType=ADT";
        protected AdsConnection _dbConn;
        protected AdsCommand _dbCmd;
        protected AdsDataReader _dbReader;
        protected string _TableName;

        public TGenericTable()
        {
            // initialize _dbConnection
            //_dbConn = new AdsConnection(_ConnString);
        }

        public void FindByID(string Value)
        {
            string strIDCol = "INVOICENO";
            string sSQL = "SELECT * FROM " + _TableName + " WHEREN " + strIDCol + " = '" + Value + "';";
        }

        public AdsConnection Get_dbConnection()
        {
            return _dbConn;
        }

        public AdsCommand GetCommand()
        {

            // make the _dbConnection to the server 
            _dbConn.Open();

            // create a command object 
            _dbCmd = _dbConn.CreateCommand();

            return _dbCmd;
        }

        public void close_dbConnection()
        {
            _dbConn.Close();
        }

    }
}
