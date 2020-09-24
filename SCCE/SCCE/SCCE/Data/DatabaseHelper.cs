using PCLExt.FileStorage;
using PCLExt.FileStorage.Folders;
using SCCE.Models;
using SQLite;
using System.Collections.Generic;
using System.Linq;

namespace SCCE.Data
{
    public class DatabaseHelper
    {
        //defina uma conexao e o  nome do banco de dados
        static SQLiteConnection sqliteconnection;
        public const string DbFileName = "AppDB.db";
        public DatabaseHelper()
        {
            //cria uma pasta base local para o dispositivo
            var pasta = new LocalRootFolder();
            //cria o arquivo
            var arquivo = pasta.CreateFile(DbFileName, CreationCollisionOption.OpenIfExists);
            //abre o BD
            sqliteconnection = new SQLiteConnection(arquivo.Path);
            //cria a tabela no BD
            sqliteconnection.CreateTable<DataTable>();
        }
        //Pegar todos os dados  
        public List<DataTable> GetAllData()
        {
            return (from data in sqliteconnection.Table<DataTable>()
                    select data).ToList();
        }
        //Pegar dados especifico por id
        public DataTable GetData(int id)
        {
            return sqliteconnection.Table<DataTable>().FirstOrDefault(t => t.Id == id);
        }
        // Deletar todos os dados
        public void DeleteAll()
        {
            sqliteconnection.DeleteAll<DataTable>();
        }
        // Deletar um dado especifico por id
        public void DeleteData(int id)
        {
            sqliteconnection.Delete<DataTable>(id);
        }
        // Inserir dados
        public void InsertData(DataTable data)
        {
            sqliteconnection.Insert(data);
        }
        // Atualizar dados
        public void UpdateData(DataTable data)
        {
            sqliteconnection.Update(data);
        }

        public void InsertAllData(List<DataTable> data)
        {
            sqliteconnection.InsertAll(data);
        }
    }
}