using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Advantage.Data;
using Advantage.Data.Provider;

namespace Capital_Data_Driver.Models.Tables
{

    public class MASTPART : Generic.TGenericTable<Entities.MasterParts>
    {
        public MASTPART()
        {
            _TableName = "MASTPART";
        }

        public Entities.MasterParts FindByID(string ID)
        {
            return null;
        }

    }
}
