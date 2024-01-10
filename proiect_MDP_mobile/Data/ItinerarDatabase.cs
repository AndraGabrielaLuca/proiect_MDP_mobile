using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;
using proiect_MDP_mobile.Models;


namespace proiect_MDP_mobile.Data
{
    public class ItinerarDatabase
    {
        readonly SQLiteAsyncConnection _database;
        public ItinerarDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Itinerar>().Wait();
            _database.CreateTableAsync<Destinatie>().Wait();
            _database.CreateTableAsync<ListaDestinatie>().Wait();
        }

        public Task<int> SaveProductAsync(Destinatie destinatie)
        {
            if (destinatie.ID != 0)
            {
                return _database.UpdateAsync(destinatie);
            }
            else
            {
                return _database.InsertAsync(destinatie);
            }
        }
        public Task<int> DeleteProductAsync(Destinatie destinatie)
        {
            return _database.DeleteAsync(destinatie);
        }
        public Task<List<Destinatie>> GetProductsAsync()
        {
            return _database.Table<Destinatie>().ToListAsync();
        }



        public Task<List<Itinerar>> GetShopListsAsync()
        {
            return _database.Table<Itinerar>().ToListAsync();
        }
        public Task<Itinerar> GetShopListAsync(int id)
        {
            return _database.Table<Itinerar>()
            .Where(i => i.ID == id)
           .FirstOrDefaultAsync();
        }
        public Task<int> SaveShopListAsync(Itinerar slist)
        {
            if (slist.ID != 0)
            {
                return _database.UpdateAsync(slist);
            }
            else
            {
                return _database.InsertAsync(slist);
            }
        }
        public Task<int> DeleteShopListAsync(Itinerar slist)
        {
            return _database.DeleteAsync(slist);
        }


        public Task<int> SaveListProductAsync(ListaDestinatie listp)
        {
            if (listp.ID != 0)
            {
                return _database.UpdateAsync(listp);
            }
            else
            {
                return _database.InsertAsync(listp);
            }
        }
        public Task<List<Destinatie>> GetListProductsAsync(int shoplistid)
        {
            return _database.QueryAsync<Destinatie>(
            "select D.ID, D.Description from Destinatie D"
            + " inner join ListaDestinatie LD"
            + " on D.ID = LD.DestinatieID where LD.ItinerarID = ?",
            shoplistid);
        }

    }
}

