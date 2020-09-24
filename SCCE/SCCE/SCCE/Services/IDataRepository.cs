using SCCE.Data;
using System.Collections.Generic;

namespace SCCE.Services
{
    public interface IDataRepository
    {
        List<DataTable> GetAllData();
        DataTable GetData(int dataID);
        void DeleteAllData();
        void DeleteData(int dataId);
        void InsertData(DataTable data);
        void UpdateData(DataTable data);
        void InsertAll(List<DataTable> data);

    }
}
