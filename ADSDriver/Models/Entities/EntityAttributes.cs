using System;

namespace Capital_Data_Driver.Models.Entities
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple = false, Inherited = false)]
    public class ColumnAttribute : Attribute
    {

        public ColumnAttribute(String ColumnName, bool IsID = false)
        {
            this._ColumnName = ColumnName;
            this._ID = IsID;
        }

        protected String _ColumnName;
        public String ColumnName
        {
            get { return this._ColumnName; }
        }

        protected bool _ID;
        public bool ID
        {
            get { return this._ID; }
        }
    }
}
