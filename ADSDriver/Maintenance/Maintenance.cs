using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ADSDriver.DataAccess;
using Advantage.Data.Provider;

namespace Capital_Data_Driver.Maintenance
{

    public class Maintenance
    {
        #region Events and Delegates
        // A delegate for hooking up ReIndexing Progress
        public delegate void ReIndexProgressEventHandler(object sender, int Progress, string CurrentTable);
        public event ReIndexProgressEventHandler ReIndexProgress;

        protected virtual void OnReIndexProgress(int Progress, string CurrentTable)
        {
            ReIndexProgress(this, Progress, CurrentTable);
        }

        public delegate void ReIndexCompleteEventHandler(object sender, List<string> OpenTableList);
        public event ReIndexCompleteEventHandler OnReIndexComplete;

        // A delegate for hooking up Packing Progress
        public delegate void PackProgressEventHandler(object sender, int Progress, string CurrentTable);
        public event PackProgressEventHandler PackProgress;

        protected virtual void OnPackProgress(int Progress, string CurrentTable)
        {
            PackProgress(this, Progress, CurrentTable);
        }

        public delegate void PackCompleteEventHandler(object sender, List<string> OpenTableList);
        public event PackCompleteEventHandler OnPackComplete;
        #endregion


        /// <summary>
        /// ReIndex Tables
        /// </summary>
        /// <param name="DataSource"></param>
        /// <param name="DataUsername"></param>
        /// <param name="DataPassword"></param>
        public void ReIndexTables(string DataSource, string DataUsername, string DataPassword)
        {
            Database dba = new Database(DataSource, DataUsername, DataPassword);
            List<string> TableList = new List<string>();
            List<string> OpenTables = new List<string>();
            AdsDataReader reader;

            // Get list of tables
            dba.OpenConnection();
            reader = dba.RunSQL("EXECUTE PROCEDURE sp_GetTables(NULL,NULL,NULL,'TABLE');");
            while (reader.Read())
            {
                TableList.Add(reader.GetValue(2).ToString());
            }
            dba.CloseConnection();

            // ReIndex Tables
            dba.OpenConnection();
            int a = 1;
            foreach (string strTable in TableList)
            {
                double dblProgress = (double)((double)a / (double)TableList.Count) * 100;
                OnReIndexProgress((int)dblProgress, strTable);
                try
                {
                    dba.RunNonQuery("EXECUTE PROCEDURE sp_Reindex('" + strTable + "',0);");
                }
                catch (Exception ex)
                {
                    OpenTables.Add(strTable);
                }
                a++;
            }
            dba.CloseConnection();
            OnReIndexComplete(this, OpenTables);
        }

        /// <summary>
        /// Pack Tables
        /// </summary>
        /// <param name="DataSource"></param>
        /// <param name="DataUsername"></param>
        /// <param name="DataPassword"></param>
        public void PackTables(string DataSource, string DataUsername, string DataPassword)
        {
            Database dba = new Database(DataSource, DataUsername, DataPassword);
            List<string> TableList = new List<string>();
            List<string> OpenTables = new List<string>();
            AdsDataReader reader;

            // Get list of tables
            dba.OpenConnection();
            reader = dba.RunSQL("EXECUTE PROCEDURE sp_GetTables(NULL,NULL,NULL,'TABLE');");
            while (reader.Read())
            {
                TableList.Add(reader.GetValue(2).ToString());
            }
            dba.CloseConnection();

            // Pack Tables
            dba.OpenConnection();
            int a = 1;
            foreach (string strTable in TableList)
            {
                double dblProgress = (double)((double)a / (double)TableList.Count) * 100;
                OnPackProgress((int)dblProgress, strTable);
                try
                {
                    dba.RunNonQuery("EXECUTE PROCEDURE sp_PackTable('" + strTable + "');");
                }
                catch (Exception ex)
                {
                    OpenTables.Add(strTable);
                }
                a++;
            }
            dba.CloseConnection();
            OnPackComplete(this, OpenTables);
        }

    }
}
