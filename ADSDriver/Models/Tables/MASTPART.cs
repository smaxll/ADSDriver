using ADSDriver.Models.Entities;
using Capital_Data_Driver.Generic;

namespace ADSDriver.Models.Tables
{

    public class MASTPART : TGenericTable<MasterParts>
    {
        public MASTPART()
        {
            _TableName = "MASTPART";
        }

        public MasterParts FindByID(string ID)
        {
            return null;
        }

    }
}
