using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using App23.Models;
using SQLite;
namespace App23.Data
{
   public  class MyDatabase
    {
        readonly SQLiteAsyncConnection database;

        public int LastInsertid { get; set; }


        public MyDatabase(string path) {
            database = new SQLiteAsyncConnection(path);
            database.CreateTableAsync<ClimaModel>().Wait();



        }

        internal void Delete(object item) {


            database.DeleteAsync(item).Wait();

        }
        internal void DeleteAll()
        {


            database.DeleteAllAsync<ClimaModel>().Wait();

        }

        public async Task<IList<ClimaModel>> GetItems() {


            var result = await database.QueryAsync<ClimaModel>("select * from ClimaModel");
            return result;



        }


        

        public void Insert(ClimaModel item) {

            database.InsertAsync(item).Wait();
        }

        internal void Update(ClimaModel item)
        {
            database.UpdateAsync(item).Wait();
        }
    

}
}
