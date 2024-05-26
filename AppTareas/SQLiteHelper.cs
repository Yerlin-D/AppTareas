using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using AppTareas.Model;

namespace AppTareas
{
    public class SQLiteHelper
    {
        private readonly SQLiteAsyncConnection db;

        public SQLiteHelper(string dbPath)
        {
            db = new SQLiteAsyncConnection(dbPath);
            db.CreateTableAsync<TareaModel>();
        }

        public Task<int> CreateTarea (TareaModel tarea)
        {
            return db.InsertAsync(tarea);
        }

        public Task<List<TareaModel>> ReadTarea()
        {
            return db.Table<TareaModel>().ToListAsync();
        }

        public Task<int> UpdateTarea (TareaModel tarea)
        {
            return db.UpdateAsync(tarea);
        }

        public Task<int> DeleteTarea (TareaModel tarea)
        {
            return db.DeleteAsync(tarea);
        }
    }
}
