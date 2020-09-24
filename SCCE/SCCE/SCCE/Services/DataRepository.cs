using SCCE.Data;
using SCCE.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SCCE.Services
{
    public class DataRepository : IDataRepository
    {
        readonly DatabaseHelper _databaseHelper;
        public DataRepository()
        {
            _databaseHelper = new DatabaseHelper();
        }

        public void DeleteData(int dataId)
        {
            _databaseHelper.DeleteData(dataId);
        }

        public void DeleteAllData()
        {
            _databaseHelper.DeleteAll();
        }

        public List<DataTable> GetAllData()
        {
            return _databaseHelper.GetAllData();
        }

        public DataTable GetData(int dataID)
        {
            return _databaseHelper.GetData(dataID);
        }

        public void InsertData(DataTable data)
        {
            _databaseHelper.InsertData(data);
        }

        public void UpdateData(DataTable data)
        {
            _databaseHelper.UpdateData(data);
        }

        public void InsertAll(List<DataTable> data)
        {
            _databaseHelper.InsertAllData(data);
        }
    }
}
